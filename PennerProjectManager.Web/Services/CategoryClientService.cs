using PennerProjectManager.Web.Models;

namespace PennerProjectManager.Web.Services;

public class CategoryClientService : ICategoryClientService
{
    private readonly HttpClient _httpClient;

    public CategoryClientService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("WebAPI");
    }

    public async Task<IEnumerable<CategoryModel>> GetAllCategories()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryModel>>("categories") ?? [];
    }

    public async Task<CategoryModel?> GetCategoryById(int id)
    {
        return await _httpClient.GetFromJsonAsync<CategoryModel>($"categories/{id}");
    }

    public async Task<bool> DeleteCategoryById(int id)
    {
        var success = await _httpClient.DeleteAsync($"categories/{id}");

        return success.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProjectFromCategoryById(int categoryId, int projectId)
    {
        var success = await _httpClient.DeleteAsync($"categories/{categoryId}/projects/{projectId}");

        return success.IsSuccessStatusCode;
    }

    public async Task<bool> CreateCategory(CategoryModel category)
    {
        var result = await _httpClient.PostAsJsonAsync("categories", category);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategoryById(CategoryModel category)
    {
        var result = await _httpClient.PutAsJsonAsync($"categories/{category.Id}", category);

        return result.IsSuccessStatusCode;
    }
}
