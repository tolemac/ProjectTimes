using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace ProjectTimes
{
    public class SystemEventsHandler
    {
        public bool Enabled { get; private set; } = false;

        private Func<Task>? _sessionUnlockHandlerAction = null;
        private Func<Task>? _sessionLockHandlerAction = null;

        public SystemEventsHandler(Func<Task>? sessionLockHandlerAction, Func<Task>? sessionUnlockHandlerAction)
        {
            _sessionLockHandlerAction = sessionLockHandlerAction;
            _sessionUnlockHandlerAction = sessionUnlockHandlerAction;
            SystemEvents.SessionSwitch += SystemEventsSessionSwitch;
        }

        public void Start()
        {
            Enabled = true;
        }

        public void Stop()
        {
            Enabled = false;
        }

        private async void SystemEventsSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (Enabled)
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                {
                    if (_sessionLockHandlerAction is not null)
                    {
                        await _sessionLockHandlerAction();
                    }
                }
                if (e.Reason == SessionSwitchReason.SessionUnlock)
                {
                    if (_sessionUnlockHandlerAction is not null)
                    {
                        await _sessionUnlockHandlerAction();
                    }
                }
            }
        }
    }
}
