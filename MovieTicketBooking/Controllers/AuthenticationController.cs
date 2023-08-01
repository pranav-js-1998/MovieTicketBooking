using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Business.Repository;
using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public AuthenticationController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }


        /// <summary>
        /// User login method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthenticationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            if (!await _repository.CheckUserExistsByUsername(model.Username))
            {
                return BadRequest("No user found");
            }

            var currentUser = await _repository.GetUserByUsername(model.Username);

            if (!await _repository.VerifyUserPassword(model.Password, currentUser))
            {
                return BadRequest("Password not match");
            }

            var token = _repository.GenerateToken(currentUser, currentUser.IsAdmin ? "Admin" : "User");

            AuthenticationResponse response = new AuthenticationResponse
            {
                AccessToken = token,
                UserId = currentUser.Id,
                Username = currentUser.Username
            };

            return Ok(response);
        }
    }
}
