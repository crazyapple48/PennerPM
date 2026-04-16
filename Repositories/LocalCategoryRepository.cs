using PennerProjectManager.Services;
using PennerProjectManager.ViewModels;

namespace PennerProjectManager.Repositories;

public class LocalCategoryRepository(IDatabaseService db) : ICategoryRepository
{
    public List<CategoryModel> GetAllCategories()
    {
        var categories = db.FetchMainCategories();

        List<CategoryModel> viewModelCategories = [];

        foreach (var category in categories)
            viewModelCategories.Add(new CategoryModel(category.Id, category.Name, category.Color));

        return viewModelCategories;
    }

    public CategoryModel? GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }
}
