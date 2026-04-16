using PennerProjectManager.Models;

namespace PennerProjectManager.Services;

public class LocalDatabaseService : IDatabaseService
{
    public List<MainCategoryDataModel> FetchMainCategories()
    {
        return
        [
            new MainCategoryDataModel(0, "Annie"),
            new MainCategoryDataModel(1, "Shop Maintenance")
        ];
    }

    public List<SubtaskDataModel> FetchSubtasks()
    {
        throw new NotImplementedException();
    }

    public List<ProgressDataModel> FetchProgress()
    {
        return
        [
            new ProgressDataModel(0, "Framed"),
            new ProgressDataModel(1, "Faced"),
            new ProgressDataModel(2, "Trim"),
            new ProgressDataModel(3, "Paint")
        ];
    }

    public ProgressPresetsDataModel FetchProgressPresets()
    {
        return new ProgressPresetsDataModel(0, FetchProgress());
    }

    public List<ProjectDataModel> FetchProjects(int categoryId)
    {
        return
        [
            new ProjectDataModel(0, categoryId, "Rolling Door"),
            new ProjectDataModel(1, categoryId, "Annie Sign")
        ];
    }

    public MainCategoryDataModel FetchMainCategoryById(int categoryId)
    {
        var categories = FetchMainCategories();

        var mainCategory = categories[categoryId];

        return mainCategory;
    }
}