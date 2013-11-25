using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	Camera cam = new Camera(2);
	Texture tex = new Texture(16, 16);
	Texture tex2 = new Texture("../Data/Textures/Temp.png");
	Texture tmp = new Texture(120, 90);

	//SystemFont font = new SystemFont("Times New Roman", 72, FontStyle.Bold | FontStyle.Strikeout);
	Font font = new Font("../Data/font.ttf", 32);

	double tm = 0;

	public Test() {
		for (int x = 0; x < tex.Width; x++) {
			for (int y = 0; y < tex.Height; y++) {
				tex[x, y] = Color.FromHSV(GRandom.NextDouble(), 1, 1);
			}
		}
		font.Smooth = false;
	}

	public override void Update(double dt) {
		base.Update(dt);
		tm += dt;
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
		Draw.Rotate(tm);
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
		if (key == Key.Space)
			StateManager.PushState(new Test());
	}

}

class MyManager : StateManager {
	public MyManager(State a) : base(a) {
	}
	double t = 1;

	public override void Update(double dt) {
		base.Update(dt);
		t -= 5 * dt;
		if (t < 0)
			t = 0;
	}

	public override void StateChanged() {
		base.StateChanged();
		t = 1;
		if (tex != null) {
			back = tex.Copy();
		}
	}

	Texture tex = null, back = null;

	public override void Render() {
		if (tex == null || tex.Width != Draw.Width || tex.Height != Draw.Height)
			tex = new Texture(Draw.Width, Draw.Height);

		Draw.BeginTexture(tex);

		base.Render();

		Draw.EndTexture();

		Draw.Save();
		Draw.Scale(2);
		Draw.Align(0.5, 0.5);

		tex.Render();
		if (back != null) {
			Draw.Color(1, 1, 1, t);
			back.Render();
		}

		Draw.Load();
	}
}

class Program {
	static void Main(string[] args) {
		//App.Fullscreen = true;
		App.Run(new MyManager(new Test()));
	}
}