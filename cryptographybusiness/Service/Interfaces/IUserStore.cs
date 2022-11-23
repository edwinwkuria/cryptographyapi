using cryptographybusiness.Models.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Service.Interfaces
{
    internal interface IUserStore
    {
        Task<(bool success, string message, User? data)> Add(User user);
        Task<(bool success, string message, IList<User> data)> GetAll();
        (bool success, string message, int data) GetUserCount();
    }
}
