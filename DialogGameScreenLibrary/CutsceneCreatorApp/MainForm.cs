using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using CutsceneScreenLibrary;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace CutsceneCreatorApp
{
    public partial class MainForm : Form
    {
        string activeFilePath = "";
        List<Cue> cues;
        bool fileHasChanged = false;
        UserControl panelControl = null;

        public MainForm()
        {
            InitializeComponent();
            statusStripFileNameLabel.Text = "New File";
            cues = new List<Cue>();
            
            cueListBox.DataSource = cues;
            cueListBox.DisplayMember = "CueType";
            cueListBox.SelectedIndexChanged += new EventHandler(cueListBox_SelectedIndexChanged);
        }

        bool LoadFile()
        {
            try
            {
                XDocument doc = XDocument.Load(activeFilePath);

                if (!doc.Root.Elements("Asset").Attributes().Any(a => a.ToString().Contains("CutsceneScreenLibrary.Cue"))) throw new Exception("Must load a cutscene xml file.");

                //MessageBox.Show(doc.Root.FirstAttribute.Name.ToString());

                foreach (XElement element in doc.Root.Elements("Asset").Elements("Item"))
                {
                    Cue cue = new Cue();
                    cue.CueType = element.Element("CueType").Value;
                    foreach (XElement data in element.Element("CueData").Elements("Item")) cue.CueData.Add(data.Value);
                    cues.Add(cue);
                }

                cueListBox.SelectedIndex = -1;
                cmbCueType.SelectedIndex = -1;
                RefreshCueList();

                fileHasChanged = false;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to load file...\n" + e.ToString());
            }

            return false;
        }
        bool SaveFile()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(activeFilePath) || !File.Exists(activeFilePath))
                {
                    throw new Exception("File path not specified.");
                }

                XDocument doc = new XDocument(new XElement("XnaContent",
                    new XAttribute(XNamespace.Xmlns + "Generic", "System.Collections.Generic"),
                    new XElement("Asset", new XAttribute("Type", "Generic:List[CutsceneScreenLibrary.Cue]"))));

                foreach (Cue cue in cues)
                {
                    XElement element = new XElement("Item");
                    element.Add(new XElement("CueType", cue.CueType));
                    element.Add(new XElement("CueData"));
                    foreach (object data in cue.CueData)
                    {
                        element.Element("CueData").Add(new XElement("Item", new XAttribute("Type", "System.String"), data.ToString()));
                    }
                    doc.Root.Element("Asset").Add(element);
                }

                doc.Save(activeFilePath);

                fileHasChanged = false;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to save file...\n" + e.ToString());
            }

            return false;
        }
        void RefreshCueList()
        {
            cueListBox.Refresh();
            cueListBox.DisplayMember = "";
            cueListBox.DisplayMember = "CueType";
        }
        void UpdateCuePanel()
        {
            if (panelControl != null)
            {
                pnlCueData.Controls.Remove(panelControl);
                panelControl = null;
            }

            if (cmbCueType.SelectedIndex > -1)
            {
                switch (cmbCueType.SelectedItem.ToString())
                {
                    case "DialogCue":
                        panelControl = new DialogCueUserControl() { Dock = DockStyle.Fill };
                        if (cues.Count > 0 && cueListBox.SelectedIndex > -1) (panelControl as DialogCueUserControl).InitializeCueData(cues[cueListBox.SelectedIndex].CueData);
                        pnlCueData.Controls.Add(panelControl);
                        break;
                } 
            }
        }

        void cueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cueListBox.SelectedIndex > -1)
            {
                if (cmbCueType.Items.Contains((cueListBox.SelectedItem as Cue).CueType))
                {
                    cmbCueType.SelectedItem = (cueListBox.SelectedItem as Cue).CueType;
                    UpdateCuePanel();
                }
            }   
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileHasChanged)
            {
                DialogResult result0 = MessageBox.Show("Would you like to save your changes?",
                                                        "Save before Open",
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxIcon.Question);

                if (result0 == DialogResult.Cancel)
                    return;
                else if (result0 == DialogResult.Yes)
                    if (!SaveFile())
                        return;
            }

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files|*.xml";
            fileDialog.Multiselect = false;
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Do things here to load the file
                activeFilePath = fileDialog.FileName;

                if (!LoadFile())
                {
                    activeFilePath = "";
                }

                this.statusStripFileNameLabel.Text = "New File";
            }
        }

        private void btnAddCue_Click(object sender, EventArgs e)
        {
            cues.Add(new Cue("DialogCue", new List<string>() { "default", "default", "default", "default" }));
            RefreshCueList();
            if (cues.Count > 0) cueListBox.SelectedIndex = cues.Count - 1;
            UpdateCuePanel();
            fileHasChanged = true;
        }

        private void btnRemoveCue_Click(object sender, EventArgs e)
        {
            if (cueListBox.SelectedIndex > -1)
            {
                cues.RemoveAt(cueListBox.SelectedIndex);
                cmbCueType.SelectedIndex = -1;
                fileHasChanged = true;
            }

            RefreshCueList();
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            if (cueListBox.SelectedIndex > -1)
            {
                if (cmbCueType.Items.Contains((cueListBox.SelectedItem as Cue).CueType))
                {
                    cmbCueType.SelectedItem = (cueListBox.SelectedItem as Cue).CueType;
                    UpdateCuePanel();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(activeFilePath))
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "XML files|*.xml";
                DialogResult result = fileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    activeFilePath = fileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            this.statusStripFileNameLabel.Text = Path.GetFileName(activeFilePath);
            SaveFile();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (panelControl is ICueUserControl)
            {
                if ((panelControl as ICueUserControl).ValidateCueData())
                {
                    cues[cueListBox.SelectedIndex].CueType = cmbCueType.SelectedItem.ToString();
                    cues[cueListBox.SelectedIndex].CueData.Clear();
                    cues[cueListBox.SelectedIndex].CueData.AddRange((panelControl as ICueUserControl).GetCueData());
                }
                else
                {
                    MessageBox.Show((panelControl as ICueUserControl).InvalidDataMessage(), "Warning: Save Cue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileHasChanged)
            {
                DialogResult result = MessageBox.Show("Would you like to save your changes?",
                                                        "Save before New File",
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                    if (!SaveFile())
                        return;
            }

            cues.Clear();
            cueListBox.SelectedIndex = -1;
            pnlCueData.Controls.Clear();
            cmbCueType.Text = "";
            cmbCueType.SelectedIndex = -1;
            fileHasChanged = false;
            RefreshCueList();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileHasChanged)
            {
                DialogResult result = MessageBox.Show("Would you like to save your changes?",
                                                        "Save before Close",
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                    if (!SaveFile())
                        return;
            }

            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files|*.xml";
            if (!String.IsNullOrWhiteSpace(activeFilePath) && File.Exists(activeFilePath))
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(activeFilePath);
                fileDialog.FileName = Path.GetFileName(activeFilePath);
            }
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                activeFilePath = fileDialog.FileName;
            }
            else
            {
                return;
            }

            this.statusStripFileNameLabel.Text = Path.GetFileName(activeFilePath);
            SaveFile();
        }

        private void cmbCueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCuePanel();   
        }
    }
}
