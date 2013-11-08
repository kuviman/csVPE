using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	public override void Render() {
		Draw.Clear(Color.Black);
		Draw.Circle(Vec2.Zero, 0.1, Color.Red);
		Draw.Circle(0.5, 0.5, 0.2);
	}

	public override void KeyDown(Key key) {
		base.KeyDown(key);
		if (key == Key.Escape)
			Close();
	}

}

class Program {
	static void Main(string[] args) {
		App.Run(new Test());
	}
}