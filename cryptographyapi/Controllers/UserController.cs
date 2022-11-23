using AutoMapper;
using cryptographyapi.BindingModels.Response;
using cryptographyapi.BindingModels.UserController;
using cryptographybusiness.Models.UserService;
using cryptographybusiness.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cryptographyapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody]AddUserBindingModel model)
        {
            User user = _mapper.Map<User>(model);
            var addUser = await _userService.AddUser(user);
            if (addUser.success)
            {
                return Ok(new ResponseUtil<User> { success = addUser.success, message = addUser.message, data = addUser.data });
            }
            return BadRequest(new ResponseUtil<object> { success = addUser.success, message = addUser.message, data = addUser.data });
            
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUsers()
        {
            var getusers = await _userService.GetUsers();
            if(getusers.success)
            {
                return Ok(new ResponseUtil<object> { success = getusers.success, message = getusers.message, data = getusers.data });
            }
            return BadRequest(new ResponseUtil<object> { success = getusers.success, message = getusers.message, data = getusers.data });
        }
    }
}
