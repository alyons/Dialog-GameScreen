using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CutsceneScreenLibrary
{
    public class SimpleDialogBox
    {
        private Texture2D backdrop;

        public SimpleDialogBox()
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
            /*string output = "";
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

            return output + line;*/

            throw new NotImplementedException();
        }
    }
}
