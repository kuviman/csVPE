using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	static Random rnd = new Random();

	Color backColor = new Color(0, rnd.NextDouble(), 1);
	double t = 0;

	public override void Update(double dt) {
		base.Update(dt);
		t += dt;
		backColor = new Color(Math.Sin(t) / 2 + 0.5, backColor.G, 1);
	}
	public override void Render() {
		Draw.Clear(backColor);
	}

	public override void KeyDown(Key key) {
		base.KeyDown(key);
		if (key == Key.Escape)
			Close();
		if (key == Key.Space)
			App.PushState(new Test());
	}
}

class Program {
	static void OnClose() {
		Console.WriteLine("Closing window");
	}

	static void Main(string[] args) {
		App.OnClose = OnClose;
		App.AutoQuit = false;
		App.Run(new Test());
	}
}