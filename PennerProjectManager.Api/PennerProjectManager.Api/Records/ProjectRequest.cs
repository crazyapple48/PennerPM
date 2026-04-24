namespace PennerProjectManager.Api.Records;

public record ProjectRequest(string Name, List<ProjectTasksRequest>? ProjectTasks);
