using PennerProjectManager.Api.Repositories;

namespace PennerProjectManager.Api.Endpoints;

public static class CategoryEndpoint
{
    
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        app.MapGet("/category", (ICategoryRepository repository) =>
            {
                var categories = repository.GetAllCategories();
                return Results.Ok(categories);
            }
        );

        app.MapGet("/category/{id}", (int id, ICategoryRepository repository) =>
        {
            var category = repository.GetCategoryById(id);
            return Results.Ok(category);
        });
    }
}