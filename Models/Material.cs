namespace PennerProjectManager.Models;

public class Material
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Name { get; set; }
    public string? Spec { get; set; }
    public decimal Quantity { get; set; }
    public string? Unit { get; set; }
    public ProjectTask Task { get; set; }
}
