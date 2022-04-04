using Warehouse.Infrastructure.Data;

namespace Warehouse.Core.Contracts
{
    public interface IFileService
    {
        Task SaveFileAsync(ApplicationFile file);
    }
}
