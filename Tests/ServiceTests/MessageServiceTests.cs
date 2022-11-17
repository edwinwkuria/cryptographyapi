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
        [TestMethod]
        public void TestReadMessages()
        {
            IMessageService ims = new MessageService();
            #region simulatesendmessage
            var msg = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 6, recipient_id = 7, message = "6 to 7", timestamp = System.DateTime.Now };

            string msgString = JsonConvert.SerializeObject(msg);
            var sth = SymmetricTestHelper.EncryptMessage(msgString);
            SendMessage sm = new SendMessage
            {
                message = sth.encryted,
                key = sth.key,
                iv = sth.iv
            };
            var sendMsg = ims.SendMessage(sm);

            var msg1 = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 7, recipient_id = 6, message = "7 to 6", timestamp = System.DateTime.Now };

            string msgString1 = JsonConvert.SerializeObject(msg1);
            var sth1 = SymmetricTestHelper.EncryptMessage(msgString1);
            SendMessage sm1 = new SendMessage
            {
                message = sth1.encryted,
                key = sth1.key,
                iv = sth1.iv
            };
            var sendMsg1 = ims.SendMessage(sm1);

            var msg2 = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 9, recipient_id = 8, message = "9 to 8", timestamp = System.DateTime.Now };

            string msgString2 = JsonConvert.SerializeObject(msg2);
            var sth2 = SymmetricTestHelper.EncryptMessage(msgString2);
            SendMessage sm2 = new SendMessage
            {
                message = sth2.encryted,
                key = sth2.key,
                iv = sth2.iv
            };
            var sendMsg2 = ims.SendMessage(sm2);

            #endregion

            var result = ims.GetMessages(new GetMessages { user_id = 6 }).Result;
            Assert.IsTrue(result.success);


        }
    }
}
