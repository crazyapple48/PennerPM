namespace PennerProjectManager.Api.Models;

public class ProjectTaskModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsComplete { get; set; } = false;
}
