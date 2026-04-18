using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public class LocalDatabaseService : IDatabaseService
{
    public List<Category> FetchCategories()
    {
        return
        [
            new Category
            {
                Id = 0,
                Name = "Shop Projects"
            },
            new Category
            {
                Id = 1,
                Name = "Annie"
            }
        ];
    }

    public Category FetchCategoryById(int categoryId)
    {
        if (categoryId == 0)
            return new Category
            {
                Id = 0,
                Name = "Shop Projects",
                Projects =
                [
                    new Project
                    {
                        Id = 0,
                        Name = "Saw Bench and Rack",
                        CategoryId = categoryId,
                        ProjectTasks =
                        [
                            new ProjectTask
                            {
                                Id = 0,
                                Name = "Frame"
                            }
                        ]
                    }
                ]
            };
        return new Category
        {
            Id = 1,
            Name = "Annie",
            Projects =
            [
                new Project
                {
                    Id = 0,
                    Name = "Rolling Door",
                    CategoryId = categoryId,
                    ProjectTasks =
                    [
                        new ProjectTask
                        {
                            Id = 0,
                            Name = "Frame"
                        }
                    ]
                }
            ]
        };
    }

    public List<Project> FetchProjects(int categoryId)
    {
        throw new NotImplementedException();
    }

    public List<ProjectTask> FetchProjectTasks(int projectId)
    {
        throw new NotImplementedException();
    }
}
