using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace CutsceneScreenLibrary
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content
    /// Pipeline to read the specified data type from binary .xnb format.
    /// 
    /// Unlike the other Content Pipeline support classes, this should
    /// be a part of your main game project, and not the Content Pipeline
    /// Extension Library project.
    /// </summary>
    public class CueContentReader : ContentTypeReader<Cue>
    {
        protected override Cue Read(ContentReader input, Cue existingInstance)
        {
            Cue cue;

            string cueType = input.ReadString();
            List<string> cueData = input.ReadObject<List<string>>();

            switch (cueType)
            {
                case "DialogCue":
                    cue = new DialogCue(cueType, cueData);
                    break;
                default:
                    cue = new Cue(cueType, cueData);
                    Debug.WriteLine("Failed to read cue type (Case not defined): " + cueType + ".\nFollowing cases defined: DialogCue");
                    break;
            }

            return cue;
        }
    }
}
