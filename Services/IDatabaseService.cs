using PennerProjectManager.Models;

namespace PennerProjectManager.Services;

public interface IDatabaseService
{
    public List<MainCategory> FetchMainCategories();
    public MainCategory FetchMainCategoryById(int categoryId);
    public List<Project> FetchProjects(int categoryId);
    public List<Subtask> FetchSubtasks();
    public List<Progress> FetchProgress();
    public ProgressPresets FetchProgressPresets();
}
