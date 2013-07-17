using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CutsceneScreenLibrary.Words;
using Microsoft.Xna.Framework.Graphics;

namespace CutsceneScreenLibrary
{
    using CutsceneScreenLibrary.StringExtension;

    public class TextBlock
    {
        #region Variables
        private Vector2 position;
        private List<Character> words;
        private int lineSpacing;
        private Rectangle textArea;
        private Dictionary<string, SpriteFont> fonts;
        private bool isTyping = false;
        private Dictionary<string, string> textEffects;
        #endregion

        #region Properties
        public Rectangle TextArea
        {
            get { return textArea; }
            set { textArea = value; }
        }
        public Dictionary<string, SpriteFont> Fonts
        {
            get { return fonts; }
            set { fonts = value; }
        }
        public Dictionary<string, string> TextEffects
        {
            get { return textEffects; }
            set { textEffects = value; }
        }
        #endregion

        #region Events
        #endregion

        #region Delegates
        #endregion

        #region Initialization
        private TextBlock()
        {
            words = new List<Character>();
            TextEffects = new Dictionary<string, string>();
        }
        public TextBlock(Rectangle textArea, Dictionary<string, SpriteFont> fonts)
            : this()
        {
            TextArea = textArea;
            Fonts = fonts;
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            foreach (Character word in words)
                word.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Character word in words.FindAll(w => WordIsVisible(w)))
            {
                word.Draw(spriteBatch);
            }
        }
        public void CreateWordsFromDialogCue(DialogCue dialogCue)
        {
            Dictionary<string, string> appliedEffects = TextEffects;
            Vector2 nextPos = new Vector2(TextArea.X, TextArea.Y);
            List<string> keysToRemove = new List<string>();

            words.Clear();

            foreach (string word in SplitString(dialogCue.Line))
            {
                if (word.IsDialogCueOpeningTag())
                {
                    int tagStart = word.IndexOf('[');
                    int tagEnd = word.IndexOf(']');
                    int tagMid = word.IndexOf('=');
                    string key = word.Substring(tagStart + 1, tagMid - tagStart - 1);
                    string value = word.Substring(tagMid + 1, tagEnd - tagMid - 1);

                    if (appliedEffects.ContainsKey(key))
                        appliedEffects[key] = value;
                    else
                        appliedEffects.Add(key, value);
                }
                else if (word.IsDialogCueClosingTag())
                {
                    int tagStart = word.IndexOf('[');
                    int tagEnd = word.IndexOf(']');
                    string key = word.Substring(tagStart + 2, tagEnd - tagStart - 2);
                    if (appliedEffects.ContainsKey(key))
                        appliedEffects.Remove(key);
                }
                else
                {
                    Character toAdd;
                    if (appliedEffects.ContainsKey("font"))
                    {
                        toAdd = WordFactory.GenerateWord(nextPos, Fonts[appliedEffects["font"]], word, appliedEffects);
                    }
                    else
                    {
                        toAdd = WordFactory.GenerateWord(nextPos, Fonts[dialogCue.FontName], word, appliedEffects);
                    }

                    if (toAdd.Right > TextArea.Right)
                    {
                        toAdd.Position = new Vector2(TextArea.X, words.Last().Bottom);
                    }

                    nextPos = new Vector2(toAdd.Right, toAdd.Position.Y);
                    words.Add(toAdd);
                }
            }
        }
        List<string> SplitString_Old(string text)
        {
            List<string> output = new List<string>();

            foreach (string s in text.Split(' '))
            {
                string toWorkWith = s + ' ';
                while (toWorkWith.Contains('['))
                {
                    int tagStart = toWorkWith.IndexOf('[');
                    int tagEnd = toWorkWith.IndexOf(']');
                    if (tagStart > 0)
                    {
                        output.Add(toWorkWith.Substring(0, tagStart));
                        toWorkWith = toWorkWith.Remove(0, tagStart);
                        tagStart = toWorkWith.IndexOf('[');
                        tagEnd = toWorkWith.IndexOf(']');
                    }
                    output.Add(toWorkWith.Substring(tagStart, tagEnd - tagStart + 1));
                    toWorkWith = toWorkWith.Remove(tagStart, tagEnd - tagStart + 1);
                }
                output.Add(toWorkWith);
            }

            return output;
        }
        List<string> SplitString(string text)
        {
            List<string> output = new List<string>();
            bool inTag = false;
            string tag = "";

            foreach (char c in text)
            {
                if (inTag)
                {
                    tag += c;
                    if (c == ']')
                    {
                        output.Add(tag);
                        inTag = false;
                        tag = "";
                    }
                }
                else
                {
                    if (c == '[')
                    {
                        tag += c;
                        inTag = true;
                    }
                    else
                    {
                        output.Add("" + c);
                    }
                }
            }

            return output;
        }
        bool WordIsVisible(Character word)
        {
            return TextArea.Contains(word.Area);
        }
        #endregion
    }
}
