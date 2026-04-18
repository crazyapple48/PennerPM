using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Services;

public class LocalDatabaseService : IDatabaseService
{
    private List<Category> _categories = 
    [
        new Category
        {
            Id = 0,
            Name = "Shop Projects",
            Projects = [
                new Project
                {
                    Id = 0,
                    Name = "Rack and Workbench",
                },
                new Project
                {
                    Id = 1,
                    Name = "Tool Storage"
                }
            ]
        },
        new Category
        {
            Id = 1,
            Name = "Annie",
            Projects = [
                new Project
                {
                    Id = 0,
                    Name = "Rolling Door",
                },
                new Project
                {
                    Id = 1,
                    Name = "Signs",
                }
            ]
        }
    ];
    
    public List<Category> FetchCategories()
    {
        return _categories;
    }

    public Category? FetchCategoryById(int categoryId)
    {
        var category = _categories.FirstOrDefault(c => categoryId == c.Id);
        return category;
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
