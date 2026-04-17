namespace PennerProjectManager.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProjectModel>? Projects { get; set; }
}
