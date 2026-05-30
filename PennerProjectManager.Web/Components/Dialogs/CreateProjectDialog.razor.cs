using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.Dialogs;

public partial class CreateProjectDialog : ComponentBase
{
    [Parameter] public string ProjectName { get; set; } = "";
    [Parameter] public required CategoryModel Category { get; set; }
    [Parameter] public EventCallback OnCancelClick { get; set; }
    [Parameter] public EventCallback OnSuccess { get; set; }

    [Inject] public required ICategoryClientService CategoryClientService { get; set; }

    private async Task HandleSubmit()
    {
        Category.Projects?.Add(new ProjectModel { Name = ProjectName });

        var result = await CategoryClientService.UpdateCategoryById(Category);

        if (!result) return;
        await OnSuccess.InvokeAsync();
    }
}
