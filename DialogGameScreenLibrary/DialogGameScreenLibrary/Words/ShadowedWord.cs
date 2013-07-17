using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public class ShadowedCharacter : CharacterDecorator
    {
        private Color shadowColor;
        private Vector2 shadowOffset;

        public override Vector2 Size
        {
            get
            {
                Vector2 value = baseWord.Size;
                value += shadowOffset;
                return value;
            }
        }

        public ShadowedCharacter(Character word, Color color, Vector2 offset)
            : base(word)
        {
            shadowColor = color;
            shadowOffset = offset;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position + shadowOffset, shadowColor);
            baseWord.Draw(spriteBatch);
        }
    }
}
