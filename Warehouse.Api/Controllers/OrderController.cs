using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Contracts;
using Warehouse.Core.Models;

namespace Warehouse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Поръчка на стока
        /// </summary>
        /// <param name="order">Вашата поръчка</param>
        /// <returns></returns>
        [HttpPost]
        [Route("place")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PlaceOrder(CustomerOrder order)
        {
            try
            {
                await service.PlaceOrder(order);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

            return Ok();
        }
    }
}
