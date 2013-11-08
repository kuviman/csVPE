using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Shader {

        struct UniformTexture : IUniform {
            public RawGL.Texture tex;
            public void Set(int loc, ref int textures) {
                GL.ActiveTexture((TextureUnit)((int)TextureUnit.Texture0 + textures));
                GL.BindTexture(TextureTarget.Texture2D, tex);
                GL.Uniform1(loc, textures);
                textures++;
            }
        }

        /// <summary>
        /// Set a uniform texture variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="texture">Texture value.</param>
        public void SetTexture(string name, Texture texture) {
            uniforms[Loc(name)] = new UniformTexture { tex = texture.tex };
        }

    }

}