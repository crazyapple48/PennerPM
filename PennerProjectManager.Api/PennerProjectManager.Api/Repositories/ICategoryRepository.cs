using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Repositories;

public interface ICategoryRepository
{
    public Task<List<CategoryModel>> GetAllCategories();
    public Task<CategoryModel?> GetCategoryById(int id);

    public void PostCategory(CategoryModel category);
    public void UpdateCategory(CategoryModel category);
}
