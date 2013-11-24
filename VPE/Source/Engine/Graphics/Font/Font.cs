using System;
using System.Drawing;
using System.Drawing.Text;
using SFont = System.Drawing.Font;

namespace VitPro.Engine {

    [Serializable]
    public class Font : IFont {
        public bool Smooth = true;

		PrivateFontCollection pfc = new PrivateFontCollection();
        internal SFont sfont;
        public Font(string filename, double emSize, FontStyle style = FontStyle.Regular) {
			pfc.AddFontFile(filename);
			var family = pfc.Families[0];
			sfont = new SFont(family, (float)emSize, (System.Drawing.FontStyle)style);
        }

        public double Measure(string text) {
            var size = helpGfx.MeasureString(text, sfont).ToSize();
            return (double)size.Width / size.Height;
        }

        static Graphics helpGfx = Graphics.FromImage(new Bitmap(1, 1));
        public void Render(string text) {
            var tex = MakeTexture(text);
            Draw.Save();
            Draw.Scale(Measure(text), 1);
            tex.Render();
            Draw.Load();
        }

        public Texture MakeTexture(string text) {
            var size = helpGfx.MeasureString(text, sfont).ToSize();
            var bitmap = new Bitmap(size.Width, size.Height);
            var gfx = Graphics.FromImage(bitmap);
            gfx.Clear(System.Drawing.Color.FromArgb(0, 0xff, 0xff, 0xff));
            gfx.TextRenderingHint = Smooth ?
                System.Drawing.Text.TextRenderingHint.AntiAlias :
                System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            gfx.DrawString(text, sfont, Brushes.White, 0, 0);
            var tex = new Texture(1, 1, Smooth);
            tex.Set(bitmap);
            return tex;
        }
    }

}