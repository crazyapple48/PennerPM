namespace PennerProjectManager.Models;

public class ProjectTask(int Id, int ProjectId, string Title)
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
    public Project? ProjectModel { get; set; }
    public List<Material>? Materials { get; set; }
    public List<Subtask>? SubTasks { get; set; }
}