using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoGameUtils.Diagnostics
{
    /// <summary>
    /// Reports back on the game's frames per second.
    /// </summary>
    /// <remarks>
    /// Adapted from this StackOverflow answer: http://stackoverflow.com/a/20679895/848199
    /// </remarks>
    public class FPSCounter
    {
        public long TotalFrames { get; private set; } = 0;
        public float CurrentFPS { get; private set; }
        public float AverageFPS { get; private set; }

        public static int MAXIMUM_SAMPLES { get; set; } = 100;

        private Queue<float> FPSQueue { get; set; } = new Queue<float>(MAXIMUM_SAMPLES);

        public void Update(GameTime gameTime)
        {
            CurrentFPS = (float) (TotalFrames / gameTime.TotalGameTime.TotalSeconds);

            if (FPSQueue.Count > MAXIMUM_SAMPLES)
            {
                FPSQueue.Dequeue();
            }

            FPSQueue.Enqueue(CurrentFPS);

            AverageFPS = FPSQueue.Average();

            TotalFrames++;
        }
    }
}