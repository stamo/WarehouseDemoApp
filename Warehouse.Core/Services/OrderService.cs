using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Contracts;
using Warehouse.Core.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Infrastructure.Data.Repositories;

namespace Warehouse.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicatioDbRepository repo;

        public OrderService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task PlaceOrder(CustomerOrder order)
        {
            string customerNumber = order.CustomerNumber?.Trim() ?? string.Empty;
            var customer = await repo.All<Contragent>()
                .FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);
            if (customer == null)
            {
                throw new ArgumentException("Unknown custommer");
            }

            var barcodes = order.Items
                .Select(i => i.Barcode)
                .ToArray();

            var products = await repo.All<Item>()
                .Where(i => barcodes.Contains(i.Barcode))
                .Include(i => i.Racks)
                .ToDictionaryAsync(k => k.Barcode, v => v.Racks.First().ItemsCount);

            foreach (var item in order.Items)
            {
                if (!products.ContainsKey(item.Barcode) || 
                    item.Count > products[item.Barcode])
                {
                    throw new ArgumentException("Not enough quantity");
                }
            }
        }
    }
}
