using System;

namespace VitPro.Engine {

	partial class Draw {

		static Shader ColorShader = new Shader(Shaders.Color);
		static Shader CircleShader = new Shader(Shaders.Circle);

		public static void Quad() {
			ColorShader.Render();
		}

		public static void Dot(double x, double y, double size, Color? color = null) {
			Dot(new Vec2(x, y), size, color);
		}

		public static void Dot(Vec2 pos, double size, Color? color = null) {
			Draw.Save();
			if (color.HasValue)
				Draw.Color(color.Value);
			Draw.Translate(pos);
			Draw.Scale(size);
			Draw.Align(0.5, 0.5);
			ColorShader.Render();
			Draw.Load();
		}

		public static void Circle(double x, double y, double r, Color? color = null) {
			Circle(new Vec2(x, y), r, color);
		}
		public static void Circle(Vec2 pos, double r, Color? color = null) {
			Draw.Save();
			if (color.HasValue)
				Draw.Color(color.Value);
			Draw.Translate(pos);
			Draw.Scale(r * 2);
			Draw.Align(0.5, 0.5);
			CircleShader.Render();
			Draw.Load();
		}

		public static void Rect(double x1, double y1, double x2, double y2, Color? color = null) {
			Draw.Save();
			if (color.HasValue)
				Draw.Color(color.Value);
			Draw.Translate(x1, y1);
			Draw.Scale(x2 - x1, y2 - y1);
			Draw.Quad();
			Draw.Load();
		}
		public static void Rect(Vec2 p1, Vec2 p2, Color? color = null) {
			Rect(p1.X, p1.Y, p2.X, p2.Y, color);
		}

	}

}