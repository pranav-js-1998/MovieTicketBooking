using AutoMapper;
using MovieTicketBooking.Business.Repository;
using MovieTicketBooking.Data.Models;
using System.Security.Cryptography;

namespace MovieTicketBooking.Business.Service
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        public readonly IUserRepository Repository;

        /// <summary>
        /// 
        /// </summary>
        public readonly IMapper Mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> CreateUser(UserDto data, bool isAdmin = false)
        {
            var newUser = Mapper.Map<User>(data);
            CreatePasswordHash(data.Password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.IsAdmin = isAdmin;
            newUser.Created = DateTime.Now;
            newUser.Updated = DateTime.Now;

            return await Repository.CreateUser(newUser);
        }

        public Task<PasswordUpdateResponse> UserPasswordUpdate(UserPasswordUpdate userPassword, User username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> VerifyUserPassword(string password, User user)
        {
            return VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
