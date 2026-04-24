using System.ComponentModel.DataAnnotations;

namespace PennerProjectManager.Api.Entities;

public class ProjectTask
{
    public int Id { get; set; }

    [MaxLength(255)] public string Name { get; set; } = string.Empty;

    public bool IsComplete { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}
