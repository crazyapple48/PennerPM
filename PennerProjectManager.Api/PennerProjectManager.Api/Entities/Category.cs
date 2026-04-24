using System.ComponentModel.DataAnnotations;

namespace PennerProjectManager.Api.Entities;

public class Category
{
    public int Id { get; set; }
    [MaxLength(255)] public required string Name { get; set; } = string.Empty;

    public ICollection<Project> Projects { get; set; } = [];
}
