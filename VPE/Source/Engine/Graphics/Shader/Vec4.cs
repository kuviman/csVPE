using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Shader {

        struct UniformVec4 : IUniform {
            public double X, Y, Z, W;
            public void Set(int loc, ref int textures) {
                GL.Uniform4(loc, (float)X, (float)Y, (float)Z, (float)W);
            }
        }

        /// <summary>
        /// Set a uniform vec4 variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        public void SetVec4(string name, double x, double y, double z, double w) {
            uniforms[Loc(name)] = new UniformVec4 { X = x, Y = y, Z = z, W = w };
        }

        /// <summary>
        /// Set a uniform color(vec4) variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="color">Color value.</param>
        public void SetColor(string name, Color color) {
            SetVec4(name, color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Set a uniform color(vec4) variable.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        public void SetColor(string name, double r, double g, double b, double a = 1) {
            SetVec4(name, r, g, b, a);
        }

    }

}