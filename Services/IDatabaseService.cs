using PennerProjectManager.Models;

namespace PennerProjectManager.Services;

public interface IDatabaseService
{
    public List<MainCategoryDataModel> FetchMainCategories();
    public MainCategoryDataModel FetchMainCategoryById(int categoryId);
    public List<ProjectDataModel> FetchProjects(int categoryId);
    public List<SubtaskDataModel> FetchSubtasks();
    public List<ProgressDataModel> FetchProgress();
    public ProgressPresetsDataModel FetchProgressPresets();
}
