using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Repositories;

public class LocalCategoryRepository(IDatabaseService db) : ICategoryRepository
{
    public List<CategoryModel> GetAllCategories()
    {
        var result = db.FetchCategories();

        return result.Select(p => p.ToCategoryModel()).ToList();
    }

    public CategoryModel? GetCategoryById(int id)
    {
        var result = db.FetchCategoryById(id);

        return result?.ToCategoryModel();
    }

    public void UpdateCategory(CategoryModel category)
    {
        throw new NotImplementedException();
    }

    public void PostCategory(CategoryModel category)
    {
        var c = category.ToCategory();
        db.CreateCategory(c);
    }
}
