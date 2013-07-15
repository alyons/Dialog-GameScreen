using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary
{
    public interface IDialogBox
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void FinishTypingCurrentLine();
    }
}
