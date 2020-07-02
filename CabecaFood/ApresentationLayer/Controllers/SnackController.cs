using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.SnackModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApresentationLayer.Controllers
{
    [Route("snacks")]
    [ApiController]
    public class SnackController : AbstractController
    {
        private readonly ISnackService _snackService;

        public SnackController(ISnackService snackService)
        {
            _snackService = snackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var snacks = await _snackService.GetAll();
                return Ok(snacks);
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
                var snack = await _snackService.GetById(id);
                return Ok(snack);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SnackRequestModel model)
        {
            try
            {
                var snack = await _snackService.Create(model);
                return Ok(snack);
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
                var user = await _snackService.Delete(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SnackRequestModel model)
        {
            try
            {
                var user = await _snackService.Update(id, model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }
    }
}