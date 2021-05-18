using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TTView
{
    public partial class fSetting : Form
    {
        #region [ MAIN ]

        public fSetting()
        {
            InitializeComponent();

            m_tabs.WindowClosed += (se, ev) => {
                this.Close();
            };
        }

        private void fSetting_Load(object sender, EventArgs e)
        {
            m_tabs.MouseMove += f_form_move_MouseDown;
            ui_panelGeneral.MouseMove += f_form_move_MouseDown;
            ui_groupOCR.MouseMove += f_form_move_MouseDown;
            ui_groupProcessImage.MouseMove += f_form_move_MouseDown;

            ui_selectOcrLanguage.SelectedIndex = 1;
            ui_selectOcrEngineMode.SelectedIndex = 3;
            ui_selectOcrLevel.SelectedIndex = 3;
        }

        private void fSetting_Shown(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) - 40;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
            => _save();
        
        #endregion

        #region [ MOVE ]

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

        void _save() { 
        
        }
    }
}
