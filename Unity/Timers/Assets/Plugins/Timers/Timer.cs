using System;
using System.Collections;
using UnityEngine;

namespace Timers
{
    public abstract class Timer
    {
        #region Variables
        public object caller = null;
        private IEnumerator coroutine;
        private float elapsedTime = 0.0f;
        private TimerManager timerManager = null;

        protected YieldInstruction waitFor = null;
        protected abstract float TickTime { get; }
        protected float interval = 0.0f;

        public bool isRunning = false;
        public virtual float Interval { get { return interval; } set { this.interval = value; } }
        public bool AutoReset = false;

        #region Pause
        private bool isPaused = false;
        public bool IsPaused { get { return isPaused; } }
        #endregion
        #region Actions
        public Action ElapsedEvent;
        public Action DisposedEvent;
        #endregion
        #endregion

        #region Core

        public Timer(float interval)
        {
            this.timerManager = TimerManager.Instance;
            Interval = interval;
        }

        public void Start()
        {
            if (!this.isRunning)
            {
                this.stopped = false;
                this.coroutine = TimerMechanism();
                this.timerManager.StartCoroutine(this.coroutine);
            }
        }
        
        IEnumerator TimerMechanism()
        {
            this.isRunning = true;
            do
            {
                this.elapsedTime = 0.0f;
                do
                {
                    yield return waitFor;
                    if (!this.isPaused)
                    {
                        this.elapsedTime += TickTime;
                    }
                } while (interval > this.elapsedTime);
                this.ElapsedEvent.Trigger();
            } while (this.AutoReset);
            this.isRunning = false;
            this.DisposedEvent.Trigger();
        }

        #endregion

        bool stopped = false;
        public void Stop()
        {
            this.stopped = true;
            if (this.isRunning)
            {
                this.timerManager.StopCoroutine(this.coroutine);
                this.isRunning = false;
            }
        }

        #region Pause
        public void SetPause(bool value)
        {
            this.isPaused = value;
        }
        #endregion
    }
}