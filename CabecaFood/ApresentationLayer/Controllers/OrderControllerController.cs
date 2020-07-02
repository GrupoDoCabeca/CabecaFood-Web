using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.OrderModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApresentationLayer.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderControllerController : AbstractController
    {
        private readonly IOrderService _orderService;

        public OrderControllerController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _orderService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var user = await _orderService.GetById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var user = await _orderService.Delete(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderRequestModel model)
        {
            try
            {
                var user = await _orderService.Create(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }
    }
}