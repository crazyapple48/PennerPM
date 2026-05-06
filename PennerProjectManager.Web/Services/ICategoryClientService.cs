using PennerProjectManager.Web.Models;

namespace PennerProjectManager.Web.Services;

public interface ICategoryClientService
{
    Task<IEnumerable<CategoryModel>> GetAllCategories();
    Task<CategoryModel?> GetCategoryById(int id);

    Task<bool> DeleteProjectFromCategoryById(int categoryId, int projectId);
}
