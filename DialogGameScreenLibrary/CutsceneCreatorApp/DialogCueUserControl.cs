using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CutsceneCreatorApp
{
    public partial class DialogCueUserControl : UserControl, ICueUserControl
    {
        public DialogCueUserControl()
        {
            InitializeComponent();
        }

        private void DialogCueUserControl_Load(object sender, EventArgs e)
        {
            
        }

        public void InitializeCueData(List<string> data)
        {
            txtName.Text = data[0];
            txtLine.Text = data[1];
            if (data.Count > 2) txtFontName.Text = data[2];
            if (data.Count > 3) txtTextEffectName.Text = data[3];
        }

        public bool ValidateCueData()
        {
            return !(String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtLine.Text));
        }

        public List<string> GetCueData()
        {
            List<string> output = new List<string>();

            output.Add(txtName.Text);
            output.Add(txtLine.Text);

            if (!String.IsNullOrWhiteSpace(txtFontName.Text))
                output.Add(txtFontName.Text);
            else
                output.Add("default");

            if (!String.IsNullOrWhiteSpace(txtTextEffectName.Text))
                output.Add(txtTextEffectName.Text);
            else
                output.Add("default");

            return output;
        }

        public string InvalidDataMessage()
        {
            return "You must have a name and a line to save a dialog cue.";
        }
    }
}
