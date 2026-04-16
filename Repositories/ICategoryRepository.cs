using PennerProjectManager.ViewModels;

namespace PennerProjectManager.Repositories;

public interface ICategoryRepository
{
    public List<CategoryModel> GetAllCategories();
    public CategoryModel? GetCategoryById(int id);
}
