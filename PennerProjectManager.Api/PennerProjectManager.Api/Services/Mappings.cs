using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Records;

namespace PennerProjectManager.Api.Services;

public static class CategoryMappings
{
    public static CategoryModel CategoryToCategoryModel(this Category category)
    {
        return new CategoryModel
        {
            Id = category.Id,
            Name = category.Name,
            Projects = category.Projects?.Select(p => p.ProjectToProjectModel()).ToList() ?? []
        };
    }

    public static Category CategoryModelToCategory(this CategoryModel category)
    {
        return new Category
        {
            Name = category.Name,
            Projects = category.Projects?.Select(p => p.ProjectModelToProject()).ToList() ?? []
        };
    }

    public static CategoryModel CategoryRequestToCategoryModel(this CategoryRequest category)
    {
        return new CategoryModel
        {
            Name = category.Name,
            Id = 0,
            Projects = []
        };
    }
}

public static class ProjectMappings
{
    public static ProjectModel ProjectToProjectModel(this Project project)
    {
        return new ProjectModel
        {
            Id = project.Id,
            Name = project.Name,
            ProjectTasks = project.ProjectTasks?.Select(p => p.ProjectTaskToProjectTaskModel()).ToList() ?? []
        };
    }

    public static Project ProjectModelToProject(this ProjectModel project)
    {
        return new Project
        {
            Name = project.Name,
            ProjectTasks = project.ProjectTasks?.Select(pt => pt.ProjectTaskModelToProjectTask()).ToList() ?? []
        };
    }

    public static ProjectModel ProjectRequestToProjectModel(this ProjectRequest project)
    {
        return new ProjectModel
        {
            Name = project.Name,
            Id = 0,
            ProjectTasks = []
        };
    }
}

public static class TaskMappings
{
    public static ProjectTaskModel ProjectTaskToProjectTaskModel(this ProjectTask task)
    {
        return new ProjectTaskModel
        {
            Id = task.Id,
            Name = task.Name,
            IsComplete = task.IsComplete
        };
    }

    public static ProjectTask ProjectTaskModelToProjectTask(this ProjectTaskModel task)
    {
        return new ProjectTask
        {
            Name = task.Name
        };
    }

    public static ProjectTaskModel ProjectTaskRequestToProjectTaskModel(this ProjectTask task)
    {
        return new ProjectTaskModel
        {
            Name = task.Name
        };
    }
}
