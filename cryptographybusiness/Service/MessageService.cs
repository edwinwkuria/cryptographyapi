﻿using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptographybusiness.Service
{
    public class MessageService : IMessageService
    {
        public async Task<(bool success, string message, object data)> GetMessages(GetMessages model)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, string message, object data)> SendMessage(SendMessage model)
        {
            throw new NotImplementedException();
        }
    }
}
