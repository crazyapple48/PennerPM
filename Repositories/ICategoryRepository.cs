using PennerProjectManager.ViewModels;

namespace PennerProjectManager.Repositories;

public interface ICategoryRepository
{
    public List<CategoryViewModel> GetAllCategories();
    public CategoryViewModel? GetCategoryById(int id);
}
