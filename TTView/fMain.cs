using FarsiLibrary.Win;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TTView
{
    public class fMain : Form, IMain
    {
        Color __BG = Color.Black;
        PictureBox m_image;

        #region [ MAIN ]

        oApp m_app;
        FATabStrip m_tabs;
        ContextMenuStrip m_menu;
        Panel m_toolbar;
        Label m_message;

        const bool m_hook_MouseMove = true;
        Panel m_resize;
        bool m_resizing = false;

        public fMain(oApp app)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            m_app = app;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = __BG;

            this.KeyPreview = true;
            this.KeyUp += main_keyUp;
            this.Shown += main_initUI;
        }

        void main_initUI(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;

            m_tabs = new FATabStrip()
            {
                Dock = DockStyle.Fill,
                //AlwaysShowClose = false
                //AlwaysShowMenuGlyph = false,
            };
            this.Controls.Add(m_tabs);
            m_tabs.ClickClose += (se, ev) => { this.Close(); };
            m_tabs.MouseMove += f_form_move_MouseDown;
            m_tabs.TabStripItemSelectionChanged += (se) =>
            {
                if (se.ChangeType == FATabStripItemChangeTypes.SelectionChanged)
                    tab_Change();
            };

            // RESIZE
            m_resize = new Panel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.Black,
                Size = new Size(8, 8),
                Top = this.Height - 8,
                Left = this.Width - 8,
            };
            this.Controls.Add(m_resize);
            m_resize.MouseDown += (se, ev) => { f_hook_mouse_Open(); m_resizing = true; };
            m_resize.MouseUp += (se, ev) =>
            {
                m_resizing = false;
                f_hook_mouse_Close();
                //Debug.WriteLine("RESIZE: ok ");
                //if (m_media.playState == WMPLib.WMPPlayState.wmppsPlaying)
                //{
                //    m_media.Ctlcontrols.pause();
                //    m_media.Ctlcontrols.play();
                //}
                //else if (m_media.playState == WMPLib.WMPPlayState.wmppsPaused)
                //{
                //    m_media.Ctlcontrols.play();
                //    m_media.Ctlcontrols.pause();
                //}
            };
            m_resize.BringToFront();

            toolbar_initUI();
            menu_initUI();

            openHistory();
        }

        ToolStripMenuItem menu_Create(string text, string code = "")
        {
            var m = new ToolStripMenuItem(text) { Tag = code };
            if (!string.IsNullOrEmpty(code))
                m.Click += (se, ev) => menu_Command(code, m);
            return m;
        }

        void main_keyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                    page_Go(1);
                    break;
                case Keys.Left:
                    page_Go(-1);
                    break;
            }
        }

        /*////////////////////////////////////////////////////////////////////////*/

        #region [ MOUSE MOVE: IN FORM, OUT FORM ]

        private void f_mouse_move_intoForm(int x, int y)
        {
            f_form_Resize(x, y, MOUSE_XY.INT);
        }

        private void f_mouse_move_outForm(int x, int y)
        {
            f_form_Resize(x, y, MOUSE_XY.OUT);
        }

        #endregion

        #region [ FORM MOVE, RESIZE ]

        enum MOUSE_XY { OUT, INT };

        void f_form_Resize(int x, int y, MOUSE_XY type)
        {
            if (m_resizing)
            {
                int max_x = this.Location.X + this.Width;
                int max_y = this.Location.Y + this.Height;
                this.Width = x - this.Location.X;
                this.Height = y - this.Location.Y;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void f_form_move_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region [ HOOK MOUSE: MOVE, WHEEL ... ]

        void f_hook_mouse_move_CallBack(MouseEventArgs e)
        {
            int max_x = this.Width + this.Location.X,
                max_y = e.Location.Y + this.Height;
            //Debug.WriteLine(this.Location.X + " " +e.X  + " " + max_x + " | " + this.Location.Y + " " +e.Y  + " " + max_y);

            if (e.X > this.Location.X && e.X < max_x
                && e.Y > this.Location.Y && e.Y < max_y)
            {
                //Debug.WriteLine("IN FORM: "+ this.Location.X + " " + e.X + " " + max_x + " | " + this.Location.Y + " " + e.Y + " " + max_y);
                f_mouse_move_intoForm(e.X, e.Y);
            }
            else
            {
                //Debug.WriteLine("OUT FORM: " + this.Location.X + " " + e.X + " " + max_x + " | " + this.Location.Y + " " + e.Y + " " + max_y);
                f_mouse_move_outForm(e.X, e.Y);
            }
        }

        void f_hook_mouse_Open()
        {
            if (m_hook_MouseMove)
                f_hook_mouse_SubscribeGlobal();
        }

        void f_hook_mouse_Close()
        {
            if (m_hook_MouseMove)
                f_hook_mouse_Unsubscribe();
        }

        /*////////////////////////////////////////////////////////////////////////*/

        private IKeyboardMouseEvents hook_events;

        private void f_hook_mouse_SubscribeApplication()
        {
            f_hook_mouse_Unsubscribe();
            f_hook_mouse_Subscribe(Hook.AppEvents());
        }

        private void f_hook_mouse_SubscribeGlobal()
        {
            f_hook_mouse_Unsubscribe();
            f_hook_mouse_Subscribe(Hook.GlobalEvents());
        }

        private void f_hook_mouse_Subscribe(IKeyboardMouseEvents events)
        {
            hook_events = events;
            //m_Events.KeyDown += OnKeyDown;
            //m_Events.KeyUp += OnKeyUp;
            //m_Events.KeyPress += HookManager_KeyPress;

            //m_Events.MouseUp += OnMouseUp;
            //m_Events.MouseClick += OnMouseClick;
            //m_Events.MouseDoubleClick += OnMouseDoubleClick;

            hook_events.MouseMove += f_hook_mouse_HookManager_MouseMove;

            //m_Events.MouseDragStarted += OnMouseDragStarted;
            //m_Events.MouseDragFinished += OnMouseDragFinished;

            //if (checkBoxSupressMouseWheel.Checked)
            //m_Events.MouseWheelExt += f_hook_mouse_HookManager_MouseWheelExt;
            //else
            ////hook_events.MouseWheel += f_hook_mouse_HookManager_MouseWheel;

            //if (checkBoxSuppressMouse.Checked)
            //m_Events.MouseDownExt += HookManager_Supress;
            //else
            //m_Events.MouseDown += OnMouseDown;
        }


        private void f_hook_mouse_Unsubscribe()
        {
            if (hook_events == null) return;
            //m_Events.KeyDown -= OnKeyDown;
            //m_Events.KeyUp -= OnKeyUp;
            //m_Events.KeyPress -= HookManager_KeyPress;

            //m_Events.MouseUp -= OnMouseUp;
            //m_Events.MouseClick -= OnMouseClick;
            //m_Events.MouseDoubleClick -= OnMouseDoubleClick;

            hook_events.MouseMove -= f_hook_mouse_HookManager_MouseMove;

            //m_Events.MouseDragStarted -= OnMouseDragStarted;
            //m_Events.MouseDragFinished -= OnMouseDragFinished;

            //if (checkBoxSupressMouseWheel.Checked)
            //m_Events.MouseWheelExt -= f_hook_mouse_HookManager_MouseWheelExt;
            //else
            //hook_events.MouseWheel -= f_hook_mouse_HookManager_MouseWheel;

            //if (checkBoxSuppressMouse.Checked)
            //m_Events.MouseDownExt -= HookManager_Supress;
            //else
            //m_Events.MouseDown -= OnMouseDown;

            hook_events.Dispose();
            hook_events = null;
        }

        private void f_hook_mouse_HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            f_hook_mouse_move_CallBack(e);
        }

        ////private void f_hook_mouse_HookManager_MouseWheel(object sender, MouseEventArgs e)
        ////{
        ////    //Debug.WriteLine(string.Format("Wheel={0:000}", e.Delta));
        ////    //f_hook_mouse_wheel_CallBack(e);
        ////}

        ////private void f_hook_mouse_HookManager_MouseWheelExt(object sender, MouseEventExtArgs e)
        ////{
        ////    //Debug.WriteLine(string.Format("Wheel={0:000}", e.Delta)); 
        ////    //Debug.WriteLine("Mouse Wheel Move Suppressed.\n");
        ////    e.Handled = true;
        ////    //e.Handled = true; // true: break event at here, stop mouse wheel at here
        ////}

        /////////////////////////////////////////////////////////////


        #endregion

        /*////////////////////////////////////////////////////////////////////////*/

        #endregion

        oFile _getFile(string file)
            => m_app.Files.Where(x => x.File == file).Take(1).SingleOrDefault();

        oFile _updateInfoFile(string file, long docId, int pageTotal) {
            var fi = _getFile(file);
            if (fi == null)
            {
                fi = new oFile() { File = file, PageTotal = pageTotal, Id = docId };
                m_app.Files.Add(fi);
            }
            else {
                fi.Id = docId;
                fi.PageTotal = pageTotal;
            }
            return fi;
        }

        public void _requestReply(string requestId, COMMANDS cmd, string input, Dictionary<string, object> data)
        {
            if (input == m_app.FileCurrent.File)
            {
                var id = data.Get<long>("id");
                var page_total = data.Get<int>("page_total");
                var page = data.Get<int>("page");
                m_message.Text = string.Format("{0}-{1}...", page, page_total);

                if (page == 0)
                {
                    m_app.FileCurrent = _updateInfoFile(input, id, page_total);
                    page_Go(page);
                }

                if (page == page_total)
                {
                    m_message.Text = string.Format("{0}-{1} done", page, page_total);
                }
            }
        }

        void toolbar_initUI()
        {
            m_message = new Label()
            {
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
            m_toolbar = new Panel()
            {
                Height = 18,
                Dock = DockStyle.Bottom,
                Visible = !m_app.Setting.HideToolbar
            };
            m_toolbar.Controls.Add(m_message);
            this.Controls.Add(m_toolbar);
        }

        void menu_initUI()
        {
            m_menu = new ContextMenuStrip();
            m_menu.Items.Add(menu_Create("Open", "OPEN"));
            m_menu.Items.Add(new ToolStripSeparator());
            m_menu.Items.Add(menu_Create("Close Tab", "CLOSE_TAB"));

            var setting = menu_Create("Setting");
            var s1 = menu_Create("Auto Resize", "SETTING_AUTO_RESIZE");
            s1.Checked = m_app.Setting.AutoResize;
            s1.CheckState = m_app.Setting.AutoResize ? CheckState.Checked : CheckState.Unchecked;

            var s2 = menu_Create("Open All  | 10 Items", "SETTING_OPEN_ALL_|_10");
            s2.Checked = m_app.Setting.OpenAllOr10;
            s2.CheckState = m_app.Setting.OpenAllOr10 ? CheckState.Checked : CheckState.Unchecked;

            var s3 = menu_Create("Hide Toolbar", "SETTING_HIDE_TOOLBAR");
            s3.Checked = m_app.Setting.HideToolbar;
            s3.CheckState = m_app.Setting.HideToolbar ? CheckState.Checked : CheckState.Unchecked;

            setting.DropDownItems.AddRange(new ToolStripItem[] { s1, s2, s3 });
            m_menu.Items.Add(setting);

            m_menu.Items.Add(new ToolStripSeparator());
            m_menu.Items.Add(menu_Create("Close", "EXIT"));
            m_tabs.ContextMenuStrip = m_menu;
        }

        void menu_Command(string code, ToolStripMenuItem menu)
        {
            switch (code)
            {
                case "OPEN":
                    openDialog();
                    break;
                case "CLOSE_TAB":
                    break;
                case "SETTING_AUTO_RESIZE":
                    menu.Checked = !menu.Checked;
                    m_app.Setting.AutoResize = menu.Checked;
                    break;
                case "SETTING_OPEN_ALL_|_10":
                    menu.Checked = !menu.Checked;
                    m_app.Setting.OpenAllOr10 = menu.Checked;
                    break;
                case "SETTING_HIDE_TOOLBAR":
                    menu.Checked = !menu.Checked;
                    m_app.Setting.HideToolbar = menu.Checked;
                    m_toolbar.Visible = !menu.Checked;
                    break;
                case "EXIT":
                    this.Close();
                    break;
            }
        }

        void tab_Change() {
            string file = m_tabs.SelectedItem.Tag as string;
        }

        void tab_Create(string file)
        {
            var fi = _getFile(file);
            if (fi == null) {
                fi = new oFile() { File = file };
                m_app.Files.Add(fi);
            }

            string title = Path.GetFileNameWithoutExtension(file);

            var image = new PictureBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = __BG,
                Top = 0,
                Left = 0,
                Width = this.Width - 40,
                Height = this.Height - 90
            };
            var box = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                AutoScroll = true,
            };
            box.Controls.Add(image);
            image.MouseDoubleClick += (se, ev) => openDialog();

            var tab = new FATabStripItem(title, box)
            {
                Tag = file,
                CanClose = false,
                BackColor = __BG
            };
            box.MouseMove += f_form_move_MouseDown;
            image.MouseMove += f_form_move_MouseDown;
            m_tabs.Items.Add(tab);

            m_image = image;
            var requestId = App.Send(COMMANDS.PDF_SPLIT_ALL_JPG, file);
        }

        void page_Go(int page = 0)
        {
            if (page > -1 && page < m_app.FileCurrent.PageTotal)
            {
                m_app.FileCurrent.PageCurrent = page;
                var img = App.GetBitmap(m_app.FileCurrent.Id, page);
                m_image.Image = img;
            }
        }

        void openHistory()
        {
            if (!string.IsNullOrEmpty(m_app.FileCurrent.File))
                tab_Create(m_app.FileCurrent.File);
        }

        void openDialog()
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                d.Filter = "pdf files (*.pdf)|*.pdf|TT files (*.tt)|*.tt|All files (*.*)|*.*";
                d.FilterIndex = 1;
                d.RestoreDirectory = true;
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (d.FileName.EndsWith(".pdf")) openFilePdf(d.FileName);
                    else if (d.FileName.EndsWith(".tt")) openFileTT(d.FileName);
                }
            }
        }

        void openFilePdf(string file)
        {
            m_app.FileCurrent.File = file;
            m_app.Setting.Directory = Path.GetDirectoryName(file);
            tab_Create(file);
        }

        void openFileTT(string file)
        {
            m_app.FileCurrent.File = file;
            m_app.Setting.Directory = Path.GetDirectoryName(file);
            tab_Create(file);
        }
    }
}
