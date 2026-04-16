using PennerProjectManager.Models;

namespace PennerProjectManager.Services;

public class LocalDatabaseService : IDatabaseService
{
    public List<MainCategory> FetchMainCategories()
    {
        return
        [
            new MainCategory(0, "Annie"),
            new MainCategory(1, "Shop Maintenance")
        ];
    }

    public List<Subtask> FetchSubtasks()
    {
        throw new NotImplementedException();
    }

    public List<Progress> FetchProgress()
    {
        return
        [
            new Progress(0, "Framed"),
            new Progress(1, "Faced"),
            new Progress(2, "Trim"),
            new Progress(3, "Paint")
        ];
    }

    public ProgressPresets FetchProgressPresets()
    {
        return new ProgressPresets(0, FetchProgress());
    }

    public List<Project> FetchProjects(int categoryId)
    {
        return
        [
            new Project(0, categoryId, "Rolling Door"),
            new Project(1, categoryId, "Annie Sign")
        ];
    }

    public MainCategory FetchMainCategoryById(int categoryId)
    {
        var categories = FetchMainCategories();

        var mainCategory = categories[categoryId];

        return mainCategory;
    }
}
