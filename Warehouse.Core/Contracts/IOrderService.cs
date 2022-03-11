using Warehouse.Core.Models;

namespace Warehouse.Core.Contracts
{
    public interface IOrderService
    {
        Task PlaceOrder(CustomerOrder order);
    }
}
