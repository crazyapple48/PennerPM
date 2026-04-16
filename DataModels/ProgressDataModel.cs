namespace PennerProjectManager.Models;

public class ProgressDataModel(int id, string title, bool isDone = false)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public bool IsDone { get; set; } = isDone;
}
