using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	Camera cam = new Camera(2);
	Texture tex = new Texture(16, 16);

	public Test() {
		for (int x = 0; x < tex.Width; x++) {
			for (int y = 0; y < tex.Height; y++) {
				tex[x, y] = Color.FromHSV(GRandom.NextDouble(), 1, 1);
			}
		}
	}

	public override void Render() {
		Draw.Clear(Color.Black);

		Draw.Save();
		cam.Apply();

		Draw.Circle(Vec2.Zero, 0.1, Color.Red);
		Draw.Circle(0.5, 0.5, 0.2);

		Draw.Save();
		Draw.Translate(-0.5, -0.5);
		Draw.Rotate(App.Time);
		Draw.Scale(0.5);
		Draw.Align(0.5, 0.5);
		tex.Render();
		Draw.Load();

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