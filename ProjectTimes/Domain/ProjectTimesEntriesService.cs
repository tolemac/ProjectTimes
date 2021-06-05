using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTimes.Domain
{
    public class ProjectTimesEntriesService : IProjectTimesEntriesService
    {
        private readonly IProjectTimeEntryRepository _repository;

        public ProjectTimesEntriesService(IProjectTimeEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectTimeEntry?> GetCurrentEntryAsync()
        {
            var last = await _repository.GetLastOrDefaultAsync();
            return last?.EndTime is null ? last : null;
        }

        public async Task<ProjectTimeEntry?> GetLastFinishedEntryAsync()
        {
            var last = await _repository.GetLastOrDefaultAsync();
            if (last is null || last.EndTime is not null)
                return last;

            return await _repository.GetPreviousToOrDefaultAsync(last!.Id);
        }

        public Task<IEnumerable<string>> GetProjectNamesAsync()
        {
            return _repository.GetAllProjectNamesAsync();
        }

        public async Task<ProjectTimeEntry> CreateEntryAsync(DateTime startTime, string projectName, string description)
        {
            var id = await _repository.GetNextIdAsync();
            return await _repository.AddAsync(new ProjectTimeEntry(id, startTime, projectName, description));
        }

        public async Task<ProjectTimeEntry> FinishEntryAsync(int id, DateTime endTime)
        {
            var entry = await _repository.GetByIdAsync(id);
            entry.EndTime = endTime;
            return await _repository.UpdateAsync(entry);
        }

        public async Task<ProjectTimeEntry?> FinishLastEntryAsync()
        {
            var entry = await GetLastFinishedEntryAsync();
            if (entry is null)
                return null;
            return await FinishEntryAsync(entry.Id, DateTime.Now);
        }
    }
}
