using System;
using System.Collections.Generic;

namespace VitPro.Engine {

	public class StateManager : State {

		/// <summary>
		/// Gets current state.
		/// </summary>
		public IState CurrentState { get; private set; }

		Stack<IState> stateStack = new Stack<IState>();

		/// <summary>
		/// Push a state into state stack, after it closes, current will continue.
		/// </summary>
		/// <param name="state">State to push.</param>
		public void PushState(IState state) {
			stateStack.Push(state);
		}

		/// <summary>
		/// Sets the next state.
		/// </summary>
		public IState NextState {
			set {
				if (stateStack.Count > 0) {
					stateStack.Pop();
					stateStack.Push(value);
				} else
					throw new EngineError("No state is current yet");
			}
		}

		public override void Update(double dt) {
			base.Update(dt);
			while (stateStack.Count > 0 && stateStack.Peek().Closed)
				stateStack.Pop();
			CurrentState = stateStack.Count > 0 ? stateStack.Peek() : null;
			if (CurrentState != null) {
				var realState = CurrentState as State;
				if (realState != null)
					realState.StateManager = this;
				CurrentState.Update(dt);
			} else
				Close();
		}

		public override void Render() {
			base.Render();
			if (CurrentState != null)
				CurrentState.Render();
		}

		public override void KeyDown(Key key) {
			base.KeyDown(key);
			if (CurrentState != null)
				CurrentState.KeyDown(key);
		}

		public override void KeyUp(Key key) {
			base.KeyUp(key);
			if (CurrentState != null)
				CurrentState.KeyUp(key);
		}

		public override void MouseDown(MouseButton button, Vec2 pos) {
			base.MouseDown(button, pos);
			if (CurrentState != null)
				CurrentState.MouseDown(button, pos);
		}

		public override void MouseMove(Vec2 pos) {
			base.MouseMove(pos);
			if (CurrentState != null)
				CurrentState.MouseMove(pos);
		}

		public override void MouseUp(MouseButton button, Vec2 pos) {
			base.MouseUp(button, pos);
			if (CurrentState != null)
				CurrentState.MouseUp(button, pos);
		}

		public StateManager(IState startState, params IState[] states) {
			for (int i = states.GetLength(0) - 1; i >= 0; i--)
				PushState(states[i]);
			PushState(startState);
		}

	}

}