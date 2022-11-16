using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Service;
using cryptographybusiness.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Handlers;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Tests.ServiceTests
{
    [TestClass]
    public class MessageServiceTests
    {
        [TestMethod]
        public void TestSendMessage()
        {
            IMessageService ims = new MessageService();
            var msg = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 6, recipient_id = 7, message = "Test Message", timestamp = System.DateTime.Now };

            string msgString = JsonConvert.SerializeObject(msg);
            var sth = SymmetricTestHelper.EncryptMessage(msgString);
            SendMessage sm = new SendMessage {
                message = sth.encryted,key = sth.key,iv = sth.iv };
            var sendMsg = ims.SendMessage(sm);
            Assert.IsTrue(sendMsg.Result.success);
        }
    }
}
