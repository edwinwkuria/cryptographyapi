using AutoMapper;
using cryptographyapi.BindingModels.MessageController;
using cryptographybusiness.Models.MessageService;

namespace cryptographyapi.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<GetMessagesRequestModel, GetMessages>();
            CreateMap<SendMessageRequestModel, SendMessage>();
        }
    }
}
