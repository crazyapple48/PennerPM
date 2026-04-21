using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public interface IDatabaseService
{
    public Task<List<Category>> FetchCategories();
    public Task<Category?> FetchCategoryById(int categoryId);
    public Task CreateCategory(Category category);
    public List<Project> FetchProjects(int categoryId);
    public List<ProjectTask> FetchProjectTasks(int projectId);
}
