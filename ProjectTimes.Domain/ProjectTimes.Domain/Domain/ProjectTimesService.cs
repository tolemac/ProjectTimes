using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectTimes.Infrastructure;
using ScopedInvocation;

namespace ProjectTimes.Domain
{
    public class ProjectTimesService
    {
        private readonly ActionTimer _endTimeTimer;
        private readonly IWorkStarter _workerStarter;
        private readonly IScopedInvocation<IProjectTimesEntriesService> _serviceInvocation;
        private readonly BeginEndWorkSignaler _beginEndWorkSignaler;
        private readonly ILogger<ProjectTimesService> _logger;

        public ProjectTimesService(IWorkStarter workerStarter, IOptions<ProjectTimesSettings>? settingsOptions, 
            IScopedInvocation<IProjectTimesEntriesService> serviceInvocation, BeginEndWorkSignaler beginEndWorkSignaler,
            ILogger<ProjectTimesService> logger)
        {
            _endTimeTimer = new ActionTimer(SaveEndTimeAsync, settingsOptions?.Value.EndTimeTimerMiliseconds ?? 3000);
            _workerStarter = workerStarter;
            _serviceInvocation = serviceInvocation;
            _beginEndWorkSignaler = beginEndWorkSignaler;
            _logger = logger;
            _beginEndWorkSignaler.SetActions(BeginWorkAsync, EndWorkAsync);
        }

        internal Task BeginWorkAsync()
        {
            // Disable events and timer.
            _endTimeTimer.Stop();
            _beginEndWorkSignaler.Stop();

            // Show start working dialog
            StartToWork();

            return Task.CompletedTask;

        }
        internal async Task EndWorkAsync()
        {
            // Disable events and timer.
            _endTimeTimer.Stop();
        }

        public void StartToWork()
        {
            _endTimeTimer.Stop();
            _beginEndWorkSignaler.Stop();

            if (_workerStarter.StartToWork())
                _endTimeTimer.Start();
            _beginEndWorkSignaler.Start();
        }

        internal async Task SaveEndTimeAsync()
        {
            _logger.LogDebug($"Saving end time. <{System.Threading.Thread.CurrentThread.ManagedThreadId} - {System.Threading.Thread.CurrentThread.Name}>");
            await _serviceInvocation.InvokeAsync(async (service, _) => {
                await service.FinishLastEntryAsync();
            });

        }
    }
}
