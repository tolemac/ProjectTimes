using System;
using System.Globalization;

namespace ProjectTimes.Domain
{
    public static class ProjectTimeEntryStringExtensions
    {
        // ReSharper disable once StringLiteralTypo
        private static string EntryDateFormat = "yyyyMMddHHmmss";

        public static ProjectTimeEntry FromString(string line)
        {
            var parts = line.Split(";");
            var id = Convert.ToInt32(parts[0]);
            var startTime = DateTime.ParseExact(parts[1], EntryDateFormat, CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact(parts[2], EntryDateFormat, CultureInfo.InvariantCulture);
            var projectName = parts[3];
            var description = parts[4];

            return new ProjectTimeEntry(id, startTime, projectName, description)
            {
                EndTime = endTime
            };
        }

        public static string ToString(ProjectTimeEntry entry)
        {
            return String.Join(';', new string[]
            {
                entry.Id.ToString(),
                entry.StartTime.ToString(EntryDateFormat),
                entry.EndTime.ToString(EntryDateFormat),
                entry.ProjectName ?? "",
                entry.Description ?? ""
            });
        }
    }
}
