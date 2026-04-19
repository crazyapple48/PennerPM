using Microsoft.AspNetCore.Mvc;
using PennerProjectManager.Api.Models;
using PennerProjectManager.Api.Records;
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

        app.MapGet("/category/{id}", (int id, ICategoryRepository repo) =>
        {
            var category = repo.GetCategoryById(id);
            return Results.Ok(category);
        });

        app.MapPost("/category",
            ([FromBody] CategoryRequest CategoryRequest, [FromServices] ICategoryRepository repo) =>
            {
                var category = CategoryRequest;
                
                repo.PostCategory(new CategoryModel
                {
                    Name = category.Name,
                    Id = 0,
                });
            });
    }
}