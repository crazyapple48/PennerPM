using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Data;

public class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Categories.Any()) return;

        List<Category> categories =
        [
            new()
            {
                Name = "Shop Projects",
                Projects =
                [
                    new Project
                    {
                        Name = "Rack and Workbench",
                        ProjectTasks =
                        [
                            new ProjectTask
                            {
                                Name = "Frame"
                            }
                        ]
                    },
                    new Project
                    {
                        Name = "Tool Storage",
                        ProjectTasks =
                        [
                            new ProjectTask
                            {
                                Name = "Frame"
                            }
                        ]
                    }
                ]
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
                            new ProjectTask
                            {
                                Name = "Frame"
                            }
                        ]
                    },
                    new Project
                    {
                        Name = "Signs",
                        ProjectTasks =
                        [
                            new ProjectTask
                            {
                                Name = "Frame"
                            }
                        ]
                    }
                ]
            }
        ];

        db.Categories.AddRange(categories);
        db.SaveChanges();
    }
}
