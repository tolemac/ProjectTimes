using System;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectTimes.Infrastructure
{
    public class ActionTimer
    {
        private readonly Timer _timer = new();

        private readonly Func<Task>? _handlerAction;

        public bool Enabled { get; private set; }

        public ActionTimer(Func<Task>? handlerAction, int milliseconds)
        {
            _handlerAction = handlerAction;

            _timer.Interval = milliseconds;
            _timer.Elapsed += _timerTick;
        }


        public void Start()
        {
            Enabled = true;

            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            
            _timer.Start();
        }

        public void Stop()
        {
            Enabled = false;
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        private async void _timerTick(object? sender, EventArgs e)
        {
            if (Enabled) 
            { 
                _timer.Stop();

                if (_handlerAction is not null)
                {
                    await _handlerAction();
                }

                if (Enabled)
                {
                    _timer.Start();
                }
            }
        }
    }
}
