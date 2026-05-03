using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Data;

public class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Categories.Any()) return;

        List<ProjectTask> tasks = [];

        for (var i = 0; i < 20; i++) tasks.Add(new ProjectTask { Name = $"Task {i}" });

        List<Project> projects = [];

        for (var i = 0; i < 20; i++) projects.Add(new Project { Name = $"Project {i}", ProjectTasks = tasks });

        List<Category> categories =
        [
            new()
            {
                Name = "Shop Projects",
                Projects = projects
            },
            new()
            {
                Name = "Annie",
                Projects =
                [
                    new Project
                    {
                        Name = "Rolling Door",
                        ProjectTasks =
                        [
                            tasks[0]
                        ]
                    },
                    new Project
                    {
                        Name = "Signs",
                        ProjectTasks =
                        [
                            tasks[0]
                        ]
                    }
                ]
            }
        ];

        db.Categories.AddRange(categories);
        db.SaveChanges();
    }
}
