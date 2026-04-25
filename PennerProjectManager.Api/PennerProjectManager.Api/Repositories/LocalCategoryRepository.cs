using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Repositories;

public class LocalCategoryRepository(IDatabaseService db) : ICategoryRepository
{
    public async Task<CategoryModel?> GetCategoryById(int id)
    {
        var result = await db.FetchCategoryById(id);

        return result?.CategoryToCategoryModel();
    }

    public void UpdateCategory(CategoryModel category)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> PostCategory(CategoryModel category)
    {
        var entity = new Category { Name = category.Name };

        if (category.Projects.Count > 0)
            foreach (var projectModel in category.Projects.Select(GetOrCreateProject))
                entity.Projects.Add(projectModel);

        await db.CreateCategory(entity);
        return entity;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var result = await db.FetchCategories();

        return result.Select(p => p.CategoryToCategoryModel()).ToList();
    }

    public Project GetOrCreateProject(ProjectModel project)
    {
        var existing = db.FetchProjectByName(project);

        if (existing is null)
            return new Project
            {
                Name = project.Name,
                ProjectTasks = project.ProjectTasks?.Select(t => GetOrCreateProjectTask(t)).ToList() ?? []
            };

        if (project.ProjectTasks is null) return existing;

        foreach (var task in project.ProjectTasks.Select(GetOrCreateProjectTask)
                     .Where(task =>
                         existing.ProjectTasks != null && existing.ProjectTasks.All(t => t.Name != task.Name)))
            existing.ProjectTasks?.Add(task);

        return existing;
    }

    public ProjectTask GetOrCreateProjectTask(ProjectTaskModel taskModel)
    {
        return db.FetchProjectTaskByName(taskModel) ?? new ProjectTask { Name = taskModel.Name };
    }
}
