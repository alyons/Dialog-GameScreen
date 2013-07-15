using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CutsceneScreenLibrary.Words
{
    public class TypedWord : WordDecorator
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

        public TypedWord(Word word, int typingDelay)
            : base(word)
        {
            delay = typingDelay;
            timeLeft = delay;
            charDisplayed = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (charDisplayed < text.Length)
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
