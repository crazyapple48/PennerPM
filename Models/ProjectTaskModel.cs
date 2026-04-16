namespace PennerProjectManager.Models;

public class ProjectTaskModel(int Id, int ProjectId, string Title)
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
    public ProjectModel? ProjectModel { get; set; }
    public List<MaterialModel>? Materials { get; set; }
    public List<SubtaskModel>? SubTasks { get; set; }
}
