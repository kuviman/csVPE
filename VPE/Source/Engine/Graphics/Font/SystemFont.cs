using System;
using System.Drawing;

namespace VitPro.Engine {

    [Serializable]
    public class SystemFont : IFont {
        public bool Smooth = true;

        internal Font Font;
        public SystemFont(string family, double emSize, FontStyle style = FontStyle.Regular) {
            Font = new Font(family, (float)emSize, (System.Drawing.FontStyle)style);
        }

        public double Measure(string text) {
            var size = helpGfx.MeasureString(text, Font).ToSize();
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
            var size = helpGfx.MeasureString(text, Font).ToSize();
            var bitmap = new Bitmap(size.Width, size.Height);
            var gfx = Graphics.FromImage(bitmap);
            gfx.Clear(System.Drawing.Color.FromArgb(0, 0xff, 0xff, 0xff));
            gfx.TextRenderingHint = Smooth ?
                System.Drawing.Text.TextRenderingHint.AntiAlias :
                System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            gfx.DrawString(text, Font, Brushes.White, 0, 0);
            var tex = new Texture(1, 1, Smooth);
            tex.Set(bitmap);
            return tex;
        }
    }

}