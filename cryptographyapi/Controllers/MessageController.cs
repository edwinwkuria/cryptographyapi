using AutoMapper;
using cryptographyapi.BindingModels.MessageController;
using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cryptographyapi.Controllers
{
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet("send")]
        public async Task<Object> SendMessage(SendMessageRequestModel model)
        {
            var _model = _mapper.Map<SendMessage>(model);
            var response = await _messageService.SendMessage(_model);
            if (response.success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("user/{userid}")]
        public async Task<Object> GetMessages(GetMessagesRequestModel model)
        {
            var _model = _mapper.Map<GetMessages>(model);
            var response = await _messageService.GetMessages(_model);
            if (response.success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
