using System;

namespace VitPro.Engine {

	public abstract class State : IState {

		bool closed = false;

		public StateManager StateManager { get; internal set; }

		/// <summary>
		/// Gets whether state has been closed.
		/// </summary>
		public bool Closed { get { return closed; } }

		/// <summary>
		/// Close the state.
		/// </summary>
		public void Close() { closed = true; }

		/// <summary>
		/// Update the state.
		/// </summary>
		/// <param name="dt">Time since last update.</param>
		public virtual void Update(double dt) { }

		/// <summary>
		/// Render the state.
		/// </summary>
		public virtual void Render() { }

		/// <summary>
		/// Called when a key is being pressed.
		/// </summary>
		/// <param name="key">Pressed key.</param>
		public virtual void KeyDown(Key key) { }

		/// <summary>
		/// Called when a key is being released.
		/// </summary>
		/// <param name="key">Released key.</param>
		public virtual void KeyUp(Key key) { }

		/// <summary>
		/// Called when a mouse button is being pressed.
		/// </summary>
		/// <param name="button">Pressed button.</param>
		/// <param name="pos">Event position.</param>
		public virtual void MouseDown(MouseButton button, Vec2 pos) { }

		/// <summary>
		/// Called when a mouse button is being released.
		/// </summary>
		/// <param name="button">Pressed button.</param>
		/// <param name="pos">Event position.</param>
		public virtual void MouseUp(MouseButton button, Vec2 pos) { }

		/// <summary>
		/// Called when mouse is being moved.
		/// </summary>
		/// <param name="pos">Event position.</param>
		public virtual void MouseMove(Vec2 pos) { }

        public virtual void MouseWheel(double delta) { }

	}

}