using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DialogGameScreenLibrary
{
    public class CutsceneScreen
    {
        ContentManager content;
        SpriteFont testFont;
        Cutscene scene;
        bool initializedCutscene = false;

        public CutsceneScreen()
        {
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            Cutscene.dialogBox = content.Load<Texture2D>("Images\\DialogBox");
            Cutscene.nextArrow = content.Load<Texture2D>("Images\\dialogArrow");
            Cutscene.nameFont = content.Load<SpriteFont>("Fonts\\CutsceneNameFont");
            Cutscene.textFont = content.Load<SpriteFont>("Fonts\\CutsceneTextFont");

            testFont = content.Load<SpriteFont>(@"Fonts\\testFont");
            scene = new Cutscene(content.Load<CueData[]>("XML\\Cutscene\\" + GameDataManager.PullCutscene), content);
 	        
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
            if (IsActive && scene != null)
            {
                scene.Update(gameTime);
            }

        }

        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new GameMenu(), ControllingPlayer);
            }

            if (keyboardState.IsKeyDown(Keys.M))
            {
                LoadingScreen.Load(ScreenManager, true, ControllingPlayer, new MapScreen());
            }

            if (input.LeftButtonPressed() || keyboardState.IsKeyDown(Keys.Space))
            {
                if(scene != null)
                    if(scene.IsDone())
                        LoadingScreen.Load(ScreenManager, true, ControllingPlayer, new MapScreen());

                if (scene != null)
                    scene.NextLine();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 vector = new Vector2(400,400);
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();
            if(scene != null)
                scene.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        } 
     }
}
