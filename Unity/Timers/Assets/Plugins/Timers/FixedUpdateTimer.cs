using UnityEngine;

namespace Timers
{
    public class FixedUpdateTimer : Timer
    {

        protected override float TickTime { get { return Time.fixedDeltaTime; } }

        public FixedUpdateTimer(float interval) : base(interval)
        {
            this.waitFor = new WaitForFixedUpdate();
        }
    }
}
