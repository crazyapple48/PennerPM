using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public interface IDatabaseService
{
    public List<Category> FetchCategories();
    public Category? FetchCategoryById(int categoryId);
    public void CreateCategory(Category category);
    public List<Project> FetchProjects(int categoryId);
    public List<ProjectTask> FetchProjectTasks(int projectId);
}
