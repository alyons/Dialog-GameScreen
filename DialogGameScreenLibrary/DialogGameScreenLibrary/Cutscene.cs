using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CutsceneScreenLibrary
{
    public class Cutscene
    {
        #region Fields
        private List<Cue> cues;
        private Dictionary<string, SpriteFont> fonts;
        private string cueAsset;
        private IDialogBox dialogBox;
        #endregion

        #region Properties
        [ContentSerializerIgnore]
        public List<Cue> Cues
        {
            get { return cues; }
            set { cues = value; }
        }

        [ContentSerializerIgnore]
        public Dictionary<string, SpriteFont> Fonts
        {
            get { return fonts; }
            set { fonts = value; }
        }

        public string CueAsset
        {
            get { return CueAsset; }
            set { cueAsset = value; }
        }
        #endregion

        #region Initialization
        public Cutscene(IDialogBox db)
        {
            cues = new List<Cue>();
            fonts = new Dictionary<string, SpriteFont>();
            dialogBox = db;
        }
        public void LoadData(ContentManager content)
        {
            Cues.AddRange(content.Load<List<Cue>>(CueAsset));

            foreach (Cue cue in Cues.Where(c => c is DialogCue))
            {
                if (!Fonts.ContainsKey((cue as DialogCue).FontName))
                {
                    Fonts.Add((cue as DialogCue).FontName, content.Load<SpriteFont>((cue as DialogCue).FontName));
                }
            }
        }
        #endregion

        #region Update and Draw
        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
        #endregion

        #region Helper Methods
        public bool ReadyToStart()
        {
            return (Fonts.Count > 0 && Cues.Count > 0);
        }
        #endregion

        #region Accessor Methods
        #endregion
    }
}
