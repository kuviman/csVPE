using System;

namespace VitPro.Engine {

	partial class App {

		/// <summary>
		/// Gets current state.
		/// </summary>
		public static IState CurrentState { get; private set; }

		static bool _closed = false;

		/// <summary>
		/// Gets whether application is done.
		/// </summary>
		public static bool Closed { get { return _closed; } }

		/// <summary>
		/// Start the application.
		/// </summary>
		/// <param name="startState">Starting state.</param>
		public static void Run(IState startState) {
			try {
				CurrentState = startState;
				Window.Run();
			} finally {
				_closed = true;
			}
		}

	}

}