namespace PennerProjectManager.ViewModels;

public class ProgressModel(int Id, string Title)
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
}
