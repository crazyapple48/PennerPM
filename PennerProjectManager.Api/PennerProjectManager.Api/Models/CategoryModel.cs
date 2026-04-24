namespace PennerProjectManager.Api.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProjectModel> Projects { get; set; } = [];
}
