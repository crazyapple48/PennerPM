namespace PennerProjectManager.Models;

public class ProjectDataModel(int Id, int CategoryId, string Name)
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public MainCategoryDataModel? MainCategory { get; set; }
    public List<ProjectTaskDataModel>? Tasks { get; set; }
    public List<ProgressDataModel>? ProgressPresets { get; set; }
}