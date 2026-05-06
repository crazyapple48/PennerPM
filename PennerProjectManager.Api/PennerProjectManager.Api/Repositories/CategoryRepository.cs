using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Data;
using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Repositories;

public class CategoryRepository(AppDbContext db, IRepositoryHelperService repoHelp) : ICategoryRepository
{
    public async Task<CategoryModel?> GetCategoryById(int id)
    {
        var result = await db.Categories.Include(c => c.Projects).ThenInclude(p => p.ProjectTasks)
            .FirstOrDefaultAsync(c => c.Id == id);

        return result?.CategoryToCategoryModel();
    }

    public async Task DeleteCategory(int id)
    {
        var category = await db.Categories.Include(c => c.Projects).ThenInclude(p => p.ProjectTasks)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category is null) throw new Exception("Category does not exist");

        db.Categories.Remove(category);

        await db.SaveChangesAsync();
    }

    public async Task<Category> PostCategory(CategoryModel category)
    {
        var entity = new Category { Name = category.Name };

        if (category.Projects.Count > 0)
            foreach (var projectModel in category.Projects.Select(repoHelp.GetOrCreateProject))
                entity.Projects.Add(projectModel);

        var doesCategoryExist = await db.Categories.AnyAsync(c => c.Name == category.Name || c.Id == entity.Id);
        if (doesCategoryExist) throw new Exception("Category already exists");

        await db.Categories.AddAsync(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var result = await db.Categories.ToListAsync();

        return result.Select(p => p.CategoryToCategoryModel()).ToList();
    }

    public async Task UpdateCategory(CategoryModel category, int id)
    {
        var existingCategory = await db.Categories.Include(c => c.Projects).ThenInclude(p => p.ProjectTasks)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (existingCategory is null) throw new Exception("Category does not exist");

        existingCategory.Name = category.Name;

        existingCategory.Projects.Clear();

        if (category.Projects.Count > 0)
            foreach (var projectModel in category.Projects.Select(repoHelp.GetOrCreateProject))
                existingCategory.Projects.Add(projectModel);

        db.Categories.Update(existingCategory);

        await db.SaveChangesAsync();
    }

    public async Task<bool> RemoveProjectFromCategory(int categoryId, int projectId)
    {
        var category = await db.Categories.Include(c => c.Projects).FirstOrDefaultAsync(c => c.Id == categoryId);

        var project = category?.Projects.FirstOrDefault(p => p.Id == projectId);

        if (project is null) return false;

        category?.Projects.Remove(project);

        await db.SaveChangesAsync();
        return true;
    }
}
