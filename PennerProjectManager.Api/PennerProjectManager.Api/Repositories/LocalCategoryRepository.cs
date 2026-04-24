using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Repositories;

public class LocalCategoryRepository(IDatabaseService db) : ICategoryRepository
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

    public async Task PostCategory(CategoryModel category)
    {
        try
        {
            var c = category.CategoryModelToCategory();
            await db.CreateCategory(c);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var result = await db.FetchCategories();

        return result.Select(p => p.CategoryToCategoryModel()).ToList();
    }
}
