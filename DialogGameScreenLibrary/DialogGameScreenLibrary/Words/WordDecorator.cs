using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public abstract class CharacterDecorator : Character
    {
        #region Variables
        protected Character baseWord;
        #endregion

        #region Properties
        public override Vector2 Position
        {
            get { return baseWord.Position; }
            set { baseWord.Position = value; }
        }
        public override SpriteFont Font
        {
            get { return baseWord.Font; }
            set { baseWord.Font = value; }
        }
        public override string Text
        {
            get { return baseWord.Text; }
            set { baseWord.Text = value; }
        }
        public override Vector2 Size
        {
            get { return baseWord.Size; }
        }
        public override float Right
        {
            get { return baseWord.Right; }
        }
        public override float Bottom
        {
            get { return baseWord.Bottom; }
        }
        #endregion

        #region Contructors
        public CharacterDecorator(Character word)
            : base(word.Position, word.Font, word.Text)
        {
            baseWord = word;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            baseWord.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            baseWord.Draw(spriteBatch);
        }
        #endregion
    }
}
