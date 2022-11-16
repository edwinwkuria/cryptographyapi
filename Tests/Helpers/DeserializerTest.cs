using cryptographybusiness.Handlers;
using cryptographybusiness.Models.MessageStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Tests.Helpers
{
    [TestClass]
    public class DeserializerTest
    {
        [TestMethod]
        public void TestDeserializeString()
        {
            var msg = new cryptographybusiness.Models.MessageStore.Message
            { sender_id = 1, recipient_id = 2, message = "Test Message", timestamp = System.DateTime.Now };

            string msgString = JsonConvert.SerializeObject(msg);

            var result = Deserializer.DeserializeString<Message>(msgString);
            Assert.IsTrue(result.Result.success);
            Assert.AreEqual(msg.message, result.Result.data.message);
        }

    }
}
