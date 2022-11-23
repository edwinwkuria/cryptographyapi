using cryptographybusiness.Models.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Service.Interfaces
{
    public interface IUserService
    {
        Task<(bool success, string message, User data)> AddUser(User user);
        Task<(bool success, string message, IList<User> data)> GetUsers();
    }
}
