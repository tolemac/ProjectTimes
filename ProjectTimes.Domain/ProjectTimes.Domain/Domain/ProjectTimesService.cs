using System;
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
            _endTimeTimer = new ActionTimer(SaveEndTimeAsync, settingsOptions?.Value.EndTimeTimerMilliseconds ?? 3000);
            _workerStarter = workerStarter;
            _serviceInvocation = serviceInvocation;
            _beginEndWorkSignaler = beginEndWorkSignaler;
            _logger = logger;
            _beginEndWorkSignaler.SetActions(BeginWorkAsync, EndWorkAsync);
        }

        internal async Task BeginWorkAsync()
        {
            // Disable events and timer.
            _endTimeTimer.Stop();
            _beginEndWorkSignaler.Stop();

            // Show start working dialog
            await StartToWork();

        }
        internal Task EndWorkAsync()
        {
            // Disable events and timer.
            _endTimeTimer.Stop();

            return Task.CompletedTask;
        }

        public async Task StartToWork()
        {
            _endTimeTimer.Stop();
            _beginEndWorkSignaler.Stop();

            var result = _workerStarter.StartToWork();
            if (!result.TimeToRest)
            {
                if (result.ContinueWork)
                {
                    await _serviceInvocation.InvokeAsync(async (service, _) =>
                    {
                        await service.FinishLastEntryAsync();
                    });
                }
                else
                {
                    await _serviceInvocation.InvokeAsync(async (service, _) =>
                    {
                        await service.CreateEntryAsync(DateTime.Now, result.ProjectName!, result.Description!);
                    });
                }
                _endTimeTimer.Start();
            }
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
