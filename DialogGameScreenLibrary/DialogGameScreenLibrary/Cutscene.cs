using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogGameScreenLibrary
{
    public class Cutscene
    {
        #region Fields
        List<Dialog> scene = new List<Dialog>();
        List<Texture2D> backdrops = new List<Texture2D>();
        List<Texture2D> actors = new List<Texture2D>();

        //Fields necessary to write dialog on the screen
        public static SpriteFont textFont;
        public static SpriteFont nameFont;
        public static Texture2D dialogBox;
        public static Texture2D nextArrow;
        String typedText = "";
        String parsedText = "";
        String actorName = "";
        double typedTextLength = 0;
        int delay = 15;
        bool isDoneDrawing;
        bool actionComplete = false;
        int lineOn = 0;
        int timer = 0;

        //Fields necessary to show the flashing arrow
        bool showArrow = true;
        int arrowTimer = 0;
        bool arrowToggle = true;

        //Fields necessary to show the actors and backdrops
        string actorLeft;
        string actorRight;
        Texture2D leftActor;
        Texture2D rightActor;
        Texture2D activeBackground;
        #endregion

        #region Properties
        #endregion

        #region Initialization
        public Cutscene(CueData[] cd, ContentManager content)
        {
            foreach (CueData c in cd)
            {
                scene.Add(new Dialog(c));
            }

            LoadData(content);
        }

        public Cutscene()
        {
        }

        public void LoadData(ContentManager content)
        {
            foreach (Dialog d in scene)
            {
                switch (d.Action)
                {
                    case (CueType.BackgroundChange):
                        backdrops.Add(content.Load<Texture2D>("Images\\CutsceneBackgrounds\\" + d.Value1));
                        backdrops.Last().Name = d.Value1;
                        break;
                    case (CueType.ChangeActor):
                        if (d.Value1.Equals("player"))
                        {
                            actors.Add(GameDataManager.Player.MyImage);
                            actors.Last().Name = d.Value1;
                        }
                        else
                        {
                            actors.Add(content.Load<Texture2D>("Images\\CharacterImages\\" + d.Value1));
                            actors.Last().Name = d.Value1;
                        }
                        break;
                    case (CueType.Talk):
                        if (d.Value2.Contains("Player"))
                        {
                            d.Value2 = d.Value2.Replace("Player", GameDataManager.Player.Name);
                        }
                        break;
                }
            }
        }
        #endregion

        #region Update and Draw
        public void Update(GameTime gameTime)
        {
            if (!actionComplete)
            {
                switch (scene[lineOn].Action)
                {
                    case (CueType.BackgroundChange):
                        activeBackground = backdrops.Find(delegate(Texture2D t) { return t.Name.Equals(scene[lineOn].Value1); });
                        lineOn++;
                        break;
                    case (CueType.ChangeActor):
                        if (scene[lineOn].Value2.Equals("left"))
                        {
                            actorLeft = scene[lineOn].Value1;
                            leftActor = actors.Find(delegate(Texture2D t) { return t.Name.Equals(scene[lineOn].Value1); });
                        }
                        else
                        {
                            actorRight = scene[lineOn].Value1;
                            rightActor = actors.Find(delegate(Texture2D t) { return t.Name.Equals(scene[lineOn].Value1); });
                        }
                        lineOn++;
                        break;
                    default:
                        #region Write out dialog
                        if (parsedText.Length < 1)
                        {
                            actorName = scene[lineOn].Value1;
                            parsedText = wordWrap(scene[lineOn].Value2);
                        }

                        delay -= gameTime.ElapsedGameTime.Milliseconds;

                        if (delay <= 0)
                        {
                            if (typedText.Length < parsedText.Length)
                            {
                                typedText += parsedText[(int)typedTextLength];
                                typedTextLength++;
                            }
                            if (typedText.Length == parsedText.Length)
                            {
                                actionComplete = true;
                            }
                            delay += 15;
                        }
                        #endregion
                        break;
                }
            }
            else
            {
            }

            if (arrowTimer < 0)
            {
                arrowTimer += 333;
                showArrow = !showArrow;
            }

            timer -= gameTime.ElapsedGameTime.Milliseconds;
            arrowTimer -= gameTime.ElapsedGameTime.Milliseconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (activeBackground != null)
                spriteBatch.Draw(activeBackground, Vector2.Zero, Color.White);

            if (leftActor != null)
            {
                spriteBatch.Draw(leftActor, new Vector2(20, (540 - (leftActor.Height * 1.5f))), null, Color.White, 0.0f, Vector2.Zero, new Vector2(1.5f, 1.5f), SpriteEffects.FlipHorizontally, 0.0f);
            }

            if (rightActor != null)
            {
                spriteBatch.Draw(rightActor, new Vector2((1260 - rightActor.Width * 1.5f), (540 - rightActor.Height * 1.5f)), null, Color.White, 0.0f, Vector2.Zero, new Vector2(1.5f, 1.5f), SpriteEffects.None, 0.0f);
            }

            spriteBatch.Draw(dialogBox, new Vector2(0, 540), Color.White);

            spriteBatch.DrawString(nameFont, actorName + ":", new Vector2(10, 550), Color.White);
            spriteBatch.DrawString(textFont, typedText, new Vector2(12, 550 + nameFont.MeasureString(scene[lineOn].Value1).Y), Color.White);

            if (arrowToggle && showArrow && actionComplete)
                spriteBatch.Draw(nextArrow, new Vector2(1236, 672), Color.White);

        }
        #endregion

        #region Helper Methods
        private string wordWrap(String text)
        {
            String output = "";
            String line = "";
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (textFont.MeasureString(line + word).Length() > 1240)
                {
                    output += line + "\n";
                    line = "";
                }
                line += word + " ";
            }

            return output + line;
        }
        #endregion

        #region Accessor Methods
        public void NextLine()
        {
            if (actionComplete)
            {
                switch (scene[lineOn].Action)
                {
                    default:
                        parsedText = "";
                        typedText = "";
                        typedTextLength = 0;
                        break;
                }

                lineOn++;
                lineOn = (int)(MathHelper.Clamp(lineOn, 0, scene.Count - 1));
                actionComplete = false;
            }
        }

        public bool IsDone()
        {
            return (lineOn == scene.Count - 1 && showArrow);
        }
        #endregion
    }
}
