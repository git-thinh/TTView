
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_tabOcr = new FarsiLibrary.Win.FATabStripItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_tabProcessImage = new FarsiLibrary.Win.FATabStripItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ui_HideFooter = new System.Windows.Forms.CheckBox();
            this.ui_SelectItems = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_tabs)).BeginInit();
            this.m_tabs.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_tabOcr.SuspendLayout();
            this.m_tabProcessImage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabs
            // 
            this.m_tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabs.Font = new System.Drawing.Font("Arial", 11F);
            this.m_tabs.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.m_tabGeneral});
            this.m_tabs.Location = new System.Drawing.Point(0, 0);
            this.m_tabs.Name = "m_tabs";
            this.m_tabs.SelectedItem = this.m_tabGeneral;
            this.m_tabs.Size = new System.Drawing.Size(800, 450);
            this.m_tabs.TabIndex = 0;
            this.m_tabs.Text = "faTabStrip1";
            // 
            // m_tabGeneral
            // 
            this.m_tabGeneral.CanClose = false;
            this.m_tabGeneral.Controls.Add(this.panel1);
            this.m_tabGeneral.IsDrawn = true;
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.Selected = true;
            this.m_tabGeneral.Size = new System.Drawing.Size(798, 428);
            this.m_tabGeneral.TabIndex = 0;
            this.m_tabGeneral.Title = "General";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ui_SelectItems);
            this.panel1.Controls.Add(this.ui_HideFooter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 428);
            this.panel1.TabIndex = 0;
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
            // ui_HideFooter
            // 
            this.ui_HideFooter.AutoSize = true;
            this.ui_HideFooter.ForeColor = System.Drawing.Color.White;
            this.ui_HideFooter.Location = new System.Drawing.Point(106, 58);
            this.ui_HideFooter.Name = "ui_HideFooter";
            this.ui_HideFooter.Size = new System.Drawing.Size(102, 21);
            this.ui_HideFooter.TabIndex = 0;
            this.ui_HideFooter.Text = "Hide Footer";
            this.ui_HideFooter.UseVisualStyleBackColor = true;
            // 
            // ui_SelectItems
            // 
            this.ui_SelectItems.AutoSize = true;
            this.ui_SelectItems.ForeColor = System.Drawing.Color.White;
            this.ui_SelectItems.Location = new System.Drawing.Point(235, 58);
            this.ui_SelectItems.Name = "ui_SelectItems";
            this.ui_SelectItems.Size = new System.Drawing.Size(108, 21);
            this.ui_SelectItems.TabIndex = 1;
            this.ui_SelectItems.Text = "Select Items";
            this.ui_SelectItems.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Store File";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(594, 24);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(706, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "browser";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(17, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 137);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OCR";
            // 
            // groupBox2
            // 
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(17, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 137);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Image";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(706, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(625, 394);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(20, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(162, 21);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Only 10 Pages Or All";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSetting";
            this.Text = "fSetting";
            ((System.ComponentModel.ISupportInitialize)(this.m_tabs)).EndInit();
            this.m_tabs.ResumeLayout(false);
            this.m_tabGeneral.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_tabOcr.ResumeLayout(false);
            this.m_tabProcessImage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarsiLibrary.Win.FATabStrip m_tabs;
        private FarsiLibrary.Win.FATabStripItem m_tabGeneral;
        private FarsiLibrary.Win.FATabStripItem m_tabOcr;
        private FarsiLibrary.Win.FATabStripItem m_tabProcessImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ui_HideFooter;
        private System.Windows.Forms.CheckBox ui_SelectItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}