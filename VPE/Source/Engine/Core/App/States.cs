using System;

namespace VitPro.Engine {

	partial class App {

		public static IState CurrentState { get; private set; }

		public static void Run(IState startState) {
			CurrentState = startState;
			Window.Run();
		}

	}

}