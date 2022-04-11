using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Contracts;
using Warehouse.Core.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Infrastructure.Data.Repositories;

namespace Warehouse.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicatioDbRepository repo;

        public CategoryService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<CategoryListViewModel> GetCategories(int pageNo, int pageSize)
        {
            CategoryListViewModel result = new CategoryListViewModel()
            {
                PageNo = pageNo,
                PageSize = pageSize
            };

            result.TotalRecords = await repo.All<Category>().CountAsync();
            result.Categories = await repo.AllReadonly<Category>()
                .OrderBy(c => c.Label)
                .Skip(pageNo * pageSize - pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }
    }
}
