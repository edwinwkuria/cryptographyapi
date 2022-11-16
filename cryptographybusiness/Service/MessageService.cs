using cryptographybusiness.Handlers;
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

        public async Task<(bool success, string message, object data)> GetMessages(GetMessages model)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, string message, object? data)> SendMessage(SendMessage model)
        {
            var result = Symmetric.Decrypt(model.message, model.key, model.iv);

            if (result == null)
                ReturnFalseWithErrorMessage("Error decrypting message");

            var msg = await Deserializer.DeserializeString<Message>(result);
            if(!msg.success)
                ReturnFalseWithErrorMessage(msg.message);

            var addmsgresult = await _messageStore.AddMessage(msg.data);
            if(!addmsgresult.success)
                ReturnFalseWithErrorMessage(addmsgresult.message);

            return (true, "success", null);

        }

        private (bool success, string message, object? data) ReturnFalseWithErrorMessage(string msg)
        {
            (bool success, string message, object? data) response = (false, msg, null);
            return response;
        }
    }
}
