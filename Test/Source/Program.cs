using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	Camera cam = new Camera(2);

	public override void Render() {
		Draw.Clear(Color.Black);

		Draw.Save();
		cam.Apply();

		Draw.Circle(Vec2.Zero, 0.1, Color.Red);
		Draw.Circle(0.5, 0.5, 0.2);

		Draw.Load();
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