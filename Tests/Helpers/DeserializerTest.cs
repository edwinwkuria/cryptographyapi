using cryptographybusiness.Handlers;
using cryptographybusiness.Models.MessageStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tests.Helpers
{
    [TestClass]
    public class DeserializerTest
    {
        [TestMethod]
        public void TestDeserializeString()
        {
            var msg = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 6, recipient_id = 7, message = "Test Message", timestamp = System.DateTime.Now };

            string msgString = JsonConvert.SerializeObject(msg);

            var result = Deserializer.DeserializeString<Message>(msgString);
            Assert.IsTrue(result.Result.success);
            Assert.AreEqual(msg.message, result.Result.data.message);

            var msg2 = "Hello World";

            var result2 = Deserializer.DeserializeString<Message>(msg2);
            Assert.IsTrue(result.Result.success);
            Assert.IsNull(result2.Result.data);
        }

        [TestMethod]
        public void TestSerializeString()
        {
            List<Message> msgList = new List<Message>();
            msgList.Add(new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 6, recipient_id = 7, message = "Test Message", timestamp = System.DateTime.Now });
            msgList.Add(new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 7, recipient_id = 6, message = "Test Message", timestamp = System.DateTime.Now });

            var list = Deserializer.SerializeObject<List<Message>>(msgList).Result;

            Assert.IsTrue(list.success);
            var desrialize = JsonConvert.DeserializeObject <List<Message>>(list.data);
            Assert.AreEqual(msgList.Count, desrialize.Count);

        }

    }
}
