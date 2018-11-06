using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
namespace Assets.Scripts.Timers
{
    /// <summary>
    /// Just a simple wrapper class for C# Timers.
    /// </summary>
    public class CSTimer
    {
        /// <summary>
        /// The actual c# timer.
        /// </summary>
        public Timer timer;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="NumberOfMilliseconds">Number of milliseconds until the timer finishes.</param>
        /// <param name="AutoRestart">Should the timer loop?</param>
        /// <param name="OnFinished">What happens when the timer finishes.</param>
        public CSTimer(int NumberOfMilliseconds,bool AutoRestart,ElapsedEventHandler OnFinished)
        {
            timer = new Timer(NumberOfMilliseconds);
            timer.Elapsed += OnFinished;
            timer.AutoReset = AutoRestart;
        }

        /// <summary>
        /// Start the timer.
        /// </summary>
        public void start()
        {
            timer.Start();
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        public void stop()
        {
            timer.Stop();
        }

    }
}
