using System;

namespace VitPro.Engine {

	public abstract class State : IState {

		bool closed = false;
		public bool Closed { get { return closed; } }
		public void Close() { closed = true; }

		public virtual void Update(double dt) { }
		public virtual void Render() { }

		public virtual void KeyDown(Key key) { }
		public virtual void KeyUp(Key key) { }

		public virtual void MouseDown(MouseButton button, Vec2 pos) { }
		public virtual void MouseUp(MouseButton button, Vec2 pos) { }
		public virtual void MouseMove(Vec2 pos) { }

	}

}