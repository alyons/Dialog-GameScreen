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
using GameStateManagement;
using CutsceneScreenLibrary;

namespace CutsceneLibraryExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CutsceneExampleGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenManager screenManager;

        public CutsceneExampleGame()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();

            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            AddInitialScreens();
        }

        private void AddInitialScreens()
        {
            //screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new TestScreen(), null);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
