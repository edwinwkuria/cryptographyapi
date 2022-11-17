using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Models.MessageStore
{
    public class Message
    {
        public int sender_id { get; set; }
        public int recipient_id { get; set; }
        public DateTime timestamp { get; set; }
        public string message { get; set; }
    }
}
