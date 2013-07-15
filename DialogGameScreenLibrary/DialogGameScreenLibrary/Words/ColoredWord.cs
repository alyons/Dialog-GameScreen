using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public class ColoredWord : WordDecorator
    {
        public Color color;

        public ColoredWord(Word word, Color c)
            :base(word)
        {
            color = c;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, DrawableText, Position, color);
        }
    }
}
