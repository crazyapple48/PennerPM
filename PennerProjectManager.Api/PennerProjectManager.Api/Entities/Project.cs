namespace PennerProjectManager.Api.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProjectTask>? ProjectTasks { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
