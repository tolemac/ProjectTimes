using Microsoft.Win32;
using ProjectTimes.Domain;

namespace ProjectTimes
{
    public class SystemEventsHandler : BeginEndWorkSignaler
    {
        public SystemEventsHandler()
        {
            SystemEvents.SessionSwitch += SystemEventsSessionSwitch;
        }

        private async void SystemEventsSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (Enabled)
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                {
                    await SendEndWorkSignal();
                }
                if (e.Reason == SessionSwitchReason.SessionUnlock)
                {
                    await SendBeginWorkSignal();
                }
            }
        }
    }
}
