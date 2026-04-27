using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Repositories;

public class ProjectRepository(IDatabaseService db) : IProjectRepository
{
}
