using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public class TypedWord : Word
    {
        private int charDisplayed;
        private int delay = 0;
        private int timeLeft = 0;

        public override string DrawableText
        {
            get
            {
                return base.Text.Substring(0, charDisplayed);
            }
        }

        public TypedWord(Vector2 pos, SpriteFont font, string text, int typingDelay)
            : base(pos, font, text)
        {
            delay = typingDelay;
            timeLeft = delay;
            charDisplayed = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (charDisplayed < Text.Length)
            {
                timeLeft -= gameTime.ElapsedGameTime.Milliseconds;

                if (timeLeft <= 0)
                {
                    charDisplayed += 1;
                    timeLeft += delay;
                }
            }
        }
    }
}
