namespace PennerProjectManager.Api.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProjectTaskModel>? ProjectTasks { get; set; } = [];
}
