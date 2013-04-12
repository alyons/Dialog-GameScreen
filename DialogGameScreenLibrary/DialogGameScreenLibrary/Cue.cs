using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace DialogGameScreenLibrary
{
    public enum CueType
    {
        BackgroundChange,
        Talk,
        ChangeActorPortrait,
        Animation,
        MusicChange,
        SFX,
        ChangeActor,
        VFX
    }

    public class Dialog
    {
        #region Fields
        CueType cueAction;
        String value1;
        String value2;
        #endregion

        #region Properties
        public CueType Action
        {
            get { return cueAction; }
        }

        public String Value1
        {
            get { return value1; }
        }

        public String Value2
        {
            get { return value2; }
            set { value2 = value; }
        }
        #endregion

        #region Initialization
        public Dialog(CueData cd)
        {
            ParseAction(cd.cueType);
            value1 = cd.value1;
            value2 = cd.value2;

            UpdateActorName();
        }
        #endregion

        #region Helper Methods
        private void ParseAction(string s)
        {
            switch (s)
            {
                case ("Animation"):
                    cueAction = CueType.Animation;
                    break;
                case ("BackgroundChange"):
                    cueAction = CueType.BackgroundChange;
                    break;
                case ("ChangeActor"):
                    cueAction = CueType.ChangeActor;
                    break;
                case ("ChangeActorPortrait"):
                    cueAction = CueType.ChangeActorPortrait;
                    break;
                case ("MusicChange"):
                    cueAction = CueType.MusicChange;
                    break;
                case ("SFX"):
                    cueAction = CueType.SFX;
                    break;
                case ("Talk"):
                    cueAction = CueType.Talk;
                    break;
                case ("VFX"):
                    cueAction = CueType.VFX;
                    break;
                default:
                    cueAction = CueType.Talk;
                    break;
            }
        }

        private void UpdateActorName()
        {
            if (cueAction == CueType.Talk)
            {
                if (value1.Equals("Player"))
                {
                    value1 = GameDataManager.Player.Name;
                }
            }
        }
        #endregion
    }

    [Serializable]
    public class CueData
    {
        public string cueType;
        public string value1;
        public string value2;
    }

    public class CueDataContentReader : ContentTypeReader<CueData>
    {
        protected override CueData Read(ContentReader input, CueData existingInstance)
        {
            CueData cd = new CueData();

            cd.cueType = input.ReadString();
            cd.value1 = input.ReadString();
            cd.value2 = input.ReadString();

            return cd;
        }
    }
}
