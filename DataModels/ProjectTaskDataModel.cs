namespace PennerProjectManager.Models;

public class ProjectTaskDataModel(int Id, int ProjectId, string Title)
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
    public ProjectDataModel? ProjectModel { get; set; }
    public List<MaterialDataModel>? Materials { get; set; }
    public List<SubtaskDataModel>? SubTasks { get; set; }
}