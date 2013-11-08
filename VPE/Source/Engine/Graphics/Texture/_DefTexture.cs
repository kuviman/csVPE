using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace VitPro.Engine {

    /// <summary>
    /// Represents a texture image.
    /// </summary>
    [Serializable]
    public partial class Texture : ITexture {

        [Serializable]
        struct ColorStruct {
            public byte r, g, b, a;
            public ColorStruct(Color c) {
                r = (byte)(c.R * 255);
                g = (byte)(c.G * 255);
                b = (byte)(c.B * 255);
                a = (byte)(c.A * 255);
            }
        }

        internal RawGL.Texture tex;

        static Texture() {
            App.Init();
        }

        /// <summary>
        /// Gets width of the texture.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets height of the texture.
        /// </summary>
        public int Height { get; private set; }

        internal Texture(bool smooth = false) {
            Init(smooth);
        }

        void Init(bool smooth) {
            tex = new RawGL.Texture();
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            Smooth = smooth;
        }

        public Texture(int width, int height, bool smooth = false)
            : this(smooth) {
            Width = width;
            Height = height;
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                Width, Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
        }

        /// <summary>
        /// Gets or sets texture's smooth parameter.
        /// </summary>
        public bool Smooth {
            get {
                GL.BindTexture(TextureTarget.Texture2D, tex);
                int filter;
                GL.GetTexParameter(TextureTarget.Texture2D, GetTextureParameter.TextureMinFilter, out filter);
                return (TextureMinFilter)filter == TextureMinFilter.Linear;
            }
            set {
                GL.BindTexture(TextureTarget.Texture2D, tex);
                var minFilter = value ? TextureMinFilter.Linear : TextureMinFilter.Nearest;
                var magFilter = value ? TextureMagFilter.Linear : TextureMagFilter.Nearest;
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)minFilter);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)magFilter);
            }
        }

        static Shader shader = new Shader(Shaders.Texture);

        internal void Render(Vec2 origin, Vec2 size) {
            shader.SetTexture("texture", this);
            shader.SetVec2("origin", origin);
            shader.SetVec2("size", size);
            shader.Render();
        }

        /// <summary>
        /// Render a quad with the texture.
        /// </summary>
        public void Render() {
            Render(Vec2.Zero, new Vec2(1, 1));
        }

    }

}