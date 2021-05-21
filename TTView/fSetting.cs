using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TTView
{
    public partial class fSetting : Form
    {
        #region [ MAIN ]

        readonly oApp m_app;
        readonly IMain m_main;
        public fSetting(oApp app, IMain main)
        {
            m_app = app;
            m_main = main;

            InitializeComponent();

            m_tabs.WindowClosed += (se, ev) => {
                app.WriteFile();
                this.Close();
            };
            this.Shown += (se, ev) =>
            {
                bindSetting();
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
            => __writeSettingChanged();
        
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

        void bindSetting() {
            var setting = m_app.Setting;

            ui_checkOnly10PageFirstlyOrAll.Checked = setting.Only10PageFirstlyOrAll;
            ui_checkViewModeNoBorder.Checked = setting.ViewModeNoBorder;
            ui_DrawSelectionImageAndWord.Checked = setting.DrawSelectionImageWord;
            ui_HideToolbarFooter.Checked = setting.HideToolbar;
            
            ui_selectOcrEngineMode.SelectedIndex = setting.OcrEngine;
            ui_selectOcrLanguage.SelectedIndex = setting.OcrLanguage;
            ui_selectOcrLevel.SelectedIndex = setting.OcrLevel;

            ui_textDpiX.Text = setting.ImageDpiX.ToString();
            ui_textDpiY.Text = setting.ImageDpiY.ToString();

            ui_txtPathStoreFilePublish.Text = setting.PathStoreFilePublish;
            ui_txtPathStoreFileRaw.Text = setting.PathStoreFileRaw;

            ui_textDpiX.Text = setting.ImageDpiX.ToString();
            ui_textDpiY.Text = setting.ImageDpiY.ToString();
            ui_textMinWidth.Text = setting.ImageMinWidth.ToString();
            ui_textQuantity.Text = setting.ImageQuantity.ToString();

            ui_textRedisIP.Text = m_app.Redis.Host;
            ui_textRedisDB.Text = m_app.Redis.Db.ToString();
            ui_textRedisPort.Text = m_app.Redis.Port.ToString();
        }

        void __writeSettingChanged() {
            var setting = m_app.Setting;
            setting.PathStoreFilePublish = ui_txtPathStoreFilePublish.Text.Trim();
            setting.PathStoreFileRaw = ui_txtPathStoreFileRaw.Text.Trim();

            int dpix = 90;
            int.TryParse(ui_textDpiX.Text, out dpix);
            setting.ImageDpiX = dpix;
            int dpiy = 90;
            int.TryParse(ui_textDpiY.Text, out dpiy);
            setting.ImageDpiY = dpiy;
            int quantity = 50;
            int.TryParse(ui_textQuantity.Text, out quantity);
            setting.ImageQuantity = quantity;
            int minWidth = 1024;
            int.TryParse(ui_textMinWidth.Text, out minWidth);
            setting.ImageMinWidth = minWidth;

            int port = 1000;
            int.TryParse(ui_textRedisPort.Text, out port);
            m_app.Redis.Port = port;
            int db = 0;
            int.TryParse(ui_textRedisDB.Text, out db);
            m_app.Redis.Db = db;
            m_app.Redis.Host = ui_textRedisIP.Text.Trim();

            m_app.WriteFile();
        }

        void openDialog()
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                d.Filter = "pdf files (*.pdf)|*.pdf|TT files (*.tt)|*.tt|All files (*.*)|*.*";
                d.FilterIndex = 1;
                d.RestoreDirectory = true;
                //if (d.ShowDialog() == DialogResult.OK) tab_Create(d.FileName);
            }
        }

        private void ui_btnPathStoreFileRaw_Click(object sender, EventArgs e)
        {
            using (var d = new FolderBrowserDialog())
            {
                DialogResult result = d.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(d.SelectedPath))
                {
                    ui_txtPathStoreFileRaw.Text = d.SelectedPath;
                }
            }
        }

        private void ui_btnPathStoreFilePublish_Click(object sender, EventArgs e)
        {
            using (var d = new FolderBrowserDialog())
            {
                DialogResult result = d.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(d.SelectedPath))
                {
                    ui_txtPathStoreFilePublish.Text = d.SelectedPath;
                }
            }
        }

        private void ui_selectOcrLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_app.Setting.OcrLanguage = ui_selectOcrLanguage.SelectedIndex;
        }

        private void ui_selectOcrLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_app.Setting.OcrLevel = ui_selectOcrLevel.SelectedIndex;
        }

        private void ui_selectOcrEngineMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_app.Setting.OcrEngine = ui_selectOcrEngineMode.SelectedIndex;
        }

        private void ui_HideToolbarFooter_CheckStateChanged(object sender, EventArgs e)
        {
            m_app.Setting.HideToolbar = ui_HideToolbarFooter.Checked;
        }

        private void ui_checkOnly10PageFirstlyOrAll_CheckedChanged(object sender, EventArgs e)
        {
            m_app.Setting.Only10PageFirstlyOrAll = ui_checkOnly10PageFirstlyOrAll.Checked;
        }

        private void ui_DrawSelectionImageAndWord_CheckStateChanged(object sender, EventArgs e)
        {
            m_app.Setting.DrawSelectionImageWord = ui_DrawSelectionImageAndWord.Checked;
        }

        private void ui_checkViewModeNoBorder_CheckStateChanged(object sender, EventArgs e)
        {
            m_app.Setting.ViewModeNoBorder = ui_checkViewModeNoBorder.Checked;
        }

        private void ui_checkViewModePublish_CheckStateChanged(object sender, EventArgs e)
        {
            m_app.Setting.ViewModePublish = ui_checkViewModePublish.Checked;
        }

        private void ui_checkViewModeMobile_CheckStateChanged(object sender, EventArgs e)
        {
            m_app.Setting.ViewModeResponsiveMobile = ui_checkViewModeMobile.Checked;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

    }
}
