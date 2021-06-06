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
        private readonly StartWorkingForm _form;
        private readonly SystemEventsHandler _systemEvents;
        private readonly EndTimeTimer _endTimeTimer;
        private readonly IScopedInvocation<IProjectTimesEntriesService> _serviceInvocation;

        public ProjectTimesService(StartWorkingForm form, IScopedInvocation<IProjectTimesEntriesService> serviceInvocation)
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
        }

        internal async void ReOpenWorkingForm()
        {
            await SessionUnlockAsync();
        }
        internal void OpenWorkingForm()
        {
            if (!Application.OpenForms.OfType<StartWorkingForm>().Any())
            {
                var result = _form.ShowDialog();
                _systemEvents.Start();
                if (result == DialogResult.Yes)
                {
                    _endTimeTimer.Start();                    
                }
            }
        }

        internal async Task SaveEndTimeAsync()
        {
            await _serviceInvocation.InvokeAsync(async (service, _) => {
                await service.FinishLastEntryAsync();
            });

        }
    }
}
