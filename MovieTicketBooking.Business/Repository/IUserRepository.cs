using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Business.Repository
{
    public interface IUserRepository
    {
        Task<PrepareResponse> CreateUser(User data);

        Task<bool> CheckUserExistsByUsername(string username);

        Task<User> GetUserByUsername(string username);

        Task<bool> VerifyUserPassword(string password, User user);
        Task<PasswordUpdateResponse> UserPasswordUpdate(UserPasswordUpdate userPassword, User username);

        string GenerateToken(User user, string role);
    }
}
