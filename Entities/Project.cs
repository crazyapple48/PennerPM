namespace PennerProjectManager.Models;

public class Project(int Id, int CategoryId, string Name)
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public MainCategory? MainCategory { get; set; }
    public List<ProjectTask>? Tasks { get; set; }
    public List<Progress>? ProgressPresets { get; set; }
}