using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using CutsceneScreenLibrary;

namespace CutsceneLibraryContentExtension
{
    [ContentTypeWriter]
    public class CueContentWriter : ContentTypeWriter<Cue>
    {
        protected override void Write(ContentWriter output, Cue value)
        {
            output.Write(value.CueType);
            output.WriteObject<List<string>>(value.CueData);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(CueContentWriter).AssemblyQualifiedName;
        }
    }
}
