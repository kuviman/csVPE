using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Shader {

        struct UniformInt : IUniform {
            public int X;
            public void Set(int loc, ref int textures) {
                GL.Uniform1(loc, X);
            }
        }

        /// <summary>
        /// Set a uniform int variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        public void SetInt(string name, int x) {
            uniforms[Loc(name)] = new UniformInt { X = x };
        }

    }

}