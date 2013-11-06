using System;

namespace VitPro.Engine {

	public interface IState {

		bool Closed { get; }
		void Close();

		void Update(double dt);
		void Render();

		void KeyDown(Key key);
		void KeyUp(Key key);

		void MouseDown(MouseButton button, Vec2 pos);
		void MouseUp(MouseButton button, Vec2 pos);
		void MouseMove(Vec2 pos);

	}

}