using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.Dialogs;

public partial class CreateTaskDialog : ComponentBase
{
    [Parameter] public string TaskName { get; set; } = "";
    [Parameter] public required CategoryModel Category { get; set; }
    [Parameter] public required ProjectModel Project { get; set; }
    [Parameter] public EventCallback OnCancelClick { get; set; }
    [Parameter] public EventCallback OnSuccess { get; set; }

    [Inject] public required ICategoryClientService CategoryClientService { get; set; }

    private async Task HandleSubmit()
    {
        Project.ProjectTasks?.Add(new ProjectTaskModel { Name = TaskName });

        Category.Projects?.Remove(Project);
        Category.Projects?.Add(Project);

        var result = await CategoryClientService.UpdateCategoryById(Category);

        if (!result) return;
        await OnSuccess.InvokeAsync();
    }
}
