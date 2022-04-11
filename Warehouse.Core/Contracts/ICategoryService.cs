using Warehouse.Core.Models;

namespace Warehouse.Core.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryListViewModel> GetCategories(int pageNo, int pageSize);
    }
}
