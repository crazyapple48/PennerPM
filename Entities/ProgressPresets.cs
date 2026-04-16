namespace PennerProjectManager.Models;

public class ProgressPresets(int Id, List<Progress> progressModels)
{
    public int Id { get; set; }
    public List<Progress> ProgressModels { get; set; }
}