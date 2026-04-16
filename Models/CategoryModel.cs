namespace PennerProjectManager.ViewModels;

public class CategoryModel(int Id, string Name, string? Color, List<ProjectModel>? Projects = null)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Color { get; set; }
    public DateOnly? OpeningDate { get; set; }
    public DateOnly? ClosingDate { get; set; }
    public string? Notes { get; set; }
    public List<ProjectModel>? Projects { get; set; } = [];
}
