using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutsceneScreenLibrary.StringExtension
{
    public static class Strings
    {
        public static bool IsDialogCueTag(this string value)
        {
            return value.First() == '[' && value.Last() == ']';
        }

        public static bool IsDialogCueOpeningTag(this string value)
        {
            if (!value.IsDialogCueTag()) return false;

            return value[1] != '/';
        }

        public static bool IsDialogCueClosingTag(this string value)
        {
            if (!value.IsDialogCueTag()) return false;

            return value[1] == '/';
        }
    }
}
