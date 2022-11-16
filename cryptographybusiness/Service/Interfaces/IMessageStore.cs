using cryptographybusiness.Models.MessageStore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace cryptographybusiness.Service.Interfaces
{

    internal interface IMessageStore
    {
        Task<(bool success, string message, object? data)> AddMessage(Message model);
        Task<(bool success, string message, List<Message>? data)> ReadMessages(int user_id);
    }
}
