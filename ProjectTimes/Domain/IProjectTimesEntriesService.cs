using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTimes.Domain
{
    public interface IProjectTimesEntriesService
    {
        Task<ProjectTimeEntry?> GetCurrentEntryAsync();
        Task<ProjectTimeEntry?> GetLastFinishedEntryAsync();
        Task<IEnumerable<string>> GetProjectNamesAsync();
        Task<ProjectTimeEntry> CreateEntryAsync(DateTime startTime, string projectName, string description);
        Task<ProjectTimeEntry> FinishEntryAsync(int id, DateTime endTime);
    }
}
