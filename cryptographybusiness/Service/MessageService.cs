using cryptographybusiness.Handlers;
using cryptographybusiness.Helpers;
using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Models.MessageStore;
using cryptographybusiness.Service.Interfaces;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;


namespace cryptographybusiness.Service
{
    public class MessageService : IMessageService
    {
        private static readonly IMessageStore _messageStore = new MessageStore();

        public async Task<(bool success, string message, GetMessageResponse data)> GetMessages(GetMessages model)
        {
            var messages = await _messageStore.ReadMessages(model.user_id);
            if (!messages.success)
                ReturnFalseWithErrorMessage(messages.message);

            var serialize = await Deserializer.SerializeObject<List<Message>>(messages.data);
            if (!serialize.success)
                ReturnFalseWithErrorMessage(serialize.message);

            var encrypt = Symmetric.Encrypt(serialize.data);

            return(true, "success", new GetMessageResponse { message = encrypt.encrypted, key = encrypt.key, iv = encrypt.iv });
        }

        public async Task<(bool success, string message, object? data)> SendMessage(SendMessage model)
        {
            var result = Symmetric.Decrypt(model.message, model.key, model.iv);
            if (result == null)
                return ReturnFalseWithErrorMessage("Error decrypting message");

            var msg = await Deserializer.DeserializeString<Message>(result);
            if(!msg.success || msg.data == null)
                return ReturnFalseWithErrorMessage(msg.message);

            var validate = ValidateMessage.ValidateEncryptedMessage(msg.data);
            if (!validate.success)
                return ReturnFalseWithErrorMessage(validate.message);
            

            var addmsgresult = await _messageStore.AddMessage(msg.data);
            if(!addmsgresult.success)
                return ReturnFalseWithErrorMessage(addmsgresult.message);

            return (true, "success", null);

        }

        private (bool success, string message, object? data) ReturnFalseWithErrorMessage(string msg)
        {
            (bool success, string message, object? data) response = (false, msg, null);
            return response;
        }
    }
}
