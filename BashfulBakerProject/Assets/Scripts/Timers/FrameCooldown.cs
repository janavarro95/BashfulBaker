using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Timers
{
    /// <summary>
    /// Class that handles cooldowns based on update frames.
    /// </summary>
    public class FrameCooldown:CooldownBase
    {
        /// <summary>
        /// The frame timer to contol the cooldown.
        /// </summary>
        public FrameTimer timer;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="NumberOfFrames">The number of frames for the timer until it expires.</param>
        /// <param name="Value">The value for the cooldown.</param>
        /// <param name="DecrementAmount">The value to decrement the cooldown each time the timer expires.</param>
        public FrameCooldown(int NumberOfFrames, double Value, double DecrementAmount) : base(Value, DecrementAmount)
        {
            this.timer = new FrameTimer(NumberOfFrames,decrementCoolDown,true);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Timer">The timer for the cooldown.</param>
        /// <param name="value">The max value for the cooldown.</param>
        /// <param name="decrementValue">How much to decrement the cool down each time time timer expires.</param>
        public FrameCooldown(FrameTimer Timer,double value, double decrementValue) : base(value,decrementValue)
        {
            this.timer = Timer;
            this.timer.autoRestart = true;
            this.timer.onFinished = this.decrementCoolDown;
        }

        /// <summary>
        /// Tick the frame timer down one value.
        /// </summary>
        public override void tick()
        {
            this.timer.tick();
        }

        /// <summary>
        /// Tick the frame timer down one value.
        /// </summary>
        public void Update()
        {
            tick();
        }

    }
}
