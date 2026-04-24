using System.ComponentModel.DataAnnotations;

namespace PennerProjectManager.Api.Entities;

public class Project
{
    public int Id { get; set; }
    [MaxLength(255)] public string Name { get; set; } = string.Empty;
    public ICollection<ProjectTask>? ProjectTasks { get; set; } = [];

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
