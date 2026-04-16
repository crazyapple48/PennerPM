namespace PennerProjectManager.ViewModels;

public class CategoryViewModel(int Id, string Name, string? Color, List<ProjectViewModel>? Projects = null)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Color { get; set; }
    public DateOnly? OpeningDate { get; set; }
    public DateOnly? ClosingDate { get; set; }
    public string? Notes { get; set; }
    public List<ProjectViewModel>? Projects { get; set; } = [];
}
