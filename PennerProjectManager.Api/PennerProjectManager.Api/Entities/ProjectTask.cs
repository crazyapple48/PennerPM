namespace PennerProjectManager.Api.Entities;

public class ProjectTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}
