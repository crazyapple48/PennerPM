namespace PennerProjectManager.Api.Records;

public record CategoryRequest(int Id, string Name, List<ProjectRequest>? Projects);
