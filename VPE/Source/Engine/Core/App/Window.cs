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

		/// <summary>
		/// Gets or sets whether application is in fullscreen mode.
		/// </summary>
		public static bool Fullscreen {
			get {
				return Window.WindowState == WindowState.Fullscreen;
			}
			set {
				Window.WindowState = value ? WindowState.Fullscreen : WindowState.Normal;
			}
		}

		/// <summary>
		/// Gets or sets window title.
		/// </summary>
		public static string Title {
			get { return Window.Title; }
			set { Window.Title = value; }
		}

		/// <summary>
		/// Gets window width.
		/// </summary>
		public static int Width { get { return Window.Width; } }

		/// <summary>
		/// Gets window height.
		/// </summary>
		public static int Height { get { return Window.Height; } }

		/// <summary>
		/// Gets the window aspect ratio.
		/// </summary>
		public static double Aspect { get { return (double)Width / (double)Height; } }

	}

}