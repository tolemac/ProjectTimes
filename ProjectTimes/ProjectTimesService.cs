using ProjectTimes.Domain;
using ScopedInvocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTimes
{
    public class ProjectTimesService
    {
        private readonly Form1 _form;
        private readonly SystemEventsHandler _systemEvents;
        private readonly EndTimeTimer _endTimeTimer;
        private readonly IScopedInvocation<ProjectTimesEntriesService> _serviceInvocation;

        public ProjectTimesService(Form1 form, IScopedInvocation<ProjectTimesEntriesService> serviceInvocation)
        {
            _form = form;
            _systemEvents = new(() => SessionLockAsync(), () => SessionUnlockAsync());
            _endTimeTimer = new(() => SaveEndTimeAsync());
            _serviceInvocation = serviceInvocation;
        }

        internal Task SessionUnlockAsync()
        {
            // Disable events and timer.
            _endTimeTimer.Stop();
            _systemEvents.Stop();

            // Show start working dialog
            OpenWorkingForm();

            return Task.CompletedTask;

        }
        internal async Task SessionLockAsync()
        {
            // Update current work end time
            await SaveEndTimeAsync();

            // Disable events and timer.
            _endTimeTimer.Stop();
            _systemEvents.Stop();
        }

        internal void OpenWorkingForm()
        {
            if (!Application.OpenForms.OfType<Form1>().Any())
            {
                _form.ShowDialog();
            }
        }

        internal async Task SaveEndTimeAsync()
        {
            await _serviceInvocation.InvokeAsync(async (service, cancelation) => {
                await service.FinishLastEntryAsync();
            });

        }
    }
}
