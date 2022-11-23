using cryptographybusiness.Models.UserService;
using cryptographybusiness.Service.Interfaces;

namespace cryptographybusiness.Service
{
    internal class UserStore : IUserStore
    {
        private static IList<User>? _users;
        public Task<(bool success, string message, User? data)> Add(User user)
        {
            (bool success, string message, User? data) response;
            try
            {


                if (_users == null)
                    _users = new List<User>();
                _users.Add(user);
                response = (true, "success", user);
            }catch (Exception ex)
            {
                response = (false, "adding user failed", null);
            }
            return Task.FromResult(response);
        }

        public Task<(bool success, string message, IList<User>? data)> GetAll()
        {
            (bool success, string message, IList<User>? data) response;

            try
            {
                response = (true, "success", _users);
                
            }catch(Exception ex)
            {
                response = (false, "could not fetch list", null);
            }

            return Task.FromResult(response);
        }

        public (bool success, string message, int data) GetUserCount()
        {
            if (_users == null)
                return (true, "success", 0);
            else
                return (true, "success", _users.Count);
        }
    }
}
