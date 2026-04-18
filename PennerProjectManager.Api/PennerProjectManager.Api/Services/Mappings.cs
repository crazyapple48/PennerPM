using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public static class CategoryMappings
{
    public static CategoryModel ToCategoryModel(this Category category)
    {
        return new CategoryModel
        {
            Id = category.Id,
            Name = category.Name,
            Projects = category.Projects?.Select(p => p.ToProjectModel()).ToList() ?? []
        };
    }
}

public static class ProjectMappings
{
    public static ProjectModel ToProjectModel(this Project project)
    {
        return new ProjectModel
        {
            Id = project.Id,
            Name = project.Name,
            ProjectTasks = project.ProjectTasks?.Select(p => p.ToProjectTaskModel()).ToList() ?? []
        };
    }
}

public static class TaskMappings
{
    public static ProjectTaskModel ToProjectTaskModel(this ProjectTask task)
    {
        return new ProjectTaskModel
        {
            Id = task.Id,
            Name = task.Name,
            IsComplete = task.IsComplete
        };
    }
}
