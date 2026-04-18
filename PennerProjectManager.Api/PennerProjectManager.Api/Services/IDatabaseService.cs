using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public interface IDatabaseService
{
    public List<Category> FetchCategories();
    public Category? FetchCategoryById(int categoryId);
    public List<Project> FetchProjects(int categoryId);
    public List<ProjectTask> FetchProjectTasks(int projectId);
}
