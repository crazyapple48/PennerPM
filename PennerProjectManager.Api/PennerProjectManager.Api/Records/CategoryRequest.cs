namespace PennerProjectManager.Api.Records;

public record CategoryRequest(string Name, List<ProjectRequest>? Projects);