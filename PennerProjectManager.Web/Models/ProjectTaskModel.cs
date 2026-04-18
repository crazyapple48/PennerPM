namespace PennerProjectManager.Models;

public class ProjectTaskModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; } = false;
}
