using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public class BasicWord : Character
    {
        public BasicWord(Vector2 pos, SpriteFont font, string text)
            : base(pos, font, text)
        {
        }
    }
}
