using System;
using UnityEngine;

namespace Timers
{
    public class SecondsTimer : Timer
    {
        protected override float TickTime { get { return base.interval; } }

        public override float Interval
        {
            get { return base.Interval; }
            set
            {
                base.Interval = value;
                base.waitFor = new WaitForSeconds(value);
            }
        }

        public SecondsTimer(float interval = 1.0f) : base ()
        {
            this.Interval = interval;
        }
    }
}
