using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CutsceneScreenLibrary
{
    public class DialogBox
    {
        private List<Texture2D> cornerAssets;
        private List<Texture2D> sideAssets;
        private Texture2D backdrop;

        public bool DrawName { get; set; }
        public DialogCue ActiveDialog { get; set; }
        public Dictionary<string, SpriteFont> Fonts { get; set; }
        public Rectangle Size { get; set; }
        public Rectangle TextArea { get; set; }

        public DialogBox()
        {
        }

        public void LoadContent(ContentManager content)
        {

        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        string WordWrap(string text)
        {
            string output = "";
            string line = "";
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (Fonts.ContainsKey(ActiveDialog.FontName))
                {
                    if (Fonts[ActiveDialog.FontName].MeasureString(line + word).Length() > TextArea.Width)
                    {
                        output += line + "\n";
                        line = "";
                    }
                    line += word + " ";
                }
                else
                {
                    if (Fonts.Values.First().MeasureString(line + word).Length() > TextArea.Width)
                    {
                        output += line + "\n";
                        line = "";
                    }
                    line += word + " ";
                }
            }

            return output + line;
        }
    }
}
