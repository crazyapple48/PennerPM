namespace PennerProjectManager.ViewModels;

public class ProjectViewModel(
    int Id,
    string Name,
    List<ProjectTaskViewModel>? Tasks = null,
    List<ProgressViewModel>? Progress = null)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public List<ProjectTaskViewModel>? Tasks { get; set; }
    public List<ProgressViewModel>? Progress { get; set; }
}
