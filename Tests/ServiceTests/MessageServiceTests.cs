using cryptographybusiness.Models.MessageService;
using cryptographybusiness.Service;
using cryptographybusiness.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Handlers;
using System.Security.Cryptography;
using System.Text;

namespace Tests.ServiceTests
{
    [TestClass]
    public class MessageServiceTests
    {
        [TestMethod]
        public void TestSendMessage()
        {
            IMessageService ims = new MessageService();
            var sth = SymmetricTestHelper.EncryptMessage("Hello World");
            SendMessage sm = new SendMessage {
                message = sth.encryted,key = sth.key,iv = sth.iv };
            var sendMsg = ims.SendMessage(sm);
            Assert.IsTrue(sendMsg.Result.success);
        }
    }
}
