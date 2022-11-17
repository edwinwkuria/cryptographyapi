using cryptographybusiness.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Helpers
{
    [TestClass]
    public class ValidateMessageTests
    {
        [TestMethod]
        public void TestValidateEncryptedMessage()
        {
            var test1 = ValidateMessage.ValidateEncryptedMessage(null);
            var test2 = ValidateMessage.ValidateEncryptedMessage(new cryptographybusiness.Models.MessageStore.Message { message = null });
            var test3 = ValidateMessage.ValidateEncryptedMessage(new cryptographybusiness.Models.MessageStore.Message { });
            Assert.IsFalse(test1.success);
            Assert.IsFalse(test2.success);
            Assert.IsFalse(test3.success);


        }
    }
}
