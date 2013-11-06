using System;

namespace VitPro.Engine {

	public interface IState {

		bool Closed { get; }
		void Close();

		void Update(double dt);
		void Render();

	}

}