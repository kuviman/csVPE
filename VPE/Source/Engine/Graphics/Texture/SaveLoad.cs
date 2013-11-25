using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Texture {

        public Texture(string path, bool smooth = false)
            : this(smooth) {
            try {
                var bitmap = new Bitmap(path);
                Set(bitmap);
            } catch (Exception e) {
                throw new EngineError(string.Format("Could not load \"{0}\"", path), e);
            }
        }

        /// <summary>
        /// Save the texture to a file.
        /// </summary>
        /// <param name="path">File to save.</param>
        public void Save(string path) {
            ToBitmap().Save(path);
        }

        internal void Set(Bitmap bitmap) {
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                bitmap.Width, bitmap.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);

            Width = bitmap.Width;
            Height = bitmap.Height;

            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        internal Bitmap ToBitmap() {
            var bitmap = new Bitmap(Width, Height);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            var data = bitmap.LockBits(new Rectangle(0, 0, Width, Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.GetTexImage(TextureTarget.Texture2D, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);

            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bitmap;
        }

		public Texture Copy() {
			var tex = new Texture(this.Smooth);
			tex.Set(this.ToBitmap());
			return tex;
		}

    }

}