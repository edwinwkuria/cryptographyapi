using cryptographybusiness.Models.MessageStore;
using cryptographybusiness.Service.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace cryptographybusiness.Service
{
    internal class MessageStore : IMessageStore
    {
        private static IList<Message>? messages;
        public Task<(bool success, string message, object? data)> AddMessage(Message model)
        {
            (bool success, string message, object? data) response;
            try 
            {
                if (messages == null)
                    messages = new List<Message>();
                messages.Add(model);
                response = (true, "success", null);
                return Task.FromResult(response);
            }catch (Exception ex)
            {
                response = (false, ex.Message, null);
                return Task.FromResult(response);
            }
            
        }
        public Task<(bool success, string message, List<Message>? data)> ReadMessages(int user_id)
        {
            (bool success, string message, List<Message>? data) response;
            try
            {
                if (messages == null)
                {
                    response = (true, "success", new List<Message>());
                    return Task.FromResult(response);
                }
                else
                {
                    response = (true, "success", null);
                    //Get messages on both sender and recipient
                    response.data = messages.Where(x => x.sender_id == user_id || x.recipient_id == user_id).ToList();
                    return Task.FromResult(response);
                }
            }catch (Exception ex)
            {
                response = (false, ex.Message, null);
                return Task.FromResult(response);
            }
        }
    }
}
