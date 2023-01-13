using Microsoft.EntityFrameworkCore;
using ProjectTimes.Domain;
using ProjectTimes.Sqlite;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqliteProjectTimesRepository(this IServiceCollection sc, string filePath,
            int endTimeTimerMilliseconds)
        {
            sc.AddDbContext<ProjectTimesDbContext>(options =>
            {
                options.UseSqlite($"Data Source={filePath}");
            });

            sc.Configure<ProjectTimesSettings>(s =>
            {
                s.DataFilePath = filePath;
                s.EndTimeTimerMilliseconds = endTimeTimerMilliseconds;
            });

            sc.AddScoped<IProjectTimeEntryRepository, EfProjectTimeEntryRepository>();


            return sc;
        }
    }
}
