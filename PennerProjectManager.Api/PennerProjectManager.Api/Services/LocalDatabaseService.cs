using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Data;
using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public class LocalDatabaseService(AppDbContext db) : IDatabaseService
{
    private readonly List<Category> _categories =
    [
    ];

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

    public async Task<List<Category>> FetchCategories()
    {
        var categories = await db.Categories
            .ToListAsync();

        return categories;
    }

    public async Task<Category?> FetchCategoryById(int categoryId)
    {
        if (categoryId == null) return null;

        var category = await db.Categories.Include(c => c.Projects).ThenInclude(p => p.ProjectTasks)
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        return category;
    }
}
