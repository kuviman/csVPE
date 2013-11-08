using System;
using System.Collections.Generic;
using Matrix = OpenTK.Matrix4;

namespace VitPro.Engine {

    partial class Draw {

        static void Mult(Matrix matrix) {
            CurrentState.Matrix = matrix * CurrentState.Matrix;
        }

        /// <summary>
        /// Set current model's center points.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public static void Align(double x, double y) {
            Translate(-x, -y);
        }

        /// <summary>
        /// Set current model's center points.
        /// </summary>
        public static void Align(Vec2 v) {
            Translate(-v);
        }

        /// <summary>
        /// Translate current model by the given vector.
        /// </summary>
        /// <param name="x">Translation along x axis.</param>
        /// <param name="y">Translation along y axis.</param>
        public static void Translate(double x, double y) {
            Mult(Matrix.CreateTranslation((float)x, (float)y, 0));
        }

        /// <summary>
        /// Translate current model by the given vector.
        /// </summary>
        public static void Translate(Vec2 v) {
            Translate(v.X, v.Y);
        }

        /// <summary>
        /// Rotate current model by the given angle.
        /// </summary>
        /// <param name="a">Rotation angle in radians.</param>
        public static void Rotate(double a) {
            Mult(Matrix.CreateRotationZ((float)a));
        }

        /// <summary>
        /// Scale current model.
        /// </summary>
        /// <param name="kx">Scale along x axis.</param>
        /// <param name="ky">Scale along y axis.</param>
        public static void Scale(double kx, double ky) {
            Mult(Matrix.Scale((float)kx, (float)ky, 1));
        }
        /// <summary>
        /// Scale current model.
        /// </summary>
        /// <param name="k"></param>
        public static void Scale(double k) {
            Scale(k, k);
        }

        /// <summary>
        /// Change color of the current model (multiply).
        /// </summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        public static void Color(double r, double g, double b, double a = 1) {
            Color(new Color(r, g, b, a));
        }

        /// <summary>
        /// Change color of the current model (multiply).
        /// </summary>
        public static void Color(Color color) {
            CurrentState.color *= color;
        }

    }

}