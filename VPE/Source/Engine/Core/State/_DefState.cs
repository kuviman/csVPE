using System;

namespace VitPro.Engine {

	public abstract class State : IState {

		bool closed = false;
		public bool Closed { get { return closed; } }
		public void Close() { closed = true; }

		public virtual void Update(double dt) { }
		public virtual void Render() { }

	}

}