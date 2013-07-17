using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public class ColoredCharacter : CharacterDecorator
    {
        public Color color;

        public ColoredCharacter(Character word, Color c)
            :base(word)
        {
            color = c;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position, color);
        }
    }
}
