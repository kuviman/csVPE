using System;

namespace VitPro.Engine {

    public interface ITexture : IRenderable {
        ITexture SubTexture(double x, double y, double sx, double sy);
    }

}