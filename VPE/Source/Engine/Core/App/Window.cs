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

	}

}