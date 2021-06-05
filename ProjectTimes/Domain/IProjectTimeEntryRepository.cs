using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTimes.Domain
{
    public interface IProjectTimeEntryRepository
    {
        Task<ProjectTimeEntry?> GetLastOrDefaultAsync();
        Task<ProjectTimeEntry?> GetPreviousToOrDefaultAsync(int id);
        Task<IEnumerable<string>> GetAllProjectNamesAsync();
        Task<int> GetNextIdAsync();
        Task<ProjectTimeEntry> AddAsync(ProjectTimeEntry projectTimeEntry);
        Task<ProjectTimeEntry> GetByIdAsync(int id);
        Task<ProjectTimeEntry> UpdateAsync(ProjectTimeEntry entry);
    }
}
