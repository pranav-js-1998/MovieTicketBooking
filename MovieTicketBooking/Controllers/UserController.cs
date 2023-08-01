using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Business.Repository;
using MovieTicketBooking.Business.Service;
using MovieTicketBooking.Data.Models;
using System.Security.Claims;

namespace MovieTicketBooking.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IUserService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="service"></param>
        public UserController(IUserRepository repository, IUserService service)
        {
            _repository = repository;
            _service = service;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data invallid");
            }

            PrepareResponse response = await _service.CreateUser(model);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAdminUser(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data invallid");
            }

            PrepareResponse response = await _service.CreateUser(model, true);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Update the user password
        /// </summary>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        [Route("update/password")]
        [HttpPatch]
        public async Task<IActionResult> UpdatePassword([FromBody] UserPasswordUpdate userPassword)
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);
            if (!ModelState.IsValid)
            {
                return BadRequest("No user found");
            }

            var currentUser = await _repository.GetUserByUsername(userId);

            var response = await _repository.UserPasswordUpdate(userPassword, currentUser);

            if (response.status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
