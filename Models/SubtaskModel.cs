using PennerProjectManager.Enums;

namespace PennerProjectManager.Models;

public class SubtaskModel
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Name { get; set; }
    public TaskPriority Priority { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
    public ProjectTaskModel TaskModel { get; set; }
}
