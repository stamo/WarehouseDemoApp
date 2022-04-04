using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Contracts;
using Warehouse.Infrastructure.Data;
using Warehouse.Infrastructure.Data.Repositories;

namespace Warehouse.Core.Services
{
    public class FileService : IFileService
    {
        private readonly IApplicatioDbRepository repo;

        public FileService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task SaveFileAsync(ApplicationFile file)
        {
            await repo.AddAsync(file);
            await repo.SaveChangesAsync();
        }
    }
}
