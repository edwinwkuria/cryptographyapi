using cryptographybusiness.Models.UserService;
using cryptographybusiness.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Service
{
    public class UserService : IUserService
    {
        public async Task<(bool success, string message, User? data)> AddUser(User user)
        {
            IUserStore store = new UserStore();
            var userCount = store.GetUserCount();
            if (!userCount.success)
                return ReturnFalseWithErrorMessage<User>(userCount.message ?? "could not get current users");

            user.User_Id = userCount.data++;
            return await store.Add(user);
        }

        public async Task<(bool success, string message, IList<User> data)> GetUsers()
        {
            IUserStore store = new UserStore();
            return await store.GetAll();
        }

        private (bool success, string message, T? data) ReturnFalseWithErrorMessage<T>(string msg)
        {
            (bool success, string message, T? data) response = (false, msg, default(T));
            return response;
        }
    }
}
