namespace CutsceneCreatorApp
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutCutsceneCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripFileNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAddCue = new System.Windows.Forms.Button();
            this.btnRemoveCue = new System.Windows.Forms.Button();
            this.cueListBox = new System.Windows.Forms.ListBox();
            this.lblCueType = new System.Windows.Forms.Label();
            this.cmbCueType = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancelChanges = new System.Windows.Forms.Button();
            this.pnlCueData = new System.Windows.Forms.Panel();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(513, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutCutsceneCreatorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // aboutCutsceneCreatorToolStripMenuItem
            // 
            this.aboutCutsceneCreatorToolStripMenuItem.Name = "aboutCutsceneCreatorToolStripMenuItem";
            this.aboutCutsceneCreatorToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutCutsceneCreatorToolStripMenuItem.Text = "About Cutscene Creator";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripFileNameLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 363);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(513, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripFileNameLabel
            // 
            this.statusStripFileNameLabel.Name = "statusStripFileNameLabel";
            this.statusStripFileNameLabel.Size = new System.Drawing.Size(57, 17);
            this.statusStripFileNameLabel.Text = "*New File";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAddCue);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveCue);
            this.splitContainer1.Panel1.Controls.Add(this.cueListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlCueData);
            this.splitContainer1.Panel2.Controls.Add(this.lblCueType);
            this.splitContainer1.Panel2.Controls.Add(this.cmbCueType);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveChanges);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelChanges);
            this.splitContainer1.Size = new System.Drawing.Size(513, 339);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnAddCue
            // 
            this.btnAddCue.Location = new System.Drawing.Point(7, 313);
            this.btnAddCue.Name = "btnAddCue";
            this.btnAddCue.Size = new System.Drawing.Size(75, 23);
            this.btnAddCue.TabIndex = 2;
            this.btnAddCue.Text = "Add";
            this.btnAddCue.UseVisualStyleBackColor = true;
            this.btnAddCue.Click += new System.EventHandler(this.btnAddCue_Click);
            // 
            // btnRemoveCue
            // 
            this.btnRemoveCue.Location = new System.Drawing.Point(88, 313);
            this.btnRemoveCue.Name = "btnRemoveCue";
            this.btnRemoveCue.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCue.TabIndex = 1;
            this.btnRemoveCue.Text = "Remove";
            this.btnRemoveCue.UseVisualStyleBackColor = true;
            this.btnRemoveCue.Click += new System.EventHandler(this.btnRemoveCue_Click);
            // 
            // cueListBox
            // 
            this.cueListBox.FormattingEnabled = true;
            this.cueListBox.Location = new System.Drawing.Point(12, 4);
            this.cueListBox.Name = "cueListBox";
            this.cueListBox.Size = new System.Drawing.Size(156, 303);
            this.cueListBox.TabIndex = 0;
            // 
            // lblCueType
            // 
            this.lblCueType.AutoSize = true;
            this.lblCueType.Location = new System.Drawing.Point(7, 6);
            this.lblCueType.Name = "lblCueType";
            this.lblCueType.Size = new System.Drawing.Size(56, 13);
            this.lblCueType.TabIndex = 3;
            this.lblCueType.Text = "Cue Type:";
            // 
            // cmbCueType
            // 
            this.cmbCueType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCueType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCueType.FormattingEnabled = true;
            this.cmbCueType.Items.AddRange(new object[] {
            "DialogCue"});
            this.cmbCueType.Location = new System.Drawing.Point(69, 3);
            this.cmbCueType.Name = "cmbCueType";
            this.cmbCueType.Size = new System.Drawing.Size(257, 21);
            this.cmbCueType.TabIndex = 2;
            this.cmbCueType.SelectedIndexChanged += new System.EventHandler(this.cmbCueType_SelectedIndexChanged);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(170, 312);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancelChanges
            // 
            this.btnCancelChanges.Location = new System.Drawing.Point(251, 313);
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.Size = new System.Drawing.Size(75, 23);
            this.btnCancelChanges.TabIndex = 0;
            this.btnCancelChanges.Text = "Cancel";
            this.btnCancelChanges.UseVisualStyleBackColor = true;
            this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click);
            // 
            // pnlCueData
            // 
            this.pnlCueData.Location = new System.Drawing.Point(10, 30);
            this.pnlCueData.Name = "pnlCueData";
            this.pnlCueData.Size = new System.Drawing.Size(316, 276);
            this.pnlCueData.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 385);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Cutscene Creator";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutCutsceneCreatorToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripFileNameLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox cueListBox;
        private System.Windows.Forms.Label lblCueType;
        private System.Windows.Forms.ComboBox cmbCueType;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancelChanges;
        private System.Windows.Forms.Button btnAddCue;
        private System.Windows.Forms.Button btnRemoveCue;
        private System.Windows.Forms.Panel pnlCueData;
    }
}

