namespace PennerProjectManager.Models;

public class ProjectModel(int Id, int CategoryId, string Name)
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public MainCategoryModel? MainCategory { get; set; }
    public List<ProjectTaskModel>? Tasks { get; set; }
    public List<ProgressModel>? ProgressPresets { get; set; }
}
