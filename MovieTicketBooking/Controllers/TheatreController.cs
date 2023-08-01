using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Business.Service;
using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService service;

        /// <summary>
        /// 
        /// </summary>
        public TheatreController(ITheatreService _service)
        {
            service = _service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Reterive/All")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTheatre()
        {
            return Ok(await service.GetTheatre());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Reterive/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTheatre([FromRoute] string id)
        {
            return Ok(await service.GetTheatre(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTheatre(TheatreDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var response = await service.AddTheatre(model);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateTheatre(TheatreDto model, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var response = await service.UpdateTheatre(model, id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteTheatre(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var response = await service.DeleteTheatre(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
