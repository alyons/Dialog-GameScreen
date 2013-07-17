using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary.Words
{
    public abstract class Character
    {
        #region Variables
        protected string text;
        protected Vector2 position;
        protected SpriteFont font;
        #endregion

        #region Properties
        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public virtual SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        public virtual string Text
        {
            get { return text; }
            set { text = value; }
        }
        public virtual Vector2 Size
        {
            get { return font.MeasureString(text); }
        }
        public virtual float Right
        { 
            get { return position.X + Size.X; } 
        }
        public virtual float Bottom 
        { 
            get { return position.Y + Size.Y; }
        }
        public virtual Rectangle Area
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            }
        }
        #endregion

        #region Constructors
        protected Character(Vector2 pos, SpriteFont font, string text)
        {
            position = pos;
            this.font = font;
            this.text = text;
        }
        #endregion

        #region Methods
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position, Color.White);
        }
        #endregion
    }
}
