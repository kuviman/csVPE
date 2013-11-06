using System;
using OpenTK;

namespace VitPro.Engine {

	partial class App {

		internal static GameWindow Window = new GameWindow();

		static void InitWindow() {
			Window.WindowBorder = WindowBorder.Fixed;

			InitEvents();

			Title = "VPE application";
		}

		public static string Title {
			get { return Window.Title; }
			set { Window.Title = value; }
		}

		public static int Width { get { return Window.Width; } }
		public static int Height { get { return Window.Height; } }

	}

}