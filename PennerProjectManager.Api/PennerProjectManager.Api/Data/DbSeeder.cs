using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Data;

public class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Categories.Any()) return;

        var task1 = new ProjectTask { Name = "Frame" };


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
                            task1
                        ]
                    },
                    new Project
                    {
                        Name = "Tool Storage",
                        ProjectTasks =
                        [
                            task1
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
                            task1
                        ]
                    },
                    new Project
                    {
                        Name = "Signs",
                        ProjectTasks =
                        [
                            task1
                        ]
                    }
                ]
            }
        ];

        db.Categories.AddRange(categories);
        db.SaveChanges();
    }
}
