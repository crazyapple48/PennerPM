using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.SharedComponents;

public partial class Navbar(ICategoryClientService client) : ComponentBase, IDisposable
{
    private IEnumerable<CategoryModel> _categories = [];

    [Inject] public required AppState AppState { get; set; }

    public void Dispose()
    {
        AppState.OnChange -= StateHasChanged;
    }


    protected override async Task OnInitializedAsync()
    {
        await AppState.RefreshCategoriesAsync();

        _categories = AppState.Categories;
    }

    protected override void OnInitialized()
    {
        AppState.OnChange += async () =>
        {
            _categories = AppState.Categories;
            Console.WriteLine("State changed" + " " + _categories.Count());
            await InvokeAsync(StateHasChanged);
        };
    }
}
