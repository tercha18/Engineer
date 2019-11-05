using Engineer.Models.Api.User;
using Engineer.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Service.UserService
{
    public interface IAuthUser
    {
        Task<User> Login(string userName, string password);
        Task<User> Create(FormModel user, string password);
        Task<bool> UserExists(string userName);
    }
}
