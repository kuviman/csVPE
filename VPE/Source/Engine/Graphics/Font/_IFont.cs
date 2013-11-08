namespace VitPro.Engine {

    public interface IFont {
        double Measure(string text);
        void Render(string text);
        Texture MakeTexture(string text);
    }

}