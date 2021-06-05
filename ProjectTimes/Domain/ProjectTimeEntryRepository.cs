using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimes.Domain
{
    public class ProjectTimeEntryRepository : IProjectTimeEntryRepository
    {
        private readonly ProjectTimesSettings _settings;
        private bool _loaded = false;
        private IList<ProjectTimeEntry> _entries = Array.Empty<ProjectTimeEntry>();

        public ProjectTimeEntryRepository(ProjectTimesSettings settings)
        {
            _settings = settings;
        }

        public async Task EnsureLoaded()
        {
            if (!_loaded)
            {
                await LoadDataAsync();
                _loaded = true;
            }
        }

        private async Task LoadDataAsync()
        {
            var lines = await File.ReadAllLinesAsync(_settings.DataFilePath);
            var data = new List<ProjectTimeEntry>(lines.Length);
            foreach (var line in lines)
            {
                data.Add(ProjectTimeEntryStringExtensions.FromString(line));
            }
            _entries = data;
        }

        private async Task WriteDataAsync()
        {
            var lines = new List<string>();
            foreach (var entry in _entries)
            {
                lines.Add(ProjectTimeEntryStringExtensions.ToString(entry));
            }

            await File.WriteAllLinesAsync(_settings.DataFilePath, lines);
        }

        public async Task<ProjectTimeEntry?> GetLastOrDefaultAsync()
        {
            await EnsureLoaded();
            return _entries.LastOrDefault();
        }

        public async Task<ProjectTimeEntry?> GetPreviousToOrDefaultAsync(int id)
        {
            await EnsureLoaded();
            return _entries.Where(e => e.Id < id).OrderByDescending(e => e.Id).FirstOrDefault();
        }

        public async Task<IEnumerable<string>> GetAllProjectNamesAsync()
        {
            await EnsureLoaded();
            return _entries.Select(e => e.ProjectName).Distinct().Where(e => e is not null)!;
        }

        public async Task<int> GetNextIdAsync()
        {
            await EnsureLoaded();
            return _entries.Max(e => e.Id) + 1;
        }

        public async Task<ProjectTimeEntry> AddAsync(ProjectTimeEntry projectTimeEntry)
        {
            await EnsureLoaded();
            _entries.Add(projectTimeEntry);
            await WriteDataAsync();
            await LoadDataAsync();
            return projectTimeEntry;
        }

        public async Task<ProjectTimeEntry> GetByIdAsync(int id)
        {
            await EnsureLoaded();
            return _entries.First(e => e.Id == id);
        }

        public async Task<ProjectTimeEntry> UpdateAsync(ProjectTimeEntry entry)
        {
            await EnsureLoaded();
            var existing = await GetByIdAsync(entry.Id);
            existing.StartTime = entry.StartTime;
            existing.EndTime = entry.EndTime;
            existing.ProjectName = entry.ProjectName;
            existing.Description = entry.Description;

            await WriteDataAsync();
            await LoadDataAsync();

            return existing;
        }
    }
}
