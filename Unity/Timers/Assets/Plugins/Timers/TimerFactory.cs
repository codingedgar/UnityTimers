
namespace Timers
{
    public class TimerFactory
    {
        public static Timer CreateTimer(TimerType type = TimerType.EndOfFrame, float interval = 0.0f)
        {
            switch (type)
            {
                case TimerType.Seconds:
                    return new SecondsTimer(interval);
                case TimerType.EndOfFrame:
                    return new EndOfFrameTimer(interval);
                case TimerType.FixedUpdate:
                    return new FixedUpdateTimer(interval);
                default:
                    return new EndOfFrameTimer(interval);
            }
        }
        public static Timer CreateTimer(object caller, TimerType type = TimerType.EndOfFrame, float interval = 0.0f)
        {
            Timer temp = null;

            temp = CreateTimer(type, interval);
            temp.caller = caller;

            return temp;
        }
    }
}