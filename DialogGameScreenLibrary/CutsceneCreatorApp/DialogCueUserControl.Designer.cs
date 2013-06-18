namespace CutsceneCreatorApp
{
    partial class DialogCueUserControl
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFontName = new System.Windows.Forms.TextBox();
            this.txtTextEffectName = new System.Windows.Forms.TextBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.lblDCName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtFontName
            // 
            this.txtFontName.Location = new System.Drawing.Point(72, 31);
            this.txtFontName.Name = "txtFontName";
            this.txtFontName.Size = new System.Drawing.Size(100, 20);
            this.txtFontName.TabIndex = 1;
            // 
            // txtTextEffectName
            // 
            this.txtTextEffectName.Location = new System.Drawing.Point(72, 58);
            this.txtTextEffectName.Name = "txtTextEffectName";
            this.txtTextEffectName.Size = new System.Drawing.Size(100, 20);
            this.txtTextEffectName.TabIndex = 2;
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(72, 85);
            this.txtLine.Multiline = true;
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(238, 137);
            this.txtLine.TabIndex = 3;
            // 
            // lblDCName
            // 
            this.lblDCName.AutoSize = true;
            this.lblDCName.Location = new System.Drawing.Point(4, 7);
            this.lblDCName.Name = "lblDCName";
            this.lblDCName.Size = new System.Drawing.Size(38, 13);
            this.lblDCName.TabIndex = 4;
            this.lblDCName.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Font Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text Effect:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Line:";
            // 
            // DialogCueUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDCName);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.txtTextEffectName);
            this.Controls.Add(this.txtFontName);
            this.Controls.Add(this.txtName);
            this.Name = "DialogCueUserControl";
            this.Size = new System.Drawing.Size(322, 234);
            this.Load += new System.EventHandler(this.DialogCueUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFontName;
        private System.Windows.Forms.TextBox txtTextEffectName;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label lblDCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
