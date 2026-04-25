using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public interface IDatabaseService
{
    public Task<List<Category>> FetchCategories();
    public Task<Category?> FetchCategoryById(int categoryId);
    public Task CreateCategory(Category category);
    public Project? FetchProjectByName(ProjectModel project);
    public ProjectTask? FetchProjectTaskByName(ProjectTaskModel projectTask);
}
