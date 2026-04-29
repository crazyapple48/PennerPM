using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Data;
using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public class LocalDatabaseService(AppDbContext db) : IDatabaseService
{
    private readonly List<Category> _categories =
    [
    ];

    public async Task CreateCategory(Category category)
    {
        var doesCategoryExist = db.Categories.Any(c => c.Id == category.Id || c.Name == category.Name);
        if (doesCategoryExist) throw new Exception("Category already exists");

        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();
    }


    public async Task<List<Category>> FetchCategories()
    {
        var categories = await db.Categories
            .ToListAsync();

        return categories;
    }

    public async Task<Category?> FetchCategoryById(int categoryId)
    {
        var category = await db.Categories.Include(c => c.Projects).ThenInclude(p => p.ProjectTasks)
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        return category;
    }

    public async Task UpdateCategory(Category category)
    {
        if (category is null) throw new Exception("Category does not exist");
        db.Categories.Update(category);

        try
        {
            await db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteCategory(Category category)
    {
        if (category is null) throw new Exception("Category does not exist");
        db.Categories.Remove(category);
        await db.SaveChangesAsync();
    }

    public Project? FetchProjectByName(ProjectModel project)
    {
        var result = db.Projects.Include(p => p.ProjectTasks).FirstOrDefault(p => p.Name == project.Name);

        return result ?? null;
    }

    public ProjectTask? FetchProjectTaskByName(ProjectTaskModel projectTask)
    {
        return db.ProjectTasks.FirstOrDefault(t => t.Name == projectTask.Name) ?? null;
    }

    public ProjectTask CreateProjectTask(ProjectTask projectTask)
    {
        var result = db.ProjectTasks.Add(projectTask);
        db.SaveChangesAsync();

        return result.Entity;
    }
}
