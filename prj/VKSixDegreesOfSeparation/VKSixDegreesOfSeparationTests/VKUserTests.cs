using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class VKUserTests
    {
        /// <summary>
        /// Test for adding child to user. Check child`s count.
        /// </summary>
        [TestMethod]
        public void addChildTest1()
        {
            int expected = 1;
            VKUser user = new VKUser(29411485);
            VKUser child = new VKUser(141371820);
            user.addChild(child);
            Assert.AreEqual(expected, user.Childs.Count, "Method addChild() doesn`t add child to user correctly");
        }
        /// <summary>
        /// Test for adding child to user. Check added child object.
        /// </summary>
        [TestMethod]
        public void addChildTest2()
        {
            VKUser user = new VKUser(29411485);
            VKUser child = new VKUser(141371820);
            VKUser expected = child;
            user.addChild(child);
            VKUser result = user.Childs[0];
            Assert.AreEqual(expected, result, "Method addChild() doesn`t add child to user correctly");
        }
        /// <summary>
        /// Test for adding child to user. Check Father property for added child.
        /// </summary>
        [TestMethod]
        public void addChildTest3()
        {
            VKUser user = new VKUser(29411485);
            VKUser child = new VKUser(141371820);
            VKUser expected = user;
            user.addChild(child);
            VKUser result = child.Father;
            Assert.AreEqual(expected, result, "Method addChild() doesn`t add child to user correctly");
        }
        /// <summary>
        /// Test for Childs property when there is no child in user object.
        /// </summary>
        [TestMethod]
        public void childTest()
        {
            int expected = 0;
            VKUser user = new VKUser(29411485);
            Assert.AreEqual(expected, user.Childs.Count, "Property Child doesn`t extract childs from user correctly");
        }
    }
}
