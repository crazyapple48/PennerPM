using PennerProjectManager.Api.Entities;
using PennerProjectManager.Api.Models;

namespace PennerProjectManager.Api.Services;

public interface IRepositoryHelperService
{
    public Project GetOrCreateProject(ProjectModel project);
    public ProjectTask GetOrCreateProjectTask(ProjectTaskModel taskModel);
}
