namespace PennerProjectManager.Api.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public List<ProjectTask>? ProjectTasks { get; set; }
    }
}
