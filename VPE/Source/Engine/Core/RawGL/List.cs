using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class RawGL {

        public class List : IDisposable {
            int list;

            public List() {
                App.Init();
                list = GL.GenLists(1);
            }

            public static implicit operator int(List list) {
                return list.list;
            }

            bool disposed = false;
            
            public void Dispose() {
                if (disposed)
                    return;
                Lists.Enqueue(list);
                disposed = true;
            }

            ~List() {
                Dispose();
            }
        }

    }

}