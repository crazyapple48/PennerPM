using PennerProjectManager.Web.Models;

namespace PennerProjectManager.Web.Services;

public class AppState(ICategoryClientService client)
{
    public IEnumerable<CategoryModel> Categories { get; private set; } = [];
    public event Action? OnChange;

    public async Task RefreshCategoriesAsync()
    {
        Categories = await client.GetAllCategories();

        OnChange?.Invoke();
    }
}
