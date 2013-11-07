using System;
using System.Collections.Generic;

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

		static Stack<IState> stateStack = new Stack<IState>();

		/// <summary>
		/// Push a state into state stack, after it closes, current will continue.
		/// </summary>
		/// <param name="state">State to push.</param>
		public static void PushState(IState state) {
			stateStack.Push(state);
		}

		/// <summary>
		/// Sets the next state.
		/// </summary>
		public static IState NextState {
			set {
				if (stateStack.Count > 0) {
					stateStack.Pop();
					stateStack.Push(value);
				} else
					throw new EngineError("No state is current yet");
			}
		}

		/// <summary>
		/// Kill the application.
		/// </summary>
		public static void Kill() {
			stateStack.Clear();
		}

		static void UpdateStates() {
			while (stateStack.Count > 0 && stateStack.Peek().Closed)
				stateStack.Pop();
			CurrentState = stateStack.Count > 0 ? stateStack.Peek() : null;
		}

		/// <summary>
		/// Start the application.
		/// </summary>
		/// <param name="startState">Starting state.</param>
		/// <param name="states">State stack remains.</param>
		public static void Run(IState startState, params IState[] states) {
			try {
				for (int i = states.GetLength(0) - 1; i >= 0; i--)
					PushState(states[i]);
				PushState(startState);
				Window.Run();
			} finally {
				_closed = true;
			}
		}

	}

}