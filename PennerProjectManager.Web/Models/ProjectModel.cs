namespace PennerProjectManager.Web.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<ProjectTaskModel>? ProjectTasks { get; set; }
}
