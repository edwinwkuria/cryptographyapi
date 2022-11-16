using Microsoft.VisualStudio.TestTools.UnitTesting;
using cryptographybusiness.Service;
using cryptographybusiness.Service.Interfaces;

namespace Tests.MessageStoreTests
{
    [TestClass]
    public class MessageStoreTests
    {
        [TestMethod]
        public void TestAddMessage()
        {
            IMessageStore messageStore = new MessageStore();
            var response = messageStore.AddMessage(new cryptographybusiness.Models.MessageStore.Message 
            { sender_id = 1, recipient_id = 2, message = "Test Message", timestamp = System.DateTime.Now});
            Assert.IsTrue(response.Result.success);
        }
        [TestMethod]
        public void TestReadMessages()
        {
            IMessageStore messageStore = new MessageStore();
            var resp = messageStore.ReadMessages(1);
            Assert.IsTrue(resp.Result.success);
            Assert.AreEqual(0, resp.Result.data.Count);

            messageStore.AddMessage(new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 1, recipient_id = 2, message = "Test Message", timestamp = System.DateTime.Now });
            messageStore.AddMessage(new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 2, recipient_id = 1, message = "Test Message Received", timestamp = System.DateTime.Now });
            messageStore.AddMessage(new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 2, recipient_id = 3, message = "Hello World", timestamp = System.DateTime.Now });
            var response = messageStore.ReadMessages(1);
            Assert.IsTrue(response.Result.success);
            Assert.AreEqual(2, response.Result.data.Count);

            IMessageStore messageStore2 = new MessageStore();
            var response2 = messageStore.ReadMessages(1);
            Assert.IsTrue(response2.Result.success);
            Assert.AreEqual(2, response.Result.data.Count);


        }
    }
}
