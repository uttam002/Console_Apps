using System.Diagnostics;

namespace FlashcardApp.Utils
{
    public class Timer
    {
        private Stopwatch _stopwatch;

        public Timer()
        {
            _stopwatch = new Stopwatch();
        }

        public void Start() => _stopwatch.Start();
        public void Stop() => _stopwatch.Stop();
        public double ElapsedSeconds => _stopwatch.Elapsed.TotalSeconds;

        public void Reset() => _stopwatch.Reset();
    }
}
