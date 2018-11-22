namespace QuestConstructorNS
{
    partial class AlternativePanel
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
            this.components = new System.ComponentModel.Container();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btUp = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.lbCondition = new System.Windows.Forms.LinkLabel();
            this.btnNewQuestionByVariant = new System.Windows.Forms.Button();
            this.toolTipNewQuestionByVariant = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(5, 2);
            this.tbId.Margin = new System.Windows.Forms.Padding(2);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(32, 20);
            this.tbId.TabIndex = 1;
            this.tbId.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(40, 2);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(282, 20);
            this.tbTitle.TabIndex = 4;
            this.tbTitle.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btUp
            // 
            this.btUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUp.FlatAppearance.BorderSize = 0;
            this.btUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUp.Image = global::QuestConstructorNS.Properties.Resources.up_alt;
            this.btUp.Location = new System.Drawing.Point(468, 2);
            this.btUp.Margin = new System.Windows.Forms.Padding(0);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(15, 20);
            this.btUp.TabIndex = 9;
            this.btUp.UseVisualStyleBackColor = true;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.FlatAppearance.BorderSize = 0;
            this.btDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDown.Image = global::QuestConstructorNS.Properties.Resources.down_alt;
            this.btDown.Location = new System.Drawing.Point(484, 2);
            this.btDown.Margin = new System.Windows.Forms.Padding(0);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(16, 20);
            this.btDown.TabIndex = 8;
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.FlatAppearance.BorderSize = 0;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Image = global::QuestConstructorNS.Properties.Resources.close_square;
            this.btDelete.Location = new System.Drawing.Point(501, 2);
            this.btDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(17, 19);
            this.btDelete.TabIndex = 7;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // lbCondition
            // 
            this.lbCondition.AutoSize = true;
            this.lbCondition.LinkColor = System.Drawing.Color.Yellow;
            this.lbCondition.Location = new System.Drawing.Point(326, 5);
            this.lbCondition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCondition.MaximumSize = new System.Drawing.Size(49, 14);
            this.lbCondition.Name = "lbCondition";
            this.lbCondition.Size = new System.Drawing.Size(41, 13);
            this.lbCondition.TabIndex = 10;
            this.lbCondition.TabStop = true;
            this.lbCondition.Text = "Если...";
            this.lbCondition.VisitedLinkColor = System.Drawing.Color.Olive;
            this.lbCondition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCondition_LinkClicked);
            // 
            // btnNewQuestionByVariant
            // 
            this.btnNewQuestionByVariant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewQuestionByVariant.BackgroundImage = global::QuestConstructorNS.Properties.Resources.done_square;
            this.btnNewQuestionByVariant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewQuestionByVariant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewQuestionByVariant.Location = new System.Drawing.Point(435, 4);
            this.btnNewQuestionByVariant.Name = "btnNewQuestionByVariant";
            this.btnNewQuestionByVariant.Size = new System.Drawing.Size(18, 17);
            this.btnNewQuestionByVariant.TabIndex = 11;
            this.toolTipNewQuestionByVariant.SetToolTip(this.btnNewQuestionByVariant, "Создать новый вопрос из данного варианта");
            this.btnNewQuestionByVariant.UseVisualStyleBackColor = true;
            this.btnNewQuestionByVariant.Click += new System.EventHandler(this.btnNewQuestionByVariant_Click);
            // 
            // toolTipNewQuestionByVariant
            // 
            this.toolTipNewQuestionByVariant.ToolTipTitle = "Создать новый вопрос на основе данного варианта";
            // 
            // AlternativePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.btnNewQuestionByVariant);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbCondition);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlternativePanel";
            this.Size = new System.Drawing.Size(528, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.LinkLabel lbCondition;
        private System.Windows.Forms.Button btnNewQuestionByVariant;
        private System.Windows.Forms.ToolTip toolTipNewQuestionByVariant;
    }
}
