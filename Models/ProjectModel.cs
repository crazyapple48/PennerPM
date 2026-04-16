namespace PennerProjectManager.ViewModels;

public class ProjectModel(
    int Id,
    string Name,
    List<ProjectTaskModel>? Tasks = null,
    List<ProgressModel>? Progress = null)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public List<ProjectTaskModel>? Tasks { get; set; }
    public List<ProgressModel>? Progress { get; set; }
}
