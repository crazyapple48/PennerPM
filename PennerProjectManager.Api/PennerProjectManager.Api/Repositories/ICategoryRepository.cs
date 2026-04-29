using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Repositories;

public interface ICategoryRepository
{
    public Task<List<CategoryModel>> GetAllCategories();
    public Task<CategoryModel?> GetCategoryById(int id);

    public Task<Category> PostCategory(CategoryModel category);

    public Task UpdateCategory(CategoryModel category, int id);

    public Task DeleteCategory(int id);
}
