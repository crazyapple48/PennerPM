using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.Dialogs;

public partial class CreateCategoryDialog : ComponentBase
{
    private string _name = "";
    [Parameter] public EventCallback OnCancelClick { get; set; }
    [Parameter] public EventCallback OnSuccess { get; set; }

    [Inject] public required ICategoryClientService CategoryClientService { get; set; }
    [Inject] public required AppState AppState { get; set; }

    private async Task HandleSubmit()
    {
        var category = new CategoryModel { Name = _name };

        await CategoryClientService.CreateCategory(category);
        await AppState.RefreshCategoriesAsync(); // NavBar updates automatically
        await OnSuccess.InvokeAsync();
    }
}
