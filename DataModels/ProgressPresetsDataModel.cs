namespace PennerProjectManager.Models;

public class ProgressPresetsDataModel(int Id, List<ProgressDataModel> progressModels)
{
    public int Id { get; set; }
    public List<ProgressDataModel> ProgressModels { get; set; }
}