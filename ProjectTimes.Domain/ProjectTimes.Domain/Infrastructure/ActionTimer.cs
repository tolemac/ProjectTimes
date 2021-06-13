using System;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectTimes.Infrastructure
{
    public class ActionTimer
    {
        private readonly Timer _timer = new();

        private readonly Func<Task>? _handlerAction;
        private readonly int _milliseconds;

        public bool Enabled { get; private set; }

        public ActionTimer(Func<Task>? handlerAction, int milliseconds)
        {
            _handlerAction = handlerAction;
            _milliseconds = milliseconds;
        }


        public void Start()
        {
            Enabled = true;

            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            _timer.Interval = _milliseconds;
            _timer.Elapsed += _timerTick;
            _timer.Start();
        }

        public void Stop()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            Enabled = false;
        }

        private async void _timerTick(object? sender, EventArgs e)
        {
            _timer.Stop();

            if (_handlerAction is not null)
            {
                await _handlerAction();
            }

            _timer.Start();
        }
    }
}
