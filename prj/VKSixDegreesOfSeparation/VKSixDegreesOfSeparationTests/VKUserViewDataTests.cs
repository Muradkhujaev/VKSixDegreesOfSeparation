using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class VKUserViewDataTests
    {
        /// <summary>
        /// Test for nick validating. Nick is a word or word and numbers.
        /// </summary>
        [TestMethod]
        public void validateNickTrueTest1()
        {
            bool expected = true;
            VKUserViewData user = new VKUserViewData("deell1");
            bool result = user.validateNick();
            Assert.AreEqual(expected, result, "Method validateNick() doesn`t validate nick correctly");
        }
        /// <summary>
        /// Test for nick validating. Nick is numbers.
        /// </summary>
        [TestMethod]
        public void validateNickTrueTest2()
        {
            bool expected = true;
            VKUserViewData user = new VKUserViewData("141371820");
            bool result = user.validateNick();
            Assert.AreEqual(expected, result, "Method validateNick() doesn`t validate nick correctly");
        }
        /// <summary>
        /// Test for nick validating. Nick is empty.
        /// </summary>
        [TestMethod]
        public void validateNickFalseTest()
        {
            bool expected = false;
            VKUserViewData user = new VKUserViewData("");
            bool result = user.validateNick();
            Assert.AreEqual(expected, result, "Method validateNick() doesn`t validate nick correctly");
        }
    }
}
