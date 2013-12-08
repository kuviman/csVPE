using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Audio.OpenAL;

namespace VitPro.Engine
{

    [Serializable]
    public partial class Sound
    {
        [NonSerialized]
        int id;

        int channels, bits_per_sample, sample_rate;
        byte[] sound_data;

        [NonSerialized]
        List<int> srcs;
        [NonSerialized]
        int i;
        const int MaxSources = 20;

        public Sound(string path)
        {
            sound_data = LoadWave(File.Open(path, FileMode.Open),
                out channels, out bits_per_sample, out sample_rate);
            Init(new System.Runtime.Serialization.StreamingContext());
        }

        [System.Runtime.Serialization.OnDeserialized]
        void Init(System.Runtime.Serialization.StreamingContext context)
        {
            id = AL.GenBuffer();
            AL.BufferData(id, GetSoundFormat(channels, bits_per_sample),
                sound_data, sound_data.Length, sample_rate);
            srcs = new List<int>();
            i = 0;
        }

        public void Play(double volume = 1, bool looped = false)
        {
            var src = GenSrc();
            AL.Source(src, ALSourcei.Buffer, id);
            AL.Source(src, ALSourceb.Looping, looped);
            AL.Source(src, ALSourcef.Gain, (float)volume);
            AL.SourcePlay(src);
        }
        public void PlayPos(Vec2 pos, double volume = 1)
        {
            PlayPos(pos.X, pos.Y, volume);
        }
        public void PlayPos(double x, double y, double volume = 1)
        {
            var src = GenSrc();
            //AL.Source(src, ALSourcef.ReferenceDistance, (float)ListenerZ);
            AL.Source(src, ALSourcef.RolloffFactor, (float)RolloffFactor);
            AL.Source(src, ALSource3f.Position, (float)x, (float)y, 0);
            AL.Source(src, ALSourcei.Buffer, id);
            AL.Source(src, ALSourcef.Gain, (float)volume);
            AL.SourcePlay(src);
        }

        int GenSrc()
        {
            var src = AL.GenSource();
            if (i < srcs.Count)
            {
                AL.DeleteSource(srcs[i]);
                srcs[i] = src;
            }
            else
                srcs.Add(src);
            i = (i + 1) % MaxSources;
            return src;
        }

        public void Stop()
        {
            foreach (var src in srcs)
            {
                AL.SourceStop(src);
                AL.DeleteSource(src);
            }
            srcs.Clear();
            i = 0;
        }
    }

}