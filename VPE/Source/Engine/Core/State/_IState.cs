using System;

namespace VitPro.Engine {

	public interface IState : IRenderable, IUpdateable {

		/// <summary>
		/// Gets whether state has been closed.
		/// </summary>
		bool Closed { get; }

		/// <summary>
		/// Close the state.
		/// </summary>
		void Close();

		/// <summary>
		/// Called when a key is being pressed.
		/// </summary>
		/// <param name="key">Pressed key.</param>
		void KeyDown(Key key);

		/// <summary>
		/// Called when a key is being released.
		/// </summary>
		/// <param name="key">Released key.</param>
		void KeyUp(Key key);

		/// <summary>
		/// Called when a mouse button is being pressed.
		/// </summary>
		/// <param name="button">Pressed button.</param>
		/// <param name="pos">Event position.</param>
		void MouseDown(MouseButton button, Vec2 pos);

		/// <summary>
		/// Called when a mouse button is being released.
		/// </summary>
		/// <param name="button">Pressed button.</param>
		/// <param name="pos">Event position.</param>
		void MouseUp(MouseButton button, Vec2 pos);

		/// <summary>
		/// Called when mouse is being moved.
		/// </summary>
		/// <param name="pos">Event position.</param>
		void MouseMove(Vec2 pos);

	}

}