using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Data;
using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public class RepositoryHelperService(AppDbContext db) : IRepositoryHelperService
{
    public ProjectTask GetOrCreateProjectTask(ProjectTaskModel taskModel)
    {
        var task = db.ProjectTasks.FirstOrDefault(t => t.Name == taskModel.Name);

        if (task is null)
        {
            db.ProjectTasks.Add(taskModel.ProjectTaskModelToProjectTask());
            db.SaveChanges();
            task = db.ProjectTasks.FirstOrDefault(t => t.Name == taskModel.Name);
        }

        return task;
    }

    public Project GetOrCreateProject(ProjectModel project)
    {
        var existing = db.Projects.Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Name == project.Name);

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
}