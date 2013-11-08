using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	public override void Render() {
		Draw.Clear(Color.Black);
		Draw.Save();
		Draw.Color(Color.Green);
		Draw.Rotate(App.Time);
		Draw.Align(0.5, 0.5);
		Draw.Quad();
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