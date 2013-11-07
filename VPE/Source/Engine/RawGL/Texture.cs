using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class RawGL {

        public class Texture : IDisposable {
            int texture;

            public Texture() {
                App.Init();
                texture = GL.GenTexture();
            }

            public static implicit operator int(Texture texture) {
                return texture.texture;
            }

            bool disposed = false;
            
            public void Dispose() {
                if (disposed)
                    return;
                Textures.Enqueue(texture);
                disposed = true;
            }

            ~Texture() {
                Dispose();
            }
        }

    }

}