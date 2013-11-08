using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    [Serializable]
    class TexturePart : ITexture {
        public TexturePart(Texture baseTexture, double x, double y, double sx, double sy)
            : this(baseTexture, new Vec2(x, y), new Vec2(sx, sy)) { }
        public TexturePart(Texture baseTexture, Vec2 origin, Vec2 size) {
            Base = baseTexture;
            Origin = origin;
            Size = size;
        }

        Texture Base;
        Vec2 Origin, Size;

        public void Render() {
            Base.Render(Origin, Size);
        }

        public ITexture SubTexture(double x, double y, double sx, double sy) {
            return new TexturePart(Base, Origin + Vec2.CompMult(new Vec2(x, y), Size), Vec2.CompMult(new Vec2(sx, sy), Size));
        }
    }

    partial class Texture {
        public ITexture SubTexture(double x, double y, double sx, double sy) {
            return new TexturePart(this, x, y, sx, sy);
        }
    }

}