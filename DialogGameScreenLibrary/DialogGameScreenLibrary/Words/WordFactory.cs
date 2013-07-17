using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CutsceneScreenLibrary.Words
{
    public static class WordFactory
    {
        public static Character GenerateWord(Vector2 position, SpriteFont font, string text, Dictionary<string, string> effects)
        {
            Character someWord;

            #region Create Base Word
            someWord = new BasicWord(position, font, text);
            #endregion

            #region Decorate Word
            if (effects.ContainsKey("color"))
            {
                var colorProp = typeof(Color).GetProperty(effects["color"]);
                if (colorProp != null)
                {
                    someWord = new ColoredCharacter(someWord, (Color)colorProp.GetValue(null, null));
                }
                else
                {
                    string[] values = effects["color"].Split(',');
                    int[] rgba = new int[4];
                    if (values.Count() == 4)
                    {
                        for (int i = 0; i < 4; i++)
                            if (!Int32.TryParse(values[i], out rgba[i]))
                            {
                                rgba = new int[] { 255, 255, 255, 255 };
                                break;
                            }
                        someWord = new ColoredCharacter(someWord, new Color(rgba[0], rgba[1], rgba[2], rgba[3]));
                    }
                }
            }

            
            if (effects.ContainsKey("shadow"))
            {
                string[] values = effects["shadow"].Split(',');
                if (values.Length == 4)
                {
                    var colorProp = typeof(Color).GetProperty(values[0]);
                    Color shadowColor = (colorProp != null) ? (Color)colorProp.GetValue(null, null) : Color.Black;
                    int alpha = 128;
                    Int32.TryParse(values[1], out alpha);
                    shadowColor.A = (byte)alpha;
                    int x = 4, y = 4;
                    Int32.TryParse(values[2], out x);
                    Int32.TryParse(values[3], out y);
                    Vector2 shadowOffset = new Vector2(x, y);
                    someWord = new ShadowedCharacter(someWord, shadowColor, shadowOffset);
                }
            }
            #endregion

            return someWord;
        }
    }
}
