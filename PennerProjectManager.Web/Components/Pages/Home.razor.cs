using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.Pages;

public partial class Home : ComponentBase
{
    private bool _isProjectSelected;
    private CategoryModel? _selectedCategory;
    private ProjectModel? _selectedProject;

    [Inject] public required ICategoryClientService CategoryClientService { get; set; }

    [Parameter] public int? CategoryId { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        await FetchCategory();
    }

    private async Task FetchCategory()
    {
        if (CategoryId is not null)
            _selectedCategory = await CategoryClientService.GetCategoryById(CategoryId.Value);
    }

    private void OnProjectSelected(ProjectModel project)
    {
        if (_isProjectSelected)
        {
            _isProjectSelected = false;
            StateHasChanged();
        }
        else
        {
            _selectedProject = project;
            _isProjectSelected = true;
            StateHasChanged();
        }
    }

    private async Task DeleteProjectFromCategory(ProjectModel project)
    {
        Console.WriteLine("Delete button clicked");
        if (_selectedCategory is null) return;
        var success = await CategoryClientService.DeleteProjectFromCategoryById(_selectedCategory.Id, project.Id);

        if (success)
        {
            await FetchCategory();
            StateHasChanged();
        }
    }
}
