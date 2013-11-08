using System;
using System.Drawing;

namespace VitPro.Engine {

    [Serializable]
    [Flags]
    public enum FontStyle {
        Bold = System.Drawing.FontStyle.Bold,
        Italic = System.Drawing.FontStyle.Italic,
        Regular = System.Drawing.FontStyle.Regular,
        Strikeout = System.Drawing.FontStyle.Strikeout,
        Underline = System.Drawing.FontStyle.Underline,
    }

}