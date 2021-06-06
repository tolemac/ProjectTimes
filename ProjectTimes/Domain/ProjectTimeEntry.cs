using System;

namespace ProjectTimes.Domain
{
    public class ProjectTimeEntry
    {
        public ProjectTimeEntry(int id, DateTime startTime, string projectName, string description)
        {
            Id = id;
            StartTime = startTime;
            EndTime = startTime;
            ProjectName = projectName;
            Description = description;
        }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
