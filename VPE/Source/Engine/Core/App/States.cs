using System;

namespace VitPro.Engine {

	partial class App {

		/// <summary>
		/// Gets current state.
		/// </summary>
		public static IState CurrentState { get; private set; }

		/// <summary>
		/// Start the application.
		/// </summary>
		/// <param name="startState">Starting state.</param>
		public static void Run(IState startState) {
			CurrentState = startState;
			Window.Run();
		}

	}

}