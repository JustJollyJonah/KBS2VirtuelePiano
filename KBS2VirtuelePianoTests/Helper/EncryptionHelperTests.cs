using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2VirtuelePiano.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Helper.Tests
{
    [TestClass()]
    public class EncryptionHelperTests
    {
        [TestMethod()]
        public void HashStringSHA512Test_WhenAStringGetsHashed_HashMethodReturnsCorrectlyHashedString()
        {
            // Arrange
            string controleHash1 = "925F43C3CFB956BBE3C6AA8023BA7AD5CFA21D104186FFFC69E768E55940D9653B1CD36FBA614FBA2E1844F4436DA20F83750C6EC1DB356DA154691BDD71A9B1";
            string teHashenString1 = "abcd1234";
            string gehashteString1;

            string controleHash2 = "939B80473546A3957F78C7946ACCC6E9E97F8DEB902919780C13526069C8CF12A31987FDF3C22A2414F8C15276697750169A9C3B656FAB2830117C61A6A008F0";
            string teHashenString2 = "1a2b3c4d";
            string gehastheString2;

            // Act
            gehashteString1 = EncryptionHelper.HashStringSHA512(teHashenString1);
            gehastheString2 = EncryptionHelper.HashStringSHA512(teHashenString2);

            // Assert
            Assert.AreEqual(controleHash1, gehashteString1);
            Assert.AreEqual(controleHash2, gehastheString2);
        }
    }
}