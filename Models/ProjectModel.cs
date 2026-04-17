namespace PennerProjectManager.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProjectTaskModel>? ProjectTasks { get; set; }
}
