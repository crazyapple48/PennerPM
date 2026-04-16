using PennerProjectManager.Models;

namespace PennerProjectManager.Services;

public interface IDatabaseService
{
    public List<MainCategoryModel> GetMainCategories();
    public MainCategoryModel GetMainCategoryById(int categoryId);
    public List<ProjectModel> GetProjects(int categoryId);
    public List<SubtaskModel> GetSubtasks();
    public List<ProgressModel> GetProgress();
    public ProgressPresetsModel GetProgressPresets();
}
