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

                if (categories.Count <= 0) Results.BadRequest("No categories found");
                return Results.Ok(categories);
            }
        );

        app.MapGet("/categories/{id:int}", (int id, ICategoryRepository repo) =>
        {
            var category = repo.GetCategoryById(id).Result;
            return Results.Ok(category);
        });

        app.MapPost("/categories",
            ([FromBody] CategoryRequest categoryRequest, [FromServices] ICategoryRepository repo) =>
            {
                try
                {
                    repo.PostCategory(categoryRequest.CategoryRequestToCategoryModel());
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e.Message);
                }
            });

        app.MapDelete("categories/{id:int}", ([FromRoute] int id, [FromServices] ICategoryRepository repo) =>
        {
            try
            {
                repo.DeleteCategory(id);
                return Results.Ok();
            }

            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        app.MapDelete("categories/{categoryId:int}/projects/{projectId:int}", async ([FromRoute] int categoryId,
            [FromRoute] int projectId, [FromServices] ICategoryRepository repo) =>
        {
            var success = await repo.RemoveProjectFromCategory(categoryId, projectId);
            return success ? Results.Ok() : Results.BadRequest("Project not found in category");
        });

        app.MapPut("categories/{id:int}",
            ([FromRoute] int id, [FromBody] CategoryRequest categoryRequest, [FromServices] ICategoryRepository repo) =>
            {
                try
                {
                    // handle the patch request
                    repo.UpdateCategory(categoryRequest.CategoryRequestToCategoryModel(), id);

                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e.Message);
                }
            });
    }
}
