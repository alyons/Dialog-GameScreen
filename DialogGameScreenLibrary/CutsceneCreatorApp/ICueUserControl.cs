using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutsceneCreatorApp
{
    interface ICueUserControl
    {
        void InitializeCueData(List<string> data);
        bool ValidateCueData();
        List<string> GetCueData();
        string InvalidDataMessage();
    }
}
