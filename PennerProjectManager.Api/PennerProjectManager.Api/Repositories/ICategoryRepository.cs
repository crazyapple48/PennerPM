using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Repositories;

public interface ICategoryRepository
{
    public List<CategoryModel> GetAllCategories();
    public CategoryModel? GetCategoryById(int id);
}
