using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Data;
using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public class LocalDatabaseService(AppDbContext db) : IDatabaseService
{
    private readonly List<Category> _categories =
    [
    ];

    public async Task CreateCategory(Category category)
    {
        var doesCategoryExist = db.Categories.Any(c => c.Id == category.Id);
        if (doesCategoryExist) return;

        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();
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
