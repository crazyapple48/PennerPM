namespace PennerProjectManager.Web.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<ProjectModel>? Projects { get; set; }
}
