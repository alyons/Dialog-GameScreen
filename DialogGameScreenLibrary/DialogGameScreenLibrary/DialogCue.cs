using System;
using System.Collections.Generic;

namespace CutsceneScreenLibrary
{
    public class DialogCue : Cue
    {
        #region Variables
        private string name;
        private string line;
        private string fontName;
        private string textEffectName;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public string Line
        {
            get { return line; }
            set { line = value; }
        }
        public string FontName
        {
            get { return fontName; }
            private set { fontName = value; }
        }
        public string TextEffectName
        {
            get { return textEffectName; }
            private set { textEffectName = value; }
        }
        #endregion

        #region Constructors
        public DialogCue(string c, List<string> d)
            : base (c, d)
        {
            if (CueData.Count > 0)
                Name = Convert.ToString(CueData[0]);
            else
                Name = "default";

            if (CueData.Count > 1)
                Line = Convert.ToString(CueData[1]);
            else
                Line = "default";

            if (CueData.Count > 2)
                FontName = Convert.ToString(CueData[2]);
            else
                FontName = "default";

            if (CueData.Count > 3)
                TextEffectName = Convert.ToString(CueData[3]);
            else
                TextEffectName = "default";
        }
        public DialogCue(Cue cue)
            : this (cue.CueType, cue.CueData)
        {
        }
        #endregion

        #region Methods
        #endregion
    }
}
