using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Business.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        Task<PrepareResponse> CreateUser(UserDto data, bool isAdmin = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userPassword"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<PasswordUpdateResponse> UserPasswordUpdate(UserPasswordUpdate userPassword, User username);
    }
}
