using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameStateManagement;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace CutsceneScreenLibrary
{
    public class DialogBox
    {
        public Rectangle BoxArea;
        public Rectangle TextArea;
        public SpriteFont Font;
        public List<Color> BoxColors;
        public List<Color> BorderColors;
        public int BorderThickness;
        public int BorderRadius;
        public Texture2D texture;
        public Rectangle InternalBox
        {
            get { return new Rectangle(BoxArea.X + (BorderThickness + BorderRadius), BoxArea.Y + (BorderThickness + BorderRadius), BoxArea.Width - 2 * (BorderThickness + BorderRadius), BoxArea.Height - 2 * (BorderThickness + BorderRadius)); }
        }

        public virtual Texture2D CreateBackdrop(GraphicsDevice graphics)
        {
            if (BoxColors == null || BoxColors.Count == 0) throw new Exception("Must define at least one box color");

            Texture2D texture = new Texture2D(graphics, BoxArea.Width, BoxArea.Height, false, SurfaceFormat.Color);
            Color[] color = new Color[texture.Width * texture.Height];
            Color toIgnore = new Color(255, 0, 255, 0);

            #region Fill in texture
            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    switch (BoxColors.Count)
                    {
                        case 4:
                            Color leftColor = Color.Lerp(BoxColors[0], BoxColors[1], ((float)y / (BoxArea.Width - 1)));
                            Color rightColor = Color.Lerp(BoxColors[2], BoxColors[3], ((float)y / (BoxArea.Height - 1)));
                            color[x + BoxArea.Width * y] = Color.Lerp(leftColor, rightColor, ((float)x / (BoxArea.Width - 1)));
                            break;
                        case 2:
                            color[x + BoxArea.Width * y] = Color.Lerp(BoxColors[0], BoxColors[1], ((float)x / (BoxArea.Width - 1)));
                            break;
                        default:
                            color[x + BoxArea.Width * y] = BoxColors[0];
                            break;
                    }
                }
            }
            #endregion

            #region Draw Border
            if (BorderColors.Count > 0)
            {
                if (BorderThickness > 0)
                {
                    if (BorderRadius > 0)
                    {
                        #region Rounded Corner Creating Code
                        /*for (int t = 0; t < BorderThickness; t++)
                        {
                            for (int x = 0; x < BoxArea.Width; x++)
                            {
                                for (int y = 0; y < BoxArea.Height; y++)
                                {
                                    Vector2 point = new Vector2(x + BoxArea.X, y + BoxArea.Y);
                                    int radius = t + BorderRadius;

                                    if (IsOnPerimeter(radius, point))
                                    {
                                        switch (BorderColors.Count)
                                        {
                                            default:
                                                color[x + BoxArea.Width * y] = BorderColors[0];
                                                break;
                                        }
                                    }


                                }
                            }
                        }*/
                        #endregion

                        #region Circle Creating Code
                        for (int t = 0; t < BorderThickness; t++)
                        {
                            int radius = t + BorderRadius;
                            Rectangle internalBox = InternalBox;
                            Vector2[] corners = new Vector2[4];
                            corners[0] = new Vector2(internalBox.Left, internalBox.Top);
                            corners[1] = new Vector2(internalBox.Left, internalBox.Bottom);
                            corners[2] = new Vector2(internalBox.Right, internalBox.Top);
                            corners[3] = new Vector2(internalBox.Right, internalBox.Bottom);

                            foreach(Vector2 corner in corners)
                            {
                                for (int angle = 0; angle < 360; angle++)
                                {
                                    int x = (int)Math.Round(corner.X + radius * Math.Cos(DegreeToRadian(angle)));
                                    int y = (int)Math.Round(corner.Y + radius * Math.Sin(DegreeToRadian(angle)));
                                    int colorPoint = (int)Math.Round((corner.X + x) + (corner.Y + y) * BoxArea.Height);
                                    color[colorPoint] = BorderColors[0];
                                } 
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //Perform logic to create a rectangular frame.
                    }
                }
            }
            #endregion

            #region Erase Outside of corners
            #endregion

            texture.SetData<Color>(color);
            //throw new NotImplementedException();
            return texture;
        }

        protected string WordWrap(string text)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null) spriteBatch.Draw(texture, BoxArea, Color.White);
        }

        protected bool IsOnPerimeter(int radius, Vector2 point)
        {
            //(BorderThickness + BorderRadius)
            Rectangle internalBox = InternalBox;
            Vector2[] corners = new Vector2[4];
            corners[0] = new Vector2(internalBox.Left, internalBox.Top);
            corners[1] = new Vector2(internalBox.Left, internalBox.Bottom);
            corners[2] = new Vector2(internalBox.Right, internalBox.Top);
            corners[3] = new Vector2(internalBox.Right, internalBox.Bottom);

            /*if (point.X < corners[0].X && point.Y < corners[0].Y)
            {
                if (
            }*/

            foreach (Vector2 corner in corners)
            {
                if ((Math.Pow(point.X - corner.X, 2) + Math.Pow(point.Y - corner.Y, 2)) == Math.Pow(radius, 2))
                    return true;
            }



            return false;
        }

        double DegreeToRadian(double angle)
        {
            while (angle < -360) angle += 360;
            while (angle > 360) angle -= 360;
            return Math.PI * (angle / 180.0);
        }
    }
}
