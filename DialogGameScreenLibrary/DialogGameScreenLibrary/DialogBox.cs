using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameStateManagement;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using CutsceneScreenLibrary.Helpers;

namespace CutsceneScreenLibrary
{
    public class DialogBox : IDialogBox
    {
        #region Variables
        private int currentDelay;
        private int typingDelay;
        private Texture2D texture;
        private int width;
        private int height;
        private int borderRadius;
        private int borderThickness;
        private int borderShadow;
        private List<Color> backgroundColors;
        private List<Color> borderColors;
        private float initialShadowIntensity;
        private float finalShadowIntensity;
        private float textShadowIntensity;
        private List<DialogCue> dialogCues;
        private Vector2 position;
        private Vector2 textShadowOffset;
        private Dictionary<string, SpriteFont> fonts;
        TextBlock textBlock;
        private DialogCue activeCue;

        //Some test variables
        private const string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium neque sit amet nibh feugiat, et ultricies lorem mollis. Curabitur eget risus vitae metus adipiscing pretium. Nullam vitae neque sed arcu commodo fermentum sed eget odio. Duis dolor nibh, blandit quis vehicula nec, adipiscing sit amet eros. Pellentesque vulputate massa vel purus sollicitudin malesuada. Mauris interdum molestie magna nec scelerisque. Aliquam lobortis volutpat massa, ac dapibus mi porttitor eu. Donec et justo dolor. Pellentesque in convallis erat. Suspendisse consectetur viverra consectetur. Nunc id tellus et nisi varius pharetra. Aenean pulvinar fermentum eros et molestie. In suscipit, velit congue condimentum accumsan, urna est tincidunt est, aliquet pretium ligula nisi et quam.";
        #endregion

        #region Properties
        public bool HasTextures { get { return texture != null; } }
        public bool EndOfCue
        {
            get { return true; }
        }
        public Rectangle BoxArea;
        public Rectangle TextArea
        {
            get 
            {
                return new Rectangle((int)TextPosition.X,
                                     (int)TextPosition.Y,
                                     (width - 2 * (borderThickness + (borderRadius / 2))),
                                     (height - 2 * (borderThickness + (borderRadius / 2)))); 
            }
        }
        Vector2 TextPosition
        {
            get
            {
                return new Vector2((position.X + (borderThickness + (borderRadius / 2))),
                                   (position.Y + (borderThickness + (borderRadius / 2))));
            }
        }
        public Dictionary<string, SpriteFont> Fonts
        {
            get { return fonts; }
            set 
            { 
                fonts = value;
                if (textBlock!=null)
                    textBlock.Fonts = fonts;
            }
        }
        public DialogCue ActiveCue
        {
            get { return activeCue; }
            set
            {
                activeCue = value;
                SetNextText(activeCue);
            }
        }
        #endregion

        #region Events
        public event DialogBoxTypingEventHandler CharacterTyped;
        #endregion

        #region Delegates
        public delegate void DialogBoxTypingEventHandler(object sender, DialogBoxTypingEventArgs e);
        #endregion

        #region Constructors
        public DialogBox()
        {
            Fonts = new Dictionary<string, SpriteFont>();

            //This is a dummy constructor. Empty out at some point!
            width = 600;
            height = 160;
            borderThickness = 8;
            borderRadius = 16;
            borderShadow = 2;
            initialShadowIntensity = 0.25f;
            finalShadowIntensity = 0.25f;
            //backgroundColors = new List<Color>() { new Color(0, 0, 240), new Color(0, 0, 100), new Color(0, 0, 180), new Color(0, 0, 40) };
            backgroundColors = new List<Color>() { new Color(200, 200, 200), new Color(60, 60, 60), new Color(140, 140, 140), new Color(0, 0, 0) };
            borderColors = new List<Color> { new Color(105, 105, 105), new Color(250, 250, 250), new Color(105, 105, 105) };
            typingDelay = 2500;
            currentDelay = typingDelay;
            textShadowIntensity = 0.5f;
            textShadowOffset = new Vector2(4, 4);
            position = new Vector2(0, 320);
            textBlock = new TextBlock(TextArea, Fonts);
            textBlock.TextEffects.Add("shadow", "Black,128,2,2");
            //textBlock.TextEffects.Add("color", "Black");
            //textBlock.TextEffects.Add("typing", "250");
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            if (textBlock != null) textBlock.Update(gameTime);
        }
        public void CreateTextures(GraphicsDevice graphics)
        {
            texture = GraphicHelper.CreateRoundedRectangleTexture(graphics, width, height, borderThickness, borderRadius, borderShadow, backgroundColors, borderColors, initialShadowIntensity, finalShadowIntensity);
        }
        private void TypeCharacter()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null) spriteBatch.Draw(texture, position, Color.White);
            if (textBlock != null) textBlock.Draw(spriteBatch);
        }
        public void FinishTypingCurrentLine()
        {
            throw new NotImplementedException();
        }
        public void SetNextText(DialogCue dialogCue)
        {
            textBlock.CreateCharactersFromDialogCue(dialogCue);
        }
        #endregion
    }
}
