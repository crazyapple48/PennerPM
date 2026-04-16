using PennerProjectManager.Models;

namespace PennerProjectManager.Services;

public class LocalDatabaseService : IDatabaseService
{
    public List<MainCategoryModel> GetMainCategories()
    {
        return
        [
            new MainCategoryModel(0, "Annie"),
            new MainCategoryModel(1, "Shop Maintenance")
        ];
    }

    public List<SubtaskModel> GetSubtasks()
    {
        throw new NotImplementedException();
    }

    public List<ProgressModel> GetProgress()
    {
        return
        [
            new ProgressModel(0, "Framed"),
            new ProgressModel(1, "Faced"),
            new ProgressModel(2, "Trim"),
            new ProgressModel(3, "Paint")
        ];
    }

    public ProgressPresetsModel GetProgressPresets()
    {
        return new ProgressPresetsModel(0, GetProgress());
    }

    public List<ProjectModel> GetProjects(int categoryId)
    {
        return
        [
            new ProjectModel(0, categoryId, "Rolling Door"),
            new ProjectModel(1, categoryId, "Annie Sign")
        ];
    }

    public MainCategoryModel GetMainCategoryById(int categoryId)
    {
        var categories = GetMainCategories();

        var mainCategory = categories[categoryId];

        return mainCategory;
    }
}
