namespace PennerProjectManager.ViewModels;

public class ProjectTaskViewModel(int Id, string Name)
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
}
