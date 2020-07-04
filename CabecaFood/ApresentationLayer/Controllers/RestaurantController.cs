using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.AddressModel;
using BusinessLogicalLayer.Models.OrderModel;
using BusinessLogicalLayer.Models.RestaurantModel;
using BusinessLogicalLayer.Models.SnackModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApresentationLayer.Controllers
{
    [Route("restaurants")]
    [ApiController]
    public class RestaurantController : AbstractController
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IAddressService _addressService;
        private readonly ISnackService _snackService;
        private readonly IOrderService _orderService;
        private readonly ICommentRestaurantService _commentRestaurantService;

        public RestaurantController(IRestaurantService restaurantService,
                                    IAddressService addressService,
                                    ISnackService snackService,
                                    IOrderService orderService,
                                    ICommentRestaurantService commentRestaurantService)
        {
            _restaurantService = restaurantService;
            _addressService = addressService;
            _snackService = snackService;
            _orderService = orderService;
            _commentRestaurantService = commentRestaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var restaurants = await _restaurantService.GetAll();
                return Ok(restaurants);
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
                var restaurant = await _restaurantService.GetById(id);
                return Ok(restaurant);
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
                var restaurant = await _restaurantService.Delete(id);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RestaurantUpdateRequestModel model)
        {
            try
            {
                var restaurant = await _restaurantService.Update(id, model);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}/password")]
        public async Task<IActionResult> UpdatePassword([FromRoute] int id, [FromBody] RestaurantPasswordRequestModel model)
        {
            try
            {
                var restaurant = await _restaurantService.ChangePassword(id, model);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RestaurantRequestModel model)
        {
            try
            {
                var user = await _restaurantService.Create(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] RestaurantLoginRequestModel model)
        {
            try
            {
                var user = await _restaurantService.Login(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        [Route("{restaurantId}/address")]
        public async Task<IActionResult> CreateAddress([FromRoute] int restaurantId, [FromBody] AddressRequestModel model)
        {
            try
            {
                var address = await _addressService.Create(restaurantId, model, true);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("{restaurantId}/address")]
        public async Task<IActionResult> GetByUserId([FromRoute] int restaurantId)
        {
            try
            {
                var address = await _addressService.GetByRestaurantId(restaurantId);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{restaurantId}/address")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int restaurantId, [FromBody] AddressUpdateModel model)
        {
            try
            {
                var address = await _addressService.UpdateAddressByRestaurant(restaurantId, model);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("{restaurantId}/snacks")]
        public async Task<IActionResult> GetSnacks([FromRoute] int restaurantId)
        {
            try
            {
                var snacks = await _snackService.GetByRestaurantId(restaurantId);
                return Ok(snacks);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        [Route("{restaurantId}/snacks")]
        public async Task<IActionResult> CreateSnack([FromRoute] int restaurantId, [FromBody] SnackRequestModel model)
        {
            try
            {
                var snack = await _snackService.Create(restaurantId, model);
                return Ok(snack);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("{restaurantId}/snacks/{id}")]
        public async Task<IActionResult> GetBySnackId([FromRoute] int restaurantId, [FromRoute] int id)
        {
            try
            {
                var snack = await _snackService.GetById(restaurantId, id);
                return Ok(snack);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{restaurantId}/snacks/{id}")]
        public async Task<IActionResult> UpdateSnack([FromRoute] int restaurantId, [FromBody] SnackUpdateModel model, [FromRoute] int id)
        {
            try
            {
                var snack = await _snackService.Update(restaurantId, id, model);
                return Ok(snack);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpDelete]
        [Route("{restaurantId}/snacks/{id}")]
        public async Task<IActionResult> DeleteSnack([FromRoute] int restaurantId, [FromRoute] int id)
        {
            try
            {
                var snack = await _snackService.Delete(restaurantId, id);
                return Ok(snack);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        //

        [HttpGet]
        [Route("{restaurantId}/orders")]
        public async Task<IActionResult> GetOrders([FromRoute] int restaurantId)
        {
            try
            {
                var orders = await _orderService.GetByRestaurantId(restaurantId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        [Route("{restaurantId}/orders")]
        public async Task<IActionResult> CreateOrder([FromRoute] int restaurantId, [FromBody] OrderRequestModel model)
        {
            try
            {
                var order = await _orderService.Create(restaurantId, model);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("{restaurantId}/orders/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int restaurantId, [FromRoute] int id)
        {
            try
            {
                var order = await _orderService.GetById(restaurantId, id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpDelete]
        [Route("{restaurantId}/orders/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int restaurantId, [FromRoute] int id)
        {
            try
            {
                var order = await _orderService.Delete(restaurantId, id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }
    }
}