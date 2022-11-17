using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Models.MessageService
{
    public class GetMessageResponse
    {
        public string message { get; set; }
        public string key { get; set; }
        public string iv { get; set; }
    }
}
