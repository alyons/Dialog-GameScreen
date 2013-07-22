using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CutsceneScreenLibrary;
using GameStateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CutsceneLibraryExample
{
    public class TestScreen : GameScreen
    {
        #region Variables
        DialogBox dialogBox;
        ContentManager content;
        InputAction proceedActions;
        InputAction resetActions;
        int cueCount;
        List<Cue> cues;
        #endregion

        #region Properties
        #endregion

        #region Initialization
        public TestScreen()
        {
            dialogBox = new DialogBox();

            proceedActions = new InputAction(new Buttons[] { Buttons.A }, new Keys[] { Keys.Space }, true);
            resetActions = new InputAction(new Buttons[] { Buttons.Back, Buttons.B }, new Keys[] { Keys.Home }, true);
            cueCount = -1;
        }
        public override void Activate(bool instancePreserved)
        {
            if (content == null) content = new ContentManager(ScreenManager.Game.Services, "Content");

            cues = content.Load<List<Cue>>(@"XML\Cutscene\SonicCutscene01");

            foreach (DialogCue dc in cues.FindAll(c => c is DialogCue))
            {
                //First test font string
                if (!dialogBox.Fonts.ContainsKey(dc.FontName))
                {
                    dialogBox.Fonts.Add(dc.FontName, content.Load<SpriteFont>(dc.FontName));
                }

                //Then look for font amendments in lines
                if (dc.Line.Contains("[font="))
                {
                    int startPos = dc.Line.IndexOf("[font=");
                    int endPos = dc.Line.IndexOf("]", startPos);
                    string substring = dc.Line.Substring(startPos, endPos - startPos + 1);
                    substring = substring.Remove(0, 6);
                    substring = substring.Remove(substring.Count() - 1);
                    if (!dialogBox.Fonts.ContainsKey(substring))
                    {
                        dialogBox.Fonts.Add(substring, content.Load<SpriteFont>(substring));
                    }
                }
            }
        }
        #endregion

        #region Methods
        public override void HandleInput(GameTime gameTime, InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = /*(int)ControllingPlayer.Value;*/1;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            PlayerIndex player;

            if (proceedActions.Evaluate(input, ControllingPlayer, out player))
            {
                Proceed();
            }
        }
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            if (!dialogBox.HasTextures)
            {
                dialogBox.CreateTextures(ScreenManager.GraphicsDevice);
            }

            dialogBox.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            dialogBox.Draw(spriteBatch);
            spriteBatch.End();
        }

        void Proceed()
        {
            if (dialogBox.EndOfCue)
            {
                cueCount++;
                if (cueCount > cues.Count - 1) cueCount = 0;
                dialogBox.ActiveCue = (cues[cueCount] as DialogCue);
            }
            else
            {
                dialogBox.NextLine();
            }
        }
        #endregion
    }
}
