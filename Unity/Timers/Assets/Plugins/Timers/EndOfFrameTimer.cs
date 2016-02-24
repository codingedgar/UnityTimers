using UnityEngine;

namespace Timers
{
    public class EndOfFrameTimer : Timer
    {
        protected override float TickTime { get { return Time.deltaTime; } }
        
        public EndOfFrameTimer() : base()
        {
            this.waitFor = new WaitForEndOfFrame();
        }

    }
}
