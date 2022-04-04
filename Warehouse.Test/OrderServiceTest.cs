using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Contracts;
using Warehouse.Core.Models;
using Warehouse.Core.Services;
using Warehouse.Infrastructure.Data;
using Warehouse.Infrastructure.Data.Repositories;

namespace Warehouse.Test
{
    public class OrderServiceTest
    {
        private ServiceProvider serviceProvider;
        private  InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicatioDbRepository, ApplicatioDbRepository>()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicatioDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void UnknownCustomerMustThrow()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "usdfhsdbjsh"
            };

            var service = serviceProvider.GetService<IOrderService>();


            Assert.CatchAsync<ArgumentException>(async () => await service.PlaceOrder(order), "Unknown custommer");
        }

        [Test]
        public void KnownCustomerMustNotThrow()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "myTestNumber"
            };

            var service = serviceProvider.GetService<IOrderService>();

            Assert.DoesNotThrowAsync(async () => await service.PlaceOrder(order));
        }

        [Test]
        public void NotEnoughtItemsShouldThrow()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "myTestNumber",
                Items = new List<ItemOrder>()
                {
                    new ItemOrder()
                    {
                        Barcode = "1234567890",
                        Count = 7
                    }
                }
            };

            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.PlaceOrder(order), "Not enough quantity");
        }

        [Test]
        public void EnoughtItemsInWarehouseShouldNotThrow()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "myTestNumber",
                Items = new List<ItemOrder>()
                {
                    new ItemOrder()
                    {
                        Barcode = "1234567890",
                        Count = 3
                    }
                }
            };

            var service = serviceProvider.GetService<IOrderService>();

            Assert.DoesNotThrowAsync(async () => await service.PlaceOrder(order));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicatioDbRepository repo)
        {
            var customer = new Contragent()
            {
                CustomerNumber = "myTestNumber",
                Name = "Pesho"
            };

            var item = new Item()
            {
                Barcode = "1234567890",
                Category = new Category()
                {
                    DateFrom = DateTime.Now,
                    Label = "Computers"
                },
                DateFrom = DateTime.Now,
                Label = "Laptop",
                Racks = new List<Rack>()
                {
                    new Rack()
                    {
                        ItemsCount = 5,
                        Number = "24",
                        Section = "3C",
                        IsInUse = true
                    }
                }
            };

            await repo.AddAsync(item);
            await repo.AddAsync(customer);
            await repo.SaveChangesAsync();
        }
    }
}