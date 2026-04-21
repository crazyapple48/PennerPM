using Microsoft.AspNetCore.Mvc;
using PennerProjectManager.Api.Records;
using PennerProjectManager.Api.Repositories;
using PennerProjectManager.Api.Services;

namespace PennerProjectManager.Api.Endpoints;

public static class CategoryEndpoint
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        app.MapGet("/categories", (ICategoryRepository repository) =>
            {
                var categories = repository.GetAllCategories().Result;

                if (categories == null) Results.BadRequest();
                return Results.Ok(categories);
            }
        );

        app.MapGet("/categories/{id:int}", (int id, ICategoryRepository repo) =>
        {
            var category = repo.GetCategoryById(id).Result;
            return Results.Ok(category);
        });

        app.MapPost("/categories",
            ([FromBody] CategoryRequest CategoryRequest, [FromServices] ICategoryRepository repo) =>
            {
                repo.PostCategory(CategoryRequest.CategoryRequestToCategoryModel());
            });
    }
}
