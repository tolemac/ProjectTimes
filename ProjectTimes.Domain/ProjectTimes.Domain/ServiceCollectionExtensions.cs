using ProjectTimes.Domain;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectTimesServices(this IServiceCollection sc)
        {
            sc
                .AddScoped<IProjectTimesEntriesService, ProjectTimesEntriesService>()
                .AddSingleton<ProjectTimesService>();

            return sc;
        }

        public static IServiceCollection AddTxtProjectTimesRepository(this IServiceCollection sc, string filePath, int endTimeTimerMilliseconds)
        {
            sc
                .AddScoped<IProjectTimeEntryRepository, TxtFileProjectTimeEntryRepository>()
                .Configure<ProjectTimesSettings>(s =>
                {
                    s.DataFilePath = filePath;
                    s.EndTimeTimerMilliseconds = endTimeTimerMilliseconds;
                });

            return sc;
        }
    }
}
