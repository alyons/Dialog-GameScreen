using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameStateManagement;
using Microsoft.Xna.Framework;

namespace CutsceneScreenLibrary
{
    public abstract class DialogBox
    {
        public Rectangle BoxArea;
        public Rectangle TextArea;
        public SpriteFont Font;
        public List<Color> BoxColors;
        public Color BorderColor;
        public int BorderThickness;
        public int BorderRadius;

        public virtual Texture2D CreateBackdrop(ref GraphicsDevice graphics)
        {
            if (BoxColors == null || BoxColors.Count == 0) throw new Exception("Must define at least one box color");

            Texture2D texture = new Texture2D(graphics, BoxArea.Width, BoxArea.Height, true, SurfaceFormat.Color);
            Color[] color = new Color[texture.Width * texture.Height];
            Color toIgnore = new Color(255, 0, 255, 0);

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    switch(BoxColors.Count)
                    {
                        case 4:
                            Color leftColor = Color.Lerp(BoxColors[0], BoxColors[1], (y / (texture.Height - 1)));
                            Color rightColor = Color.Lerp(BoxColors[2], BoxColors[3], (y / (texture.Height - 1)));
                            color[x + texture.Width * y] = Color.Lerp(leftColor, rightColor, (x / (texture.Width - 1)));
                            break;
                        case 2:
                            color[x + texture.Width * y] = Color.Lerp(BoxColors[0], BoxColors[1], (x / (texture.Width - 1)));
                            break;
                        default:
                            color[x + texture.Width * y] = BoxColors[0];
                            break;
                    }
                }
            }

            texture.SetData<Color>(color);
            throw new NotImplementedException();
            //return texture;
        }

        protected virtual string WordWrap(string text)
        {
            string output = "";
            string line = "";
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (Font.MeasureString(line + word).Length() > TextArea.Width)
                {
                    output += line + "\n";
                    line = "";
                }
                line += word + " ";
            }

            return output + line;
        }
    }
}
