using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Shader {

        struct UniformDouble : IUniform {
            public double X;
            public void Set(int loc, ref int textures) {
                GL.Uniform1(loc, (float)X);
            }
        }

        /// <summary>
        /// Set a uniform float variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        public void SetReal(string name, double x) {
            uniforms[Loc(name)] = new UniformDouble { X = x };
        }

    }

}