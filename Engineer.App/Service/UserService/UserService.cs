using Engineer.Data;
using Engineer.Models.Api;
using Engineer.Models.Api.User;
using Engineer.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Engineer.Service.UserService
{
    public class UserService : IAuthUser
    {
        private readonly DataContext context;
        private IMapper Mapper { get; }
        public UserService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.Mapper = mapper;
        }

        #region Login()
        public async Task<User> Login(string userName, string password)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Username.Equals(userName));

                if (user == null)
                    return null;

                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Create()
        public async Task<User> Create(FormModel model, string password)
        {
            try
            {
                var user = Mapper.Map<User>(model);

                byte[] passwordHash, passwordSalt;
                CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region UserExists()
        public async Task<bool> UserExists(string userName)
        {
            if (await context.Users.AnyAsync(x => x.Username.Equals(userName)))
                return true;

            return false;
        }
        #endregion

        #region [private] CreatePasswordHashSalt()
        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion

        #region [private] VerifyPasswordHash()
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != password[i])
                        return false;
                }
                return true;
            }
        }
        #endregion

        #region GetList()
        public async Task<List<User>> GetList()
        {
            try
            {
                var result = await context.Users
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Fetch()
        public User Fetch(long id)
        {
            try
            {
                var result = context.Users
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update()
        public User Update(FormModel model, User user)
        {
            try
            {
                var updateUser = Mapper.Map<User>(model);

                byte[] passwordHash, passwordSalt;
                if (!String.IsNullOrEmpty(model.Password))
                {
                    CreatePasswordHashSalt(model.Password, out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }

                user.Height = updateUser.Height > 0 ? updateUser.Height : user.Height;
                user.Weight = updateUser.Weight > 0 ? updateUser.Weight : user.Weight;
                if (!String.IsNullOrEmpty(updateUser.Username))
                    user.Username = updateUser.Username;

                context.Users.Update(user);
                context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
