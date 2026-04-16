namespace PennerProjectManager.Models;

public class ProgressPresetsModel(int Id, List<ProgressModel> progressModels)
{
    public int Id { get; set; }
    public List<ProgressModel> ProgressModels { get; set; }
}
