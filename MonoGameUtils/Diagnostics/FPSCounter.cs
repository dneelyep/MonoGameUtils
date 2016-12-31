using System.Collections.Generic;
using System.Linq;

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
        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float CurrentFPS { get; private set; }
        public float AverageFPS { get; private set; }

        public const int MAXIMUM_SAMPLES = 100;
        private Queue<float> FPSQueue { get; set; }

        public void Update(float deltaTime)
        {
            CurrentFPS = 1.0f / deltaTime;

            if (FPSQueue.Count > MAXIMUM_SAMPLES)
            {
                FPSQueue.Dequeue();
            }

            FPSQueue.Enqueue(CurrentFPS);

            AverageFPS = FPSQueue.Average();

            TotalFrames++;
            TotalSeconds += deltaTime;
        }
    }
}