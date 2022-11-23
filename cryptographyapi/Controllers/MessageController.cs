using AutoMapper;
using cryptographyapi.BindingModels.MessageController;
using cryptographyapi.BindingModels.Response;
using cryptographybusiness.Handlers;
using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace cryptographyapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequestModel model)
        {
            var _model = _mapper.Map<SendMessage>(model);
            var response = await _messageService.SendMessage(_model);
            if (response.success)
            {
                return Ok(new ResponseUtil<object> { success = response.success, message = response.message, data = response.data});
            }
            return BadRequest(new ResponseUtil<object> { success = response.success, message = response.message, data = response.data });
        }

        [HttpGet("user/{userid}")]
        public async Task<IActionResult> GetMessages(int userid)
        {
            var _model = new GetMessages { user_id = userid };  
            var response = await _messageService.GetMessages(_model);
            if (response.success)
            {
                return Ok(new ResponseUtil<GetMessageResponse> { success = response.success, message = response.message, data = response.data });
            }
            return BadRequest(new ResponseUtil<GetMessageResponse> { success = response.success, message = response.message, data = response.data });
        }

        //Test endpoint
        [HttpPost("simulate")]
        public async Task<IActionResult> SendMessage(int from, int to, string msg)
        {
            var value = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = from, recipient_id = to, message = msg, timestamp = System.DateTime.Now };

            string msgString = JsonConvert.SerializeObject(value);
            var sth = Symmetric.Encrypt(msgString);
            var encrypted = new SendMessage
            {
                Message = sth.encrypted,
                Key = sth.key,
                IV = sth.iv
            };
            var response = await _messageService.SendMessage(encrypted);
            if (response.success)
            {
                return Ok(new ResponseUtil<object> { success = response.success, message = response.message, data = response.data });
            }
            return BadRequest(new ResponseUtil<object> { success = response.success, message = response.message, data = response.data });
        }
    }
}
