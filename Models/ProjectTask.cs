using PennerProjectManager.Enums;

namespace PennerProjectManager.Models;

public class ProjectTask
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public ProjectTaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
    public Project Project { get; set; }
    public List<Material> Materials { get; set; }
    public List<Subtask> SubTasks { get; set; }
}
