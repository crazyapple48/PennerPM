namespace PennerProjectManager.Models;

public class MainCategoryDataModel(int Id, string Name)
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Color { get; set; }
    public DateOnly? OpeningDate { get; set; }
    public DateOnly? ClosingDate { get; set; }
    public string? Notes { get; set; }
    public List<ProjectDataModel> Projects { get; set; } = [];
}
