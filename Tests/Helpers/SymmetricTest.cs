using cryptographybusiness.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tests.Handlers;

namespace Tests.Helpers
{
    [TestClass]
    public class SymmetricTest
    {
        [TestMethod]
        public void TestDecrypt()
        {
            var msg = "Hello World!";
            var sth = SymmetricTestHelper.EncryptMessage(msg);
            Assert.AreEqual(msg, Symmetric.Decrypt(sth.encryted, sth.key, sth.iv));
        }
    }
}
