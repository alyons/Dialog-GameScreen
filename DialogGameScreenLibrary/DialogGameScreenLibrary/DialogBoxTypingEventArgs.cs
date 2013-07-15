using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutsceneScreenLibrary
{
    public class DialogBoxTypingEventArgs : EventArgs
    {
        #region Properties
        public char CharacterTyped { get; private set; }
        #endregion

        #region Constructors
        public DialogBoxTypingEventArgs(char c)
            : base()
        {
            CharacterTyped = c;
        }
        #endregion
    }
}
