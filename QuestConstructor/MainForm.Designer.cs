namespace QuestConstructorNS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btOpen = new System.Windows.Forms.ToolStripButton();
            this.btSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btAddQuest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btExportCSV = new System.Windows.Forms.ToolStripButton();
            this.pnMain = new System.Windows.Forms.FlowLayoutPanel();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOpen,
            this.btSave,
            this.toolStripSeparator1,
            this.btAddQuest,
            this.toolStripSeparator2,
            this.btRun,
            this.toolStripSeparator3,
            this.btExportCSV});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(592, 27);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // btOpen
            // 
            this.btOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOpen.Image = ((System.Drawing.Image)(resources.GetObject("btOpen.Image")));
            this.btOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(24, 24);
            this.btOpen.Text = "Открыть Опросник";
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btSave
            // 
            this.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(24, 24);
            this.btSave.Text = "Сохранить Опросник";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(16, 27);
            // 
            // btAddQuest
            // 
            this.btAddQuest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAddQuest.Image = ((System.Drawing.Image)(resources.GetObject("btAddQuest.Image")));
            this.btAddQuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAddQuest.Name = "btAddQuest";
            this.btAddQuest.Size = new System.Drawing.Size(24, 24);
            this.btAddQuest.Text = "Добавить Вопрос";
            this.btAddQuest.Click += new System.EventHandler(this.btAddQuest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(16, 27);
            // 
            // btRun
            // 
            this.btRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btRun.Image = ((System.Drawing.Image)(resources.GetObject("btRun.Image")));
            this.btRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(24, 24);
            this.btRun.Text = "Запуск Опросника";
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(16, 27);
            // 
            // btExportCSV
            // 
            this.btExportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btExportCSV.Image = global::QuestConstructorNS.Properties.Resources.csv_text__1_;
            this.btExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExportCSV.Name = "btExportCSV";
            this.btExportCSV.Size = new System.Drawing.Size(24, 24);
            this.btExportCSV.Text = "Экспорт анкет в CSV";
            this.btExportCSV.Click += new System.EventHandler(this.btExportCSV_Click);
            // 
            // pnMain
            // 
            this.pnMain.AutoScroll = true;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 27);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(3);
            this.pnMain.Size = new System.Drawing.Size(592, 324);
            this.pnMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 351);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.tsMain);
            this.Name = "MainForm";
            this.Text = "Quest Constructor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btOpen;
        private System.Windows.Forms.ToolStripButton btSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btAddQuest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btRun;
        private System.Windows.Forms.FlowLayoutPanel pnMain;
        private System.Windows.Forms.ToolStripButton btExportCSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

