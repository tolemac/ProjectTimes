using System;
using System.Threading.Tasks;

namespace ProjectTimes.Domain
{
    public class BeginEndWorkSignaler
    {
        public bool Enabled { get; private set; } = false;

        private Func<Task>? _endWorkAction = null;
        private Func<Task>? _beginWorkAction = null;

        public void SetActions(Func<Task>? beginWorkAction, Func<Task>? endWorkAction)
        {
            _beginWorkAction = beginWorkAction;
            _endWorkAction = endWorkAction;
        }

        public void Start()
        {
            Enabled = true;
        }

        public void Stop()
        {
            Enabled = false;
        }

        protected async Task SendBeginWorkSignal()
        {
            if (_endWorkAction is not null)
            {
                await _endWorkAction();
            }
        }

        protected async Task SendEndWorkSignal()
        {
            if (_beginWorkAction is not null)
            {
                await _beginWorkAction();
            }
        }
    }
}
