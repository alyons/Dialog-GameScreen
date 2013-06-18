using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace CutsceneScreenLibrary
{
    public class Cue
    {
        private string cueType;
        private List<string> cueData;

        public string CueType
        {
            get { return cueType; }
            set { cueType = value; }
        }
        public List<string> CueData
        {
            get { return cueData; }
            set { cueData = value; }
        }

        public Cue()
        {
            cueData = new List<string>();
        }
        public Cue(string c)
            : this()
        {
            CueType = c;
        }
        public Cue(string c, List<string> d)
            : this(c)
        {
            cueData.AddRange(d);
        }
    }
}
