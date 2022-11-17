using cryptographybusiness.Models.MessageStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Helpers
{
    internal class ValidateMessage
    {
        public static (bool success, string message) ValidateEncryptedMessage(Message message)
        {
            if(message == null) { return (false, "Invalid message"); }

            if (message.GetType() != typeof(Message)) { return (false, "Object is not of instance message"); }

            if(message.message == null || message.sender_id == 0 || message.recipient_id == 0) { return (false, "Incorrect object"); }

            return (true, "success");
        }
    }
}
