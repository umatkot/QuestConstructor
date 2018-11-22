namespace QuestConstructorNS
{
    partial class QuestPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.pnAlternatives = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbQuestType = new System.Windows.Forms.ComboBox();
            this.lbCondition = new System.Windows.Forms.LinkLabel();
            this.btAddAlt = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbId.Location = new System.Drawing.Point(36, 2);
            this.tbId.Margin = new System.Windows.Forms.Padding(2);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(49, 19);
            this.tbId.TabIndex = 1;
            this.tbId.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(36, 25);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tbTitle.MaximumSize = new System.Drawing.Size(530, 4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(530, 20);
            this.tbTitle.TabIndex = 4;
            this.tbTitle.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // pnAlternatives
            // 
            this.pnAlternatives.AutoSize = true;
            this.pnAlternatives.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnAlternatives.Location = new System.Drawing.Point(36, 75);
            this.pnAlternatives.Margin = new System.Windows.Forms.Padding(2);
            this.pnAlternatives.MaximumSize = new System.Drawing.Size(530, 0);
            this.pnAlternatives.Name = "pnAlternatives";
            this.pnAlternatives.Size = new System.Drawing.Size(530, 0);
            this.pnAlternatives.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Альтернативы";
            // 
            // cbQuestType
            // 
            this.cbQuestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestType.FormattingEnabled = true;
            this.cbQuestType.Location = new System.Drawing.Point(428, 49);
            this.cbQuestType.Margin = new System.Windows.Forms.Padding(2);
            this.cbQuestType.Name = "cbQuestType";
            this.cbQuestType.Size = new System.Drawing.Size(138, 21);
            this.cbQuestType.TabIndex = 11;
            this.cbQuestType.SelectionChangeCommitted += new System.EventHandler(this.cbQuestType_SelectionChangeCommitted);
            // 
            // lbCondition
            // 
            this.lbCondition.AutoSize = true;
            this.lbCondition.Location = new System.Drawing.Point(88, 5);
            this.lbCondition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCondition.MaximumSize = new System.Drawing.Size(225, 14);
            this.lbCondition.Name = "lbCondition";
            this.lbCondition.Size = new System.Drawing.Size(41, 13);
            this.lbCondition.TabIndex = 13;
            this.lbCondition.TabStop = true;
            this.lbCondition.Text = "Если...";
            this.lbCondition.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbCondition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCondition_LinkClicked);
            // 
            // btAddAlt
            // 
            this.btAddAlt.FlatAppearance.BorderSize = 0;
            this.btAddAlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddAlt.Image = global::QuestConstructorNS.Properties.Resources.list_add;
            this.btAddAlt.Location = new System.Drawing.Point(36, 49);
            this.btAddAlt.Margin = new System.Windows.Forms.Padding(2);
            this.btAddAlt.Name = "btAddAlt";
            this.btAddAlt.Size = new System.Drawing.Size(19, 20);
            this.btAddAlt.TabIndex = 10;
            this.btAddAlt.UseVisualStyleBackColor = true;
            this.btAddAlt.Click += new System.EventHandler(this.btAddAlt_Click);
            // 
            // btUp
            // 
            this.btUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUp.FlatAppearance.BorderSize = 0;
            this.btUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUp.Image = global::QuestConstructorNS.Properties.Resources.icons8_sort_up_16;
            this.btUp.Location = new System.Drawing.Point(516, 3);
            this.btUp.Margin = new System.Windows.Forms.Padding(2);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(15, 16);
            this.btUp.TabIndex = 9;
            this.btUp.UseVisualStyleBackColor = false;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.FlatAppearance.BorderSize = 0;
            this.btDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDown.Image = global::QuestConstructorNS.Properties.Resources.icons8_sort_down_16;
            this.btDown.Location = new System.Drawing.Point(536, 3);
            this.btDown.Margin = new System.Windows.Forms.Padding(2);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(15, 16);
            this.btDown.TabIndex = 8;
            this.btDown.UseVisualStyleBackColor = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.FlatAppearance.BorderSize = 0;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Image = global::QuestConstructorNS.Properties.Resources.icons8_delete_24;
            this.btDelete.Location = new System.Drawing.Point(554, 2);
            this.btDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(18, 18);
            this.btDelete.TabIndex = 7;
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuestConstructorNS.Properties.Resources.gnome_dialog_question;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // QuestPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbCondition);
            this.Controls.Add(this.cbQuestType);
            this.Controls.Add(this.btAddAlt);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnAlternatives);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbId);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuestPanel";
            this.Size = new System.Drawing.Size(578, 77);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.FlowLayoutPanel pnAlternatives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btAddAlt;
        private System.Windows.Forms.ComboBox cbQuestType;
        private System.Windows.Forms.LinkLabel lbCondition;
    }
}
