using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public class LocalDatabaseService : IDatabaseService
{
    private readonly List<Category> _categories =
    [
    ];

    public List<Category> FetchCategories()
    {
        return _categories;
    }

    public Category? FetchCategoryById(int categoryId)
    {
        var category = _categories.FirstOrDefault(c => categoryId == c.Id);
        return category;
    }

    public void CreateCategory(Category category)
    {
        List<int> categoryIds = [];
        categoryIds.AddRange(_categories.Select(c => c.Id));
        var highestId = categoryIds[^1];

        if (category.Id == 0)
        {
            var modifiedCategory = new Category
            {
                Id = highestId + 1,
                Name = category.Name,
                Projects = category.Projects
            };
            _categories.Add(modifiedCategory);
        }

        if (categoryIds.Contains(category.Id)) return;

        _categories.Add(category);
    }

    public List<Project> FetchProjects(int categoryId)
    {
        throw new NotImplementedException();
    }

    public List<ProjectTask> FetchProjectTasks(int projectId)
    {
        throw new NotImplementedException();
    }
}
