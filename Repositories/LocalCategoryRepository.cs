using PennerProjectManager.Services;
using PennerProjectManager.ViewModels;

namespace PennerProjectManager.Repositories;

public class LocalCategoryRepository(IDatabaseService db) : ICategoryRepository
{
    public List<CategoryViewModel> GetAllCategories()
    {
        var categories = db.FetchMainCategories();

        List<CategoryViewModel> viewModelCategories = [];

        foreach (var category in categories)
            viewModelCategories.Add(new CategoryViewModel(category.Id, category.Name, category.Color));

        return viewModelCategories;
    }

    public CategoryViewModel? GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }
}
