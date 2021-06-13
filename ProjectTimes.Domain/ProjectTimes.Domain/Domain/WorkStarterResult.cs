namespace ProjectTimes.Domain
{
    public class WorkStarterResult
    {
        public static WorkStarterResult CreateContinueWorkObject()
        {
            return new WorkStarterResult(true, false, null, null);
        }

        public static WorkStarterResult CreateTimeToRestObject()
        {
            return new WorkStarterResult(false, true, null, null);
        }

        public static WorkStarterResult CreateNewWorkObject(string projectName, string description)
        {
            return new WorkStarterResult(false, false, projectName, description);
        }

        private WorkStarterResult(bool continueWork, bool timeToRest, string? projectName, string? description)
        {
            ContinueWork = continueWork;
            TimeToRest = timeToRest;
            ProjectName = projectName;
            Description = description;
        }

        public bool ContinueWork { get; }
        public bool TimeToRest { get; }
        public string? ProjectName { get; }
        public string? Description { get; }
    }
}
