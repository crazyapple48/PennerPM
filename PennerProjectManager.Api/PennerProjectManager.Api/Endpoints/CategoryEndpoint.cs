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
    }
}