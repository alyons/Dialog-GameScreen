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
            get { return base.Position; }
            set { base.Position = value; }
        }
        public override SpriteFont Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        public override Vector2 Size
        {
            get { return base.Size; }
        }
        public override float Right
        {
            get { return base.Right; }
        }
        public override float Bottom
        {
            get { return base.Bottom; }
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
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
