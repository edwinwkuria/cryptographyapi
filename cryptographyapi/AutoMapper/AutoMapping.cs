using AutoMapper;
using cryptographyapi.BindingModels.MessageController;
using cryptographyapi.BindingModels.UserController;
using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Models.UserService;

namespace cryptographyapi.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region messages
            CreateMap<GetMessagesRequestModel, GetMessages>();
            CreateMap<SendMessageRequestModel, SendMessage>();
            #endregion

            #region users
            CreateMap<AddUserBindingModel, User>();
            #endregion
        }
    }
}
