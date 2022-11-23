using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Models.MessageService
{
    public class GetMessageResponse
    {
        public string? Message { get; set; }
        public string? Key { get; set; }
        public string? IV { get; set; }
    }
}
