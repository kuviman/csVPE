using System;
using System.Collections.Generic;

namespace VitPro.Engine
{
    public class AnimatedTexture : IUpdateable, IRenderable
    {
        private List<Tuple<Texture, double>> Textures = new List<Tuple<Texture, double>>();
        private List<Tuple<Texture, double>>.Enumerator CurrentTexture;
        private double CurrentTime = 0;
        private double Timer = 0, TotalTime = 0;

        public AnimatedTexture() { }

        public AnimatedTexture(Texture tex)
        {
            Textures.Add(new Tuple<Texture, double>(tex, 0));
            CurrentTexture = Textures.GetEnumerator();
            CurrentTexture.MoveNext();
        }

        public AnimatedTexture Add(Texture tex, double time)
        {
            Textures.Add(new Tuple<Texture, double>(tex, time));
            CurrentTexture = Textures.GetEnumerator();
            CurrentTexture.MoveNext();
            TotalTime += time;
            return this;
        }

        public void Render()
        {
            CurrentTexture.Current.Item1.Render();
        }

        public void RenderToPosAndSize(Vec2 Pos, Vec2 Size)
        {
            Draw.Save();
            Draw.Translate(Pos);
            Draw.Scale(Size.X, Size.Y);
            Draw.Scale(2);
            Draw.Align(0.5, 0.5);
            Render();
            Draw.Load();
        }

        public void Update(double dt)
        {
            Timer += dt;
            if (Textures.Count < 2)
                return;
            CurrentTime += dt;
            if (CurrentTime > CurrentTexture.Current.Item2)
            {
                CurrentTime = 0;
                if (!CurrentTexture.MoveNext())
                {
                    CurrentTexture.Dispose();
                    CurrentTexture = Textures.GetEnumerator();
                    CurrentTexture.MoveNext();
                }
            }
        }

        public double GetTotalTime
        {
            get
            {
                return TotalTime;
            }
        }

        public double GetTime
        {
            get
            {
                return Timer;
            }
        }

        public bool HasLooped { get { return GetTime > GetTotalTime; } }
    }
}