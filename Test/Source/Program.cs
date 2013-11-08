using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	Camera cam = new Camera(2);
	Texture tex = new Texture(16, 16);
	Texture tex2 = new Texture("../Data/Textures/Temp.png");
	Texture tmp = new Texture(120, 90);

	SystemFont font = new SystemFont("Times New Roman", 72, FontStyle.Bold | FontStyle.Strikeout);

	public Test() {
		for (int x = 0; x < tex.Width; x++) {
			for (int y = 0; y < tex.Height; y++) {
				tex[x, y] = Color.FromHSV(GRandom.NextDouble(), 1, 1);
			}
		}
		font.Smooth = false;
	}

	public override void Render() {
		Draw.BeginTexture(tmp);
		Draw.Clear(Color.Blue);

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

		Draw.Save();
		Draw.Translate(0.5, 0.5);
		Draw.Scale(0.3);
		Draw.Align(0.5, 0.5);
		tex2.Render();
		Draw.Load();

		Draw.Load();

		Draw.EndTexture();

		Draw.Save();
		Draw.Translate(-1, -1);
		Draw.Scale(2);
		tmp.Render();
		Draw.Load();

		Draw.Save();
		Draw.Color(0, 0, 0);
		Draw.Scale(0.3);
		Draw.Scale(font.Measure("TEXT"), 1);
		var t = font.MakeTexture("TEXT");
		t.SubTexture(0, 0, 2.4, 1).Render();
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