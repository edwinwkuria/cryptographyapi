using cryptographybusiness.Models.MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Service.Interfaces
{
    public interface IMessageService
    {
        Task<(bool success, string message, object data)> SendMessage(SendMessage model);
        Task<(bool success, string message, object data)> GetMessages(GetMessages model);
    }
}
