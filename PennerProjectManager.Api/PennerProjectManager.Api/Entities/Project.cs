using System.ComponentModel.DataAnnotations;

namespace PennerProjectManager.Api.Entities;

public class Project
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    public List<ProjectTask>? ProjectTasks { get; set; } = [];

    public List<Category> Categories { get; set; } = null!;
}
