using FarsiLibrary.Win;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TTView
{
    public class fMain : Form, IMain
    {
        Color __BG_GRAY = Color.DimGray;
        Color __BG_BLACK = Color.Black;
        Color __TEXT_COLOR = Color.White;

        #region [ MAIN ]

        PictureBox __image;
        oFile __file;

        oApp m_app;
        FATabStrip m_tabs;
        ContextMenuStrip m_menu;
        Panel m_toolbar;

        Label m_message;
        Label m_size;

        const bool m_hook_MouseMove = true;
        Panel m_resize;
        bool m_resizing = false;

        public fMain(oApp app)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            m_app = app;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = __BG_GRAY;

            this.KeyPreview = true;
            this.KeyUp += main_keyUp;
            this.Shown += main_initUI;
        }

        void main_initUI(object sender, EventArgs e)
        {
            this.Top = m_app.Window.Top;
            this.Left = m_app.Window.Left;
            this.Width = m_app.Window.Width;
            this.Height = m_app.Window.Height;

            m_tabs = new FATabStrip()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 11.0f)
            };
            this.Controls.Add(m_tabs);
            m_tabs.WindowClosed += (se, ev) => { this.Close(); };
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
                BackColor = __BG_BLACK,
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

        void toolbar_initUI()
        {
            m_size = new Label()
            {
                AutoSize = false,
                Width = 99,
                ForeColor = __TEXT_COLOR,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right,
                Text = "0 kb"
            };
            m_message = new Label()
            {
                ForeColor = __TEXT_COLOR,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
            m_toolbar = new Panel()
            {
                Height = 18,
                Dock = DockStyle.Bottom,
                Visible = !m_app.Setting.HideToolbar,
                Padding = new Padding(0, 0, 10, 0)
            };
            m_toolbar.Controls.AddRange(new Control[] { m_message, m_size });
            this.Controls.Add(m_toolbar);
        }

        #endregion

        #region [ MENU - COMMAND REPLY ]

        void menu_initUI()
        {
            m_menu = new ContextMenuStrip();
            m_menu.Items.Add(menu_Create("Open", "OPEN"));
            m_menu.Items.Add(menu_Create("Recent Files", "RECENT_FILES"));
            m_menu.Items.Add(new ToolStripSeparator());
            m_menu.Items.Add(menu_Create("Setting", "OPEN_SETTING"));
            m_menu.Items.Add(new ToolStripSeparator());
            m_menu.Items.Add(menu_Create("Close Tab", "CLOSE_TAB"));

            //m_menu.Items.Add(new ToolStripSeparator());
            //m_menu.Items.Add(menu_Create("Select Lines On Page", "OCR_BOX_PAGE"));
            //m_menu.Items.Add(menu_Create("Setting For Select Lines", "OCR_BOX_SETTING"));
            //m_menu.Items.Add(new ToolStripSeparator());
            //m_menu.Items.Add(menu_Create("Get Text This Page", "OCR_TEXT_PAGE"));
            //m_menu.Items.Add(menu_Create("Get Text All Page", "OCR_TEXT_ALL_PAGE"));

            //var setting = menu_Create("Setting");
            //var s1 = menu_Create("Auto Resize", "SETTING_AUTO_RESIZE");
            //s1.Checked = m_app.Setting.AutoResize;
            //s1.CheckState = m_app.Setting.AutoResize ? CheckState.Checked : CheckState.Unchecked;

            //var s2 = menu_Create("Open All  | 10 Items", "SETTING_OPEN_ALL_|_10");
            //s2.Checked = m_app.Setting.OpenAllOr10;
            //s2.CheckState = m_app.Setting.OpenAllOr10 ? CheckState.Checked : CheckState.Unchecked;

            //var s3 = menu_Create("Hide Toolbar", "SETTING_HIDE_TOOLBAR");
            //s3.Checked = m_app.Setting.HideToolbar;
            //s3.CheckState = m_app.Setting.HideToolbar ? CheckState.Checked : CheckState.Unchecked;

            //setting.DropDownItems.AddRange(new ToolStripItem[] { s1, s2, s3 });
            //m_menu.Items.Add(setting);

            //m_menu.Items.Add(new ToolStripSeparator());
            //m_menu.Items.Add(menu_Create("Close", "EXIT"));
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
                    //m_app.Setting.AutoResize = menu.Checked;
                    break;
                case "SETTING_OPEN_ALL_|_10":
                    menu.Checked = !menu.Checked;
                    m_app.Setting.Only10PageFirstlyOrAll = menu.Checked;
                    break;
                case "SETTING_HIDE_TOOLBAR":
                    menu.Checked = !menu.Checked;
                    m_app.Setting.HideToolbar = menu.Checked;
                    m_toolbar.Visible = !menu.Checked;
                    break;
                case "RECENT_FILES":
                    openFormRecentFiles();
                    break;
                case "OCR_TEXT_PAGE":
                    App.Send(COMMANDS.OCR_TEXT_PAGE, string.Format("{0}.{1}", __file.Id, __file.PageCurrent));
                    break;
                case "OCR_TEXT_ALL_PAGE":
                    App.Send(COMMANDS.OCR_TEXT_ALL_PAGE, string.Format("{0}", __file.Id));
                    break;

                case "OCR_BOX_SETTING":
                    ocrBoxSetting();
                    break;
                case "OCR_BOX_PAGE":
                    App.Send(COMMANDS.OCR_BOX_PAGE, string.Format("{0}.{1}", __file.Id, __file.PageCurrent));
                    break;
                case "OCR_BOX_ALL_PAGE":
                    App.Send(COMMANDS.OCR_BOX_ALL_PAGE, string.Format("{0}", __file.Id));
                    break;
                case "OPEN_SETTING":
                    new fSetting(m_app, this).ShowDialog();
                    break;
                case "EXIT":
                    this.Close();
                    break;
            }
        }

        public void _requestReply(string requestId, COMMANDS cmd, string input, Dictionary<string, object> data)
        {
            switch (cmd)
            {
                case COMMANDS.PDF_SPLIT_ALL_JPG:
                    var id = data.Get<long>("id");
                    var page_total = data.Get<int>("page_total");
                    var page = data.Get<int>("page");
                    m_message.Text = string.Format("{0}-{1}...", page, page_total);

                    if (page == __file.PageCurrent)
                    {
                        _updateInfoFile(input, id, page_total);
                        if (m_tabs.Items.Count == 1) page_Go(0);
                    }

                    if (page == page_total)
                    {
                        m_message.Text = string.Format("{0}-{1} done", page, page_total);
                    }
                    break;
                case COMMANDS.OCR_BOX_PAGE:
                    ocrBoxResponse(data);
                    break;
                case COMMANDS.OCR_TEXT_PAGE:
                    convertPageCurrent(data);
                    break;
                case COMMANDS.OCR_TEXT_ALL_PAGE:
                    convertPageAll(data);
                    break;
            }
        }

        #endregion

        #region [ TAB OPEN ]

        void openFormRecentFiles()
        {
            var main = this;
            var fm = new Form()
            {
                BackColor = __BG_GRAY,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MinimizeBox = false,
                MaximizeBox = false,
                Left = main.Left,
                Width = main.Width,
                Height = 500
            };
            fm.Shown += (se, ev) =>
            {
                this.Left = main.Left;
            };
            var ls = new ListBox()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Arial", 15.0f),
                BackColor = __BG_GRAY,
                ForeColor = Color.White
            };
            ls.SelectedIndexChanged += (se, ev) =>
            {
                //if (ls.SelectedIndex == -1) return;
                //var fi = m_app.Files[ls.SelectedIndex];
                //tab_Create(fi.File);
                //fm.Close();
            };
            //foreach (var fo in m_app.Files) ls.Items.Add(Path.GetFileNameWithoutExtension(fo.File));
            fm.Controls.Add(ls);
            fm.ShowDialog();
        }

        void openHistory()
        {
            if (m_app.FileCurrent != null
                && !string.IsNullOrEmpty(m_app.FileCurrent.File))
            {
                __file = m_app.FileCurrent;
                tab_Create(__file.File);
            }
        }

        void openDialog()
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                d.Filter = "pdf files (*.pdf)|*.pdf|TT files (*.tt)|*.tt|All files (*.*)|*.*";
                d.FilterIndex = 1;
                d.RestoreDirectory = true;
                if (d.ShowDialog() == DialogResult.OK) tab_Create(d.FileName);
            }
        }

        oFile _getFile(string file)
        {
            return null;
        }

        oFile _updateInfoFile(string file, long docId, int pageTotal)
        {
            var fi = _getFile(file);
            if (fi == null)
            {
                fi = new oFile() { File = file, PageTotal = pageTotal, Id = docId };
                //m_app.Files.Add(fi);
            }
            else
            {
                fi.Id = docId;
                fi.PageTotal = pageTotal;
            }
            return fi;
        }

        void tab_Change()
        {
            string file = m_tabs.SelectedItem.Tag as string;
            var fi = _getFile(file);
            if (fi != null)
            {
                __file = fi;
                m_app.FileCurrent = fi;
                __image = m_tabs.SelectedItem.Controls[0].Controls[0] as PictureBox;
                page_Go();
            }
        }

        void tab_Create(string file)
        {
            var fi = _getFile(file);
            if (fi == null)
            {
                fi = new oFile() { File = file };
                //m_app.Files.Add(fi);
            }

            if (m_tabs.SelectedItem != null && m_tabs.SelectedItem.Tag.ToString() == file) return;
            if (m_tabs.Items.Count > 0)
            {
                for (int i = 0; i < m_tabs.Items.Count; i++)
                {
                    if (m_tabs.Items[i].Tag.ToString() == file)
                    {
                        m_tabs.SelectedItem = m_tabs.Items[i];
                        __file = fi;
                        if (fi.PageTotal == 0) App.Send(COMMANDS.PDF_SPLIT_ALL_JPG, file);
                        else page_Go();
                        return;
                    }
                }
            }

            string title = string.Format("{0}-{1}.{2}", fi.PageCurrent + 1, fi.PageTotal, Path.GetFileNameWithoutExtension(file));

            var image = new PictureBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = __BG_GRAY,
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
                BackColor = __BG_BLACK
            };
            box.Controls.Add(image);
            image.MouseDoubleClick += (se, ev) => openDialog();

            var tab = new FATabStripItem(title, box)
            {
                Tag = file,
                CanClose = false,
                BackColor = __BG_GRAY
            };
            box.MouseMove += f_form_move_MouseDown;
            image.MouseMove += f_form_move_MouseDown;
            m_tabs.Items.Add(tab);

            if (fi.PageTotal == 0) App.Send(COMMANDS.PDF_SPLIT_ALL_JPG, file);
        }

        void page_Go(int k = 0)
        {
            int page = __file.PageCurrent + k;
            if (page > -1 && page < __file.PageTotal)
            {
                __file.PageCurrent = page;
                var img = App.GetBitmap(__file.Id, page);
                if (img == null)
                {
                    App.Send(COMMANDS.PDF_SPLIT_ALL_JPG, __file.File);
                    return;
                }
                if (__image != null)
                {
                    __image.Image = img;
                    m_tabs.SelectedItem.Title =
                        string.Format("{0}-{1}.{2}", page + 1, __file.PageTotal,
                        Path.GetFileNameWithoutExtension(__file.File));

                    __image.Width = img.Width;
                    __image.Height = img.Height;

                    using (var ms = new MemoryStream())
                    {
                        img.Save(ms, ImageFormat.Jpeg);
                        m_size.Text = string.Format("{0} kb", (int)(ms.ToArray().Length / 1024));
                    }
                }
            }
        }

        #endregion

        #region [ OCR ]

        void ocrBoxSetting()
        {

        }

        void ocrBoxResponse(Dictionary<string, object> data)
        {
            var id = data.Get<long>("id");
            var page = data.Get<int>("page");
            var box_count = data.Get<int>("box_count");
            var box_text = data.Get<string>("box_text");
            var box_format = data.Get<string>("box_format");
            if (id == __file.Id && page == __file.PageCurrent)
            {
                if (!string.IsNullOrEmpty(box_text))
                {
                    var a = box_text.Split('|').Select(x => x.Split('_').Select(i => int.Parse(i)).ToArray()).ToArray();

                    Image image = (Image)__image.Image.Clone();
                    using (Graphics g = Graphics.FromImage(image))
                    {
                        Pen blackPen = new Pen(Color.Red, 1);
                        for (int i = 0; i < a.Length; i++)
                        {
                            Rectangle rect = new Rectangle(a[i][0], a[i][1], a[i][2], a[i][3]);
                            g.DrawRectangle(blackPen, rect);
                        }
                    }

                    __image.Image = image;
                }
            }
        }

        void convertPageCurrent(Dictionary<string, object> data)
        {

        }

        void convertPageAll(Dictionary<string, object> data)
        {

        }

        #endregion
    }
}
