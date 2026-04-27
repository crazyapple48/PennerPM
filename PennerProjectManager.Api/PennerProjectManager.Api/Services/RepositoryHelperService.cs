using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public class RepositoryHelperService(IDatabaseService db) : IRepositoryHelperService
{
    public Project GetOrCreateProject(ProjectModel project)
    {
        var existing = db.FetchProjectByName(project);

        if (existing is null)
            return new Project
            {
                Name = project.Name,
                ProjectTasks = project.ProjectTasks?.Select(GetOrCreateProjectTask).ToList() ?? []
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
        var task = db.FetchProjectTaskByName(taskModel) ??
                   db.CreateProjectTask(taskModel.ProjectTaskModelToProjectTask());
        return task;
    }
}
