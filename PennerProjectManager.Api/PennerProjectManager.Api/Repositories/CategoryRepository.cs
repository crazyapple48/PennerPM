using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Repositories;

public class CategoryRepository(IDatabaseService db, IRepositoryHelperService repoHelp) : ICategoryRepository
{
    public async Task<CategoryModel?> GetCategoryById(int id)
    {
        var result = await db.FetchCategoryById(id);

        return result?.CategoryToCategoryModel();
    }

    public void UpdateCategory(CategoryModel category)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCategory(int id)
    {
        var category = await db.FetchCategoryById(id);
        if (category is null) throw new Exception("Category does not exist");
        await db.DeleteCategory(category);
    }

    public async Task<Category> PostCategory(CategoryModel category)
    {
        var entity = new Category { Name = category.Name };

        if (category.Projects.Count > 0)
            foreach (var projectModel in category.Projects.Select(repoHelp.GetOrCreateProject))
                entity.Projects.Add(projectModel);

        await db.CreateCategory(entity);
        return entity;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var result = await db.FetchCategories();

        return result.Select(p => p.CategoryToCategoryModel()).ToList();
    }
}
