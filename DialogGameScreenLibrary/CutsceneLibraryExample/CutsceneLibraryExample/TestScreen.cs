using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStateManagement;
using Microsoft.Xna.Framework;
using CutsceneScreenLibrary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace CutsceneLibraryExample
{
    public class TestScreen : GameScreen
    {
        #region Variables
        DialogBox dialogBox;
        #endregion

        #region Properties
        #endregion

        #region Initialization
        public TestScreen()
        {
            dialogBox = new DialogBox()
            {
                BoxArea = new Rectangle(0, 320, 600, 160),
                BoxColors = new List<Color>() { new Color(0, 0, 240), new Color(0, 0, 100), new Color(0, 0, 180), new Color(0, 0, 40) },
                BorderThickness = 7,
                BorderRadius = 5,
                //BorderColors = new List<Color> { new Color(155, 155, 155), new Color(250, 250, 250), new Color(155, 155, 155) }
                BorderColors = new List<Color> { new Color(250, 250, 250) }
            };
        }

        public void LoadContent(ContentManager content)
        {

        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            if (dialogBox.texture == null)
            {
                try
                {
                    dialogBox.texture = dialogBox.CreateBackdrop(ScreenManager.GraphicsDevice);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            dialogBox.Draw(spriteBatch);
            spriteBatch.End();
        }
        #endregion
    }
}
