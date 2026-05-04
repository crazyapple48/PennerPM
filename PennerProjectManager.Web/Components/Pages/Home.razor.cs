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
        if (CategoryId is not null)
            _selectedCategory = await CategoryClientService.GetCategoryById(CategoryId.Value);
        else
            _selectedCategory = null;
    }

    private void OnProjectSelected(ProjectModel project)
    {
        if (_isProjectSelected)
        {
            _isProjectSelected = false;
            Console.WriteLine("clicked " + project.Name + " is " + _isProjectSelected);
            StateHasChanged();
        }
        else
        {
            _selectedProject = project;
            _isProjectSelected = true;
            Console.WriteLine("clicked " + project.Name + " is " + _isProjectSelected);
            StateHasChanged();
        }
    }
}
