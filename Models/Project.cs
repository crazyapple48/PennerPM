namespace PennerProjectManager.Models;

public class Project
{
    public int Id { get; set; }
    public int ShowId { get; set; }
    public string Name { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public ShowModel Show { get; set; }
    public List<ProjectTask> Tasks { get; set; }
}
