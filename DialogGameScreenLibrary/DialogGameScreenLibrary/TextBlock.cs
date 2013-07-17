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
        public void CreateCharactersFromDialogCue_Old(DialogCue dialogCue)
        {
            Dictionary<string, string> appliedEffects = TextEffects;
            Vector2 nextPos = new Vector2(TextArea.X, TextArea.Y);
            List<string> keysToRemove = new List<string>();
            int lastSpace = 0;
            int wordCount = 0;

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

                    if (toAdd.Right > TextArea.Right && !toAdd.Text.Equals(" "))
                    {
                        toAdd.Position = new Vector2(TextArea.X, words.Last().Bottom);
                    }
                    else
                    {
                        if (word.Equals(" ")) lastSpace = wordCount;
                    }

                    nextPos = new Vector2(toAdd.Right, toAdd.Position.Y);
                    words.Add(toAdd);
                    wordCount++;
                }
            }
        }
        public void CreateCharactersFromDialogCue(DialogCue dialogCue)
        {
            Dictionary<string, string> appliedEffects = TextEffects;
            Vector2 nextPos = new Vector2(TextArea.X, TextArea.Y);
            List<string> keysToRemove = new List<string>();
            List<Character> wordToAdd = new List<Character>();
            List<string> characters = SplitString(dialogCue.Line);
            int lastCharacter = 0;

            for (int i = 0; i < characters.Count; i++) if (!characters[i].IsDialogCueTag()) lastCharacter = i;

            words.Clear();

            for (int i = 0; i < characters.Count; i++)
            {
                string word = characters[i];

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

                    wordToAdd.Add(toAdd);

                    if (wordToAdd.Last().Text.Equals(" ") || i == lastCharacter)
                    {
                        //Test for word wrapping and all of that shit (oh could add logic to handle really long words as well, i.e. hyphenation)!
                        float wordLength = 0;
                        foreach (Character c in wordToAdd) if (!c.Text.Equals(" ")) wordLength += c.Size.X;

                        if (nextPos.X + wordLength > TextArea.Right)
                        {
                            //This is where hyphenation would be extremely useful
                            nextPos = new Vector2(TextArea.X, words.Last().Bottom);
                            foreach (Character c in wordToAdd)
                            {
                                c.Position = nextPos;
                                nextPos = new Vector2(c.Right, c.Position.Y);
                            }
                        }
                        else
                        {
                            foreach (Character c in wordToAdd)
                            {
                                c.Position = nextPos;
                                nextPos = new Vector2(c.Right, c.Position.Y);
                            }
                        }

                        words.AddRange(wordToAdd);
                        wordToAdd.Clear();
                    }
                }
            }
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
