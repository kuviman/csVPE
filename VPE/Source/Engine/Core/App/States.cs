using System;
using System.Collections.Generic;

namespace VitPro.Engine {

	partial class App {

		public static IState MainState { get; private set; }

		static bool _closed = false;

		/// <summary>
		/// Gets whether application is done.
		/// </summary>
		public static bool Closed { get { return _closed; } set { _closed = value; } }

		/// <summary>
		/// Kill the application.
		/// </summary>
		public static void Kill() {
			MainState.Close();
			Closed = true;
		}

		/// <summary>
		/// Start the application.
		/// </summary>
		/// <param name="mainState">Main state.</param>
		public static void Run(IState mainState) {
			try {
				MainState = mainState;
				Window.Run();
			} finally {
				Closed = true;
			}
		}

	}

}