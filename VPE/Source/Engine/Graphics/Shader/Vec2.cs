using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Shader {

        struct UniformVec2 : IUniform {
            public double X, Y;
            public void Set(int loc, ref int textures) {
                GL.Uniform2(loc, (float)X, (float)Y);
            }
        }

        /// <summary>
        /// Set a uniform vec2 variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public void SetVec2(string name, double x, double y) {
            uniforms[Loc(name)] = new UniformVec2 { X = x, Y = y };
        }

        /// <summary>
        /// Set a uniform vec2 variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="v">Vec2 value.</param>
        public void SetVec2(string name, Vec2 v) {
            SetVec2(name, v.X, v.Y);
        }

    }

}