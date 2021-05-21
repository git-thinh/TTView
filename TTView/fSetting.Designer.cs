
namespace TTView
{
    partial class fSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_tabs = new FarsiLibrary.Win.FATabStrip();
            this.m_tabGeneral = new FarsiLibrary.Win.FATabStripItem();
            this.ui_panelGeneral = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.ui_txtPathStoreFilePublish = new System.Windows.Forms.TextBox();
            this.ui_txtPathStoreFileRaw = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ui_textRedisDB = new System.Windows.Forms.TextBox();
            this.ui_textRedisPort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ui_textRedisIP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ui_checkViewModePublish = new System.Windows.Forms.CheckBox();
            this.ui_checkViewModeMobile = new System.Windows.Forms.CheckBox();
            this.ui_btnPathStoreFilePublish = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ui_groupProcessImage = new System.Windows.Forms.GroupBox();
            this.ui_textMinWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ui_textQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ui_textDpiY = new System.Windows.Forms.TextBox();
            this.ui_textDpiX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ui_groupOCR = new System.Windows.Forms.GroupBox();
            this.ui_checkViewModeNoBorder = new System.Windows.Forms.CheckBox();
            this.ui_selectOcrLevel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ui_selectOcrEngineMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ui_selectOcrLanguage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ui_checkOnly10PageFirstlyOrAll = new System.Windows.Forms.CheckBox();
            this.ui_HideToolbarFooter = new System.Windows.Forms.CheckBox();
            this.ui_DrawSelectionImageAndWord = new System.Windows.Forms.CheckBox();
            this.ui_btnPathStoreFileRaw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tabOcr = new FarsiLibrary.Win.FATabStripItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_tabProcessImage = new FarsiLibrary.Win.FATabStripItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_tabs)).BeginInit();
            this.m_tabs.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.ui_panelGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ui_groupProcessImage.SuspendLayout();
            this.ui_groupOCR.SuspendLayout();
            this.m_tabOcr.SuspendLayout();
            this.m_tabProcessImage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabs
            // 
            this.m_tabs.AlwaysShowMenuGlyph = false;
            this.m_tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabs.Font = new System.Drawing.Font("Arial", 11F);
            this.m_tabs.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.m_tabGeneral});
            this.m_tabs.Location = new System.Drawing.Point(0, 0);
            this.m_tabs.Name = "m_tabs";
            this.m_tabs.SelectedItem = this.m_tabGeneral;
            this.m_tabs.Size = new System.Drawing.Size(581, 335);
            this.m_tabs.TabIndex = 0;
            this.m_tabs.Text = "faTabStrip1";
            // 
            // m_tabGeneral
            // 
            this.m_tabGeneral.CanClose = false;
            this.m_tabGeneral.Controls.Add(this.ui_panelGeneral);
            this.m_tabGeneral.IsDrawn = true;
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.Selected = true;
            this.m_tabGeneral.Size = new System.Drawing.Size(579, 313);
            this.m_tabGeneral.TabIndex = 0;
            this.m_tabGeneral.Title = "SETTING";
            // 
            // ui_panelGeneral
            // 
            this.ui_panelGeneral.BackColor = System.Drawing.Color.Black;
            this.ui_panelGeneral.Controls.Add(this.groupBox2);
            this.ui_panelGeneral.Controls.Add(this.btnApply);
            this.ui_panelGeneral.Controls.Add(this.ui_txtPathStoreFilePublish);
            this.ui_panelGeneral.Controls.Add(this.ui_txtPathStoreFileRaw);
            this.ui_panelGeneral.Controls.Add(this.groupBox1);
            this.ui_panelGeneral.Controls.Add(this.ui_btnPathStoreFilePublish);
            this.ui_panelGeneral.Controls.Add(this.label2);
            this.ui_panelGeneral.Controls.Add(this.btnSave);
            this.ui_panelGeneral.Controls.Add(this.ui_groupProcessImage);
            this.ui_panelGeneral.Controls.Add(this.ui_groupOCR);
            this.ui_panelGeneral.Controls.Add(this.ui_btnPathStoreFileRaw);
            this.ui_panelGeneral.Controls.Add(this.label1);
            this.ui_panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.ui_panelGeneral.Name = "ui_panelGeneral";
            this.ui_panelGeneral.Size = new System.Drawing.Size(579, 313);
            this.ui_panelGeneral.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Arial", 8F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(11, 282);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(60, 23);
            this.btnApply.TabIndex = 17;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ui_txtPathStoreFilePublish
            // 
            this.ui_txtPathStoreFilePublish.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_txtPathStoreFilePublish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_txtPathStoreFilePublish.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_txtPathStoreFilePublish.Location = new System.Drawing.Point(130, 34);
            this.ui_txtPathStoreFilePublish.Name = "ui_txtPathStoreFilePublish";
            this.ui_txtPathStoreFilePublish.Size = new System.Drawing.Size(412, 20);
            this.ui_txtPathStoreFilePublish.TabIndex = 10;
            // 
            // ui_txtPathStoreFileRaw
            // 
            this.ui_txtPathStoreFileRaw.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_txtPathStoreFileRaw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_txtPathStoreFileRaw.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_txtPathStoreFileRaw.Location = new System.Drawing.Point(130, 12);
            this.ui_txtPathStoreFileRaw.Name = "ui_txtPathStoreFileRaw";
            this.ui_txtPathStoreFileRaw.Size = new System.Drawing.Size(412, 20);
            this.ui_txtPathStoreFileRaw.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.ui_textRedisDB);
            this.groupBox1.Controls.Add(this.ui_textRedisPort);
            this.groupBox1.Controls.Add(this.ui_textRedisIP);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ui_checkViewModePublish);
            this.groupBox1.Controls.Add(this.ui_checkViewModeMobile);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(178, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 74);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Publish";
            // 
            // ui_textRedisDB
            // 
            this.ui_textRedisDB.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textRedisDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textRedisDB.Font = new System.Drawing.Font("Arial", 11F);
            this.ui_textRedisDB.Location = new System.Drawing.Point(160, 42);
            this.ui_textRedisDB.Name = "ui_textRedisDB";
            this.ui_textRedisDB.Size = new System.Drawing.Size(53, 24);
            this.ui_textRedisDB.TabIndex = 27;
            this.ui_textRedisDB.Text = "0";
            this.ui_textRedisDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ui_textRedisPort
            // 
            this.ui_textRedisPort.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textRedisPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textRedisPort.Font = new System.Drawing.Font("Arial", 11F);
            this.ui_textRedisPort.Location = new System.Drawing.Point(56, 42);
            this.ui_textRedisPort.Name = "ui_textRedisPort";
            this.ui_textRedisPort.Size = new System.Drawing.Size(78, 24);
            this.ui_textRedisPort.TabIndex = 26;
            this.ui_textRedisPort.Text = "1000";
            this.ui_textRedisPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(134, 44);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label12.Size = new System.Drawing.Size(32, 22);
            this.label12.TabIndex = 25;
            this.label12.Text = "Db";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 9F);
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(26, 41);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label11.Size = new System.Drawing.Size(36, 22);
            this.label11.TabIndex = 24;
            this.label11.Text = "Port";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_textRedisIP
            // 
            this.ui_textRedisIP.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textRedisIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textRedisIP.Font = new System.Drawing.Font("Arial", 11F);
            this.ui_textRedisIP.Location = new System.Drawing.Point(56, 17);
            this.ui_textRedisIP.Name = "ui_textRedisIP";
            this.ui_textRedisIP.Size = new System.Drawing.Size(157, 24);
            this.ui_textRedisIP.TabIndex = 19;
            this.ui_textRedisIP.Text = "127.0.0.1";
            this.ui_textRedisIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(0, 19);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label10.Size = new System.Drawing.Size(63, 22);
            this.label10.TabIndex = 23;
            this.label10.Text = "Redis IP";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_checkViewModePublish
            // 
            this.ui_checkViewModePublish.AutoSize = true;
            this.ui_checkViewModePublish.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_checkViewModePublish.ForeColor = System.Drawing.Color.White;
            this.ui_checkViewModePublish.Location = new System.Drawing.Point(220, 14);
            this.ui_checkViewModePublish.Name = "ui_checkViewModePublish";
            this.ui_checkViewModePublish.Size = new System.Drawing.Size(118, 18);
            this.ui_checkViewModePublish.TabIndex = 22;
            this.ui_checkViewModePublish.Text = "View mode publish";
            this.ui_checkViewModePublish.UseVisualStyleBackColor = true;
            this.ui_checkViewModePublish.CheckStateChanged += new System.EventHandler(this.ui_checkViewModePublish_CheckStateChanged);
            // 
            // ui_checkViewModeMobile
            // 
            this.ui_checkViewModeMobile.AutoSize = true;
            this.ui_checkViewModeMobile.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_checkViewModeMobile.ForeColor = System.Drawing.Color.White;
            this.ui_checkViewModeMobile.Location = new System.Drawing.Point(220, 33);
            this.ui_checkViewModeMobile.Name = "ui_checkViewModeMobile";
            this.ui_checkViewModeMobile.Size = new System.Drawing.Size(171, 18);
            this.ui_checkViewModeMobile.TabIndex = 21;
            this.ui_checkViewModeMobile.Text = "View mode responsive mobile";
            this.ui_checkViewModeMobile.UseVisualStyleBackColor = true;
            this.ui_checkViewModeMobile.CheckStateChanged += new System.EventHandler(this.ui_checkViewModeMobile_CheckStateChanged);
            // 
            // ui_btnPathStoreFilePublish
            // 
            this.ui_btnPathStoreFilePublish.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_btnPathStoreFilePublish.Location = new System.Drawing.Point(542, 34);
            this.ui_btnPathStoreFilePublish.Name = "ui_btnPathStoreFilePublish";
            this.ui_btnPathStoreFilePublish.Size = new System.Drawing.Size(27, 20);
            this.ui_btnPathStoreFilePublish.TabIndex = 11;
            this.ui_btnPathStoreFilePublish.Text = "...";
            this.ui_btnPathStoreFilePublish.UseVisualStyleBackColor = true;
            this.ui_btnPathStoreFilePublish.Click += new System.EventHandler(this.ui_btnPathStoreFilePublish_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Path Store File Publish";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 8F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(76, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ui_groupProcessImage
            // 
            this.ui_groupProcessImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_groupProcessImage.Controls.Add(this.ui_textMinWidth);
            this.ui_groupProcessImage.Controls.Add(this.label9);
            this.ui_groupProcessImage.Controls.Add(this.ui_textQuantity);
            this.ui_groupProcessImage.Controls.Add(this.label8);
            this.ui_groupProcessImage.Controls.Add(this.ui_textDpiY);
            this.ui_groupProcessImage.Controls.Add(this.ui_textDpiX);
            this.ui_groupProcessImage.Controls.Add(this.label3);
            this.ui_groupProcessImage.Controls.Add(this.label4);
            this.ui_groupProcessImage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ui_groupProcessImage.Location = new System.Drawing.Point(10, 151);
            this.ui_groupProcessImage.Name = "ui_groupProcessImage";
            this.ui_groupProcessImage.Size = new System.Drawing.Size(163, 125);
            this.ui_groupProcessImage.TabIndex = 6;
            this.ui_groupProcessImage.TabStop = false;
            this.ui_groupProcessImage.Text = "Compress";
            // 
            // ui_textMinWidth
            // 
            this.ui_textMinWidth.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textMinWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textMinWidth.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.ui_textMinWidth.ForeColor = System.Drawing.Color.Black;
            this.ui_textMinWidth.Location = new System.Drawing.Point(73, 94);
            this.ui_textMinWidth.Name = "ui_textMinWidth";
            this.ui_textMinWidth.Size = new System.Drawing.Size(68, 21);
            this.ui_textMinWidth.TabIndex = 17;
            this.ui_textMinWidth.Text = "1024";
            this.ui_textMinWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(0, 93);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label9.Size = new System.Drawing.Size(77, 22);
            this.label9.TabIndex = 16;
            this.label9.Text = "Min Width";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_textQuantity
            // 
            this.ui_textQuantity.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textQuantity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.ui_textQuantity.ForeColor = System.Drawing.Color.Black;
            this.ui_textQuantity.Location = new System.Drawing.Point(73, 70);
            this.ui_textQuantity.Name = "ui_textQuantity";
            this.ui_textQuantity.Size = new System.Drawing.Size(68, 21);
            this.ui_textQuantity.TabIndex = 15;
            this.ui_textQuantity.Text = "50";
            this.ui_textQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(10, 69);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label8.Size = new System.Drawing.Size(67, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "Quantity";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_textDpiY
            // 
            this.ui_textDpiY.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textDpiY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textDpiY.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.ui_textDpiY.ForeColor = System.Drawing.Color.Black;
            this.ui_textDpiY.Location = new System.Drawing.Point(73, 46);
            this.ui_textDpiY.Name = "ui_textDpiY";
            this.ui_textDpiY.Size = new System.Drawing.Size(68, 21);
            this.ui_textDpiY.TabIndex = 13;
            this.ui_textDpiY.Text = "90";
            this.ui_textDpiY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ui_textDpiX
            // 
            this.ui_textDpiX.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_textDpiX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_textDpiX.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.ui_textDpiX.ForeColor = System.Drawing.Color.Black;
            this.ui_textDpiX.Location = new System.Drawing.Point(73, 22);
            this.ui_textDpiX.Name = "ui_textDpiX";
            this.ui_textDpiX.Size = new System.Drawing.Size(68, 21);
            this.ui_textDpiX.TabIndex = 12;
            this.ui_textDpiX.Text = "90";
            this.ui_textDpiX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(29, 20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label3.Size = new System.Drawing.Size(47, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dpi X";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(30, 45);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label4.Size = new System.Drawing.Size(47, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dpi Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_groupOCR
            // 
            this.ui_groupOCR.Controls.Add(this.ui_checkViewModeNoBorder);
            this.ui_groupOCR.Controls.Add(this.ui_selectOcrLevel);
            this.ui_groupOCR.Controls.Add(this.label7);
            this.ui_groupOCR.Controls.Add(this.ui_selectOcrEngineMode);
            this.ui_groupOCR.Controls.Add(this.label6);
            this.ui_groupOCR.Controls.Add(this.ui_selectOcrLanguage);
            this.ui_groupOCR.Controls.Add(this.label5);
            this.ui_groupOCR.Controls.Add(this.ui_checkOnly10PageFirstlyOrAll);
            this.ui_groupOCR.Controls.Add(this.ui_HideToolbarFooter);
            this.ui_groupOCR.Controls.Add(this.ui_DrawSelectionImageAndWord);
            this.ui_groupOCR.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ui_groupOCR.Location = new System.Drawing.Point(10, 60);
            this.ui_groupOCR.Name = "ui_groupOCR";
            this.ui_groupOCR.Size = new System.Drawing.Size(560, 90);
            this.ui_groupOCR.TabIndex = 5;
            this.ui_groupOCR.TabStop = false;
            this.ui_groupOCR.Text = "Genneral";
            // 
            // ui_checkViewModeNoBorder
            // 
            this.ui_checkViewModeNoBorder.AutoSize = true;
            this.ui_checkViewModeNoBorder.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_checkViewModeNoBorder.ForeColor = System.Drawing.Color.White;
            this.ui_checkViewModeNoBorder.Location = new System.Drawing.Point(388, 67);
            this.ui_checkViewModeNoBorder.Name = "ui_checkViewModeNoBorder";
            this.ui_checkViewModeNoBorder.Size = new System.Drawing.Size(131, 18);
            this.ui_checkViewModeNoBorder.TabIndex = 20;
            this.ui_checkViewModeNoBorder.Text = "View mode no border";
            this.ui_checkViewModeNoBorder.UseVisualStyleBackColor = true;
            this.ui_checkViewModeNoBorder.CheckStateChanged += new System.EventHandler(this.ui_checkViewModeNoBorder_CheckStateChanged);
            // 
            // ui_selectOcrLevel
            // 
            this.ui_selectOcrLevel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_selectOcrLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_selectOcrLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ui_selectOcrLevel.Font = new System.Drawing.Font("Arial", 9F);
            this.ui_selectOcrLevel.FormattingEnabled = true;
            this.ui_selectOcrLevel.Items.AddRange(new object[] {
            "Block",
            "Para",
            "TextLine",
            "Word",
            "Symbol"});
            this.ui_selectOcrLevel.Location = new System.Drawing.Point(264, 20);
            this.ui_selectOcrLevel.Name = "ui_selectOcrLevel";
            this.ui_selectOcrLevel.Size = new System.Drawing.Size(117, 23);
            this.ui_selectOcrLevel.TabIndex = 19;
            this.ui_selectOcrLevel.SelectedIndexChanged += new System.EventHandler(this.ui_selectOcrLevel_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(224, 20);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label7.Size = new System.Drawing.Size(42, 22);
            this.label7.TabIndex = 18;
            this.label7.Text = "Level";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_selectOcrEngineMode
            // 
            this.ui_selectOcrEngineMode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_selectOcrEngineMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_selectOcrEngineMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ui_selectOcrEngineMode.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_selectOcrEngineMode.FormattingEnabled = true;
            this.ui_selectOcrEngineMode.Items.AddRange(new object[] {
            "Only the legacy tesseract OCR engine is used",
            "Only the new LSTM-based OCR engine is used",
            "Both the legacy and new LSTM based OCR engine is used",
            "Default OCR engine is used(currently LSTM-ased OCR engine)"});
            this.ui_selectOcrEngineMode.Location = new System.Drawing.Point(73, 51);
            this.ui_selectOcrEngineMode.Name = "ui_selectOcrEngineMode";
            this.ui_selectOcrEngineMode.Size = new System.Drawing.Size(308, 22);
            this.ui_selectOcrEngineMode.TabIndex = 17;
            this.ui_selectOcrEngineMode.SelectedIndexChanged += new System.EventHandler(this.ui_selectOcrEngineMode_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(21, 50);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label6.Size = new System.Drawing.Size(54, 22);
            this.label6.TabIndex = 16;
            this.label6.Text = "Engine";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_selectOcrLanguage
            // 
            this.ui_selectOcrLanguage.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ui_selectOcrLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_selectOcrLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ui_selectOcrLanguage.Font = new System.Drawing.Font("Arial", 9F);
            this.ui_selectOcrLanguage.FormattingEnabled = true;
            this.ui_selectOcrLanguage.Items.AddRange(new object[] {
            "English",
            "Vietnamese"});
            this.ui_selectOcrLanguage.Location = new System.Drawing.Point(73, 20);
            this.ui_selectOcrLanguage.Name = "ui_selectOcrLanguage";
            this.ui_selectOcrLanguage.Size = new System.Drawing.Size(137, 23);
            this.ui_selectOcrLanguage.TabIndex = 15;
            this.ui_selectOcrLanguage.SelectedIndexChanged += new System.EventHandler(this.ui_selectOcrLanguage_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label5.Size = new System.Drawing.Size(68, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Language";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_checkOnly10PageFirstlyOrAll
            // 
            this.ui_checkOnly10PageFirstlyOrAll.AutoSize = true;
            this.ui_checkOnly10PageFirstlyOrAll.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_checkOnly10PageFirstlyOrAll.ForeColor = System.Drawing.Color.White;
            this.ui_checkOnly10PageFirstlyOrAll.Location = new System.Drawing.Point(388, 32);
            this.ui_checkOnly10PageFirstlyOrAll.Name = "ui_checkOnly10PageFirstlyOrAll";
            this.ui_checkOnly10PageFirstlyOrAll.Size = new System.Drawing.Size(152, 18);
            this.ui_checkOnly10PageFirstlyOrAll.TabIndex = 9;
            this.ui_checkOnly10PageFirstlyOrAll.Text = "Only 10 pages firstly or all";
            this.ui_checkOnly10PageFirstlyOrAll.UseVisualStyleBackColor = true;
            this.ui_checkOnly10PageFirstlyOrAll.CheckedChanged += new System.EventHandler(this.ui_checkOnly10PageFirstlyOrAll_CheckedChanged);
            // 
            // ui_HideToolbarFooter
            // 
            this.ui_HideToolbarFooter.AutoSize = true;
            this.ui_HideToolbarFooter.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_HideToolbarFooter.ForeColor = System.Drawing.Color.White;
            this.ui_HideToolbarFooter.Location = new System.Drawing.Point(388, 15);
            this.ui_HideToolbarFooter.Name = "ui_HideToolbarFooter";
            this.ui_HideToolbarFooter.Size = new System.Drawing.Size(119, 18);
            this.ui_HideToolbarFooter.TabIndex = 0;
            this.ui_HideToolbarFooter.Text = "Hide Toolbar Footer";
            this.ui_HideToolbarFooter.UseVisualStyleBackColor = true;
            this.ui_HideToolbarFooter.CheckStateChanged += new System.EventHandler(this.ui_HideToolbarFooter_CheckStateChanged);
            // 
            // ui_DrawSelectionImageAndWord
            // 
            this.ui_DrawSelectionImageAndWord.AutoSize = true;
            this.ui_DrawSelectionImageAndWord.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_DrawSelectionImageAndWord.ForeColor = System.Drawing.Color.White;
            this.ui_DrawSelectionImageAndWord.Location = new System.Drawing.Point(388, 49);
            this.ui_DrawSelectionImageAndWord.Name = "ui_DrawSelectionImageAndWord";
            this.ui_DrawSelectionImageAndWord.Size = new System.Drawing.Size(165, 18);
            this.ui_DrawSelectionImageAndWord.TabIndex = 1;
            this.ui_DrawSelectionImageAndWord.Text = "Draw selections image word";
            this.ui_DrawSelectionImageAndWord.UseVisualStyleBackColor = true;
            this.ui_DrawSelectionImageAndWord.CheckStateChanged += new System.EventHandler(this.ui_DrawSelectionImageAndWord_CheckStateChanged);
            // 
            // ui_btnPathStoreFileRaw
            // 
            this.ui_btnPathStoreFileRaw.Font = new System.Drawing.Font("Arial", 8F);
            this.ui_btnPathStoreFileRaw.Location = new System.Drawing.Point(542, 12);
            this.ui_btnPathStoreFileRaw.Name = "ui_btnPathStoreFileRaw";
            this.ui_btnPathStoreFileRaw.Size = new System.Drawing.Size(27, 20);
            this.ui_btnPathStoreFileRaw.TabIndex = 4;
            this.ui_btnPathStoreFileRaw.Text = "...";
            this.ui_btnPathStoreFileRaw.UseVisualStyleBackColor = true;
            this.ui_btnPathStoreFileRaw.Click += new System.EventHandler(this.ui_btnPathStoreFileRaw_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 8F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Store File Raw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_tabOcr
            // 
            this.m_tabOcr.CanClose = false;
            this.m_tabOcr.Controls.Add(this.panel2);
            this.m_tabOcr.IsDrawn = true;
            this.m_tabOcr.Name = "m_tabOcr";
            this.m_tabOcr.Size = new System.Drawing.Size(798, 428);
            this.m_tabOcr.TabIndex = 1;
            this.m_tabOcr.Title = "OCR";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 428);
            this.panel2.TabIndex = 1;
            // 
            // m_tabProcessImage
            // 
            this.m_tabProcessImage.CanClose = false;
            this.m_tabProcessImage.Controls.Add(this.panel3);
            this.m_tabProcessImage.IsDrawn = true;
            this.m_tabProcessImage.Name = "m_tabProcessImage";
            this.m_tabProcessImage.Size = new System.Drawing.Size(798, 429);
            this.m_tabProcessImage.TabIndex = 2;
            this.m_tabProcessImage.Title = "Process Image";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 429);
            this.panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(178, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 82);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Process";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 8F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Only the legacy tesseract OCR engine is used",
            "Only the new LSTM-based OCR engine is used",
            "Both the legacy and new LSTM based OCR engine is used",
            "Default OCR engine is used(currently LSTM-ased OCR engine)"});
            this.comboBox1.Location = new System.Drawing.Point(54, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(331, 22);
            this.comboBox1.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox1.Location = new System.Drawing.Point(332, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 24);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox2.Location = new System.Drawing.Point(228, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 24);
            this.textBox2.TabIndex = 30;
            this.textBox2.Text = "1000";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9F);
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(306, 48);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label13.Size = new System.Drawing.Size(32, 22);
            this.label13.TabIndex = 29;
            this.label13.Text = "Db";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(196, 47);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label14.Size = new System.Drawing.Size(36, 22);
            this.label14.TabIndex = 28;
            this.label14.Text = "Port";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 9F);
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(11, 18);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label15.Size = new System.Drawing.Size(48, 22);
            this.label15.TabIndex = 32;
            this.label15.Text = "Name";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(581, 335);
            this.Controls.Add(this.m_tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSetting";
            this.Text = "fSetting";
            this.Load += new System.EventHandler(this.fSetting_Load);
            this.Shown += new System.EventHandler(this.fSetting_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.m_tabs)).EndInit();
            this.m_tabs.ResumeLayout(false);
            this.m_tabGeneral.ResumeLayout(false);
            this.ui_panelGeneral.ResumeLayout(false);
            this.ui_panelGeneral.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ui_groupProcessImage.ResumeLayout(false);
            this.ui_groupProcessImage.PerformLayout();
            this.ui_groupOCR.ResumeLayout(false);
            this.ui_groupOCR.PerformLayout();
            this.m_tabOcr.ResumeLayout(false);
            this.m_tabProcessImage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarsiLibrary.Win.FATabStrip m_tabs;
        private FarsiLibrary.Win.FATabStripItem m_tabGeneral;
        private FarsiLibrary.Win.FATabStripItem m_tabOcr;
        private FarsiLibrary.Win.FATabStripItem m_tabProcessImage;
        private System.Windows.Forms.Panel ui_panelGeneral;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ui_HideToolbarFooter;
        private System.Windows.Forms.CheckBox ui_DrawSelectionImageAndWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ui_txtPathStoreFileRaw;
        private System.Windows.Forms.Button ui_btnPathStoreFileRaw;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox ui_groupProcessImage;
        private System.Windows.Forms.GroupBox ui_groupOCR;
        private System.Windows.Forms.CheckBox ui_checkOnly10PageFirstlyOrAll;
        private System.Windows.Forms.Button ui_btnPathStoreFilePublish;
        private System.Windows.Forms.TextBox ui_txtPathStoreFilePublish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ui_textDpiY;
        private System.Windows.Forms.TextBox ui_textDpiX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ui_selectOcrLanguage;
        private System.Windows.Forms.ComboBox ui_selectOcrEngineMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ui_selectOcrLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ui_textQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ui_textMinWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ui_checkViewModeNoBorder;
        private System.Windows.Forms.CheckBox ui_checkViewModePublish;
        private System.Windows.Forms.CheckBox ui_checkViewModeMobile;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox ui_textRedisIP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ui_textRedisDB;
        private System.Windows.Forms.TextBox ui_textRedisPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}