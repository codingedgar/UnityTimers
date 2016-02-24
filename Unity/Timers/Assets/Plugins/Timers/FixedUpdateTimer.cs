using UnityEngine;

namespace Timers
{
    public class FixedUpdateTimer : Timer
    {

        protected override float TickTime { get { return Time.fixedDeltaTime; } }

        public FixedUpdateTimer() : base()
        {
            this.waitFor = new WaitForFixedUpdate();
        }
    }
}
