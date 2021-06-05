using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTimes
{
    public class EndTimeTimer
    {
        private Timer _timer = new Timer();

        private Func<Task>? _handlerAction = null;

        public bool Enabled { get; private set; } = false;

        public EndTimeTimer(Func<Task>? handlerAction)
        {
            _handlerAction = handlerAction;
        }


        public void Start()
        {
            Enabled = true;

            _timer.Interval = 3000;
            _timer.Tick += _timerTick;
            _timer.Start();

        }

        public void Stop()
        {
            _timer.Stop();
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
