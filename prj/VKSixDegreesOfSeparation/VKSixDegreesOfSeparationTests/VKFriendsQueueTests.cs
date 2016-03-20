using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class VKFriendsQueueTests
    {
        /// <summary>
        /// Test for constructor work.  
        /// </summary>
        [TestMethod]
        public void constructorTest()
        {
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            Assert.AreEqual(1, queue.UserCount, "Constructor doesn`t initialize VKFriendsQueue object correctly");
        }
        /// <summary>
        /// Test for adding user to queue.
        /// </summary>
        [TestMethod]
        public void addUserTest1()
        {
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            queue.addUser(user);
            Assert.AreEqual(2, queue.UserCount, "Method addUser() doesn`t add user to queue correctly");
        }
        /// <summary>
        /// Test for adding user to queue and its root.
        /// </summary>
        [TestMethod]
        public void addUserTest2()
        {
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            queue.addUser(user);
            Assert.AreEqual(root, queue.Root, "Method addUser() doesn`t add user to queue correctly");
        }
        /// <summary>
        /// Test for true result of looking for users in queue.
        /// </summary>
        [TestMethod]
        public void containsUserTrueTest()
        {
            bool expected = true;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            queue.addUser(user);
            bool result = queue.containsUser(user);
            Assert.AreEqual(expected, result, "Method containsUser() doesn`t find user in queue correctly");
        }
        /// <summary>
        /// Test for false result of looking for users in queue.
        /// </summary>
        [TestMethod]
        public void containsUserFalseTest1()
        {
            bool expected = false;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            VKUser otherUser = new VKUser(198489790);
            queue.addUser(user);
            bool result = queue.containsUser(otherUser);
            Assert.AreEqual(expected, result, "Method containsUser() doesn`t find user in queue correctly");
        }
        /// <summary>
        /// Test for false result of looking for users (user is equal to null) in queue.
        /// </summary>
        [TestMethod]
        public void containsUserFalseTest2()
        {
            bool expected = false;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            queue.addUser(user);
            bool result = queue.containsUser(null);
            Assert.AreEqual(expected, result, "Method containsUser() doesn`t find user in queue correctly");
        }
        /// <summary>
        /// Test for getting user from queue/
        /// </summary>
        [TestMethod]
        public void getUserTest1()
        {
            VKUser expected = new VKUser(141371820);
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            queue.addUser(user);
            VKUser result = queue.getUser(141371820);
            Assert.AreEqual(expected.ID, result.ID, "Method getUser() doesn`t get user in queue correctly");
        }
        /// <summary>
        /// Test for getting not contained user from queue.
        /// </summary>
        [TestMethod]
        public void getUserTest2()
        {
            VKUser expected = null;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser user = new VKUser(141371820);
            queue.addUser(user);
            VKUser result = queue.getUser(1);
            Assert.AreEqual(expected, result, "Method getUser() doesn`t get user in queue correctly");
        }
        /// <summary>
        /// Test for checking whether the queue is empty. Test for true result.
        /// </summary>
        [TestMethod]
        public void hasNextUserTrueTest()
        {
            bool expected = true;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            bool result = queue.hasHextUser();
            Assert.AreEqual(expected, result, "Method hasNextUser() doesn`t find next user in queue correctly");
        }
        /// <summary>
        /// Test for checking whether the queue is empty. Test for false result.
        /// </summary>
        [TestMethod]
        public void hasNextUserFalseTest()
        {
            bool expected = false;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            queue.getNextUser();
            bool result = queue.hasHextUser();
            Assert.AreEqual(expected, result, "Method hasNextUser() doesn`t find next user in queue correctly");
        }
        /// <summary>
        /// Test for extracting user from queue. Test the UserCount property.
        /// </summary>
        [TestMethod]
        public void getNextUserTest1()
        {
            int expected = 0;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            queue.getNextUser();
            Assert.AreEqual(expected, queue.UserCount, "Method getNextUser() doesn`t extract user from queue correctly");
        }
        /// <summary>
        /// Test for extracting user from queue. Test whether the extracted object is correct.
        /// </summary>
        [TestMethod]
        public void getNextUserTest2()
        {
            VKUser root = new VKUser(29411485);
            VKUser expected = root;
            VKFriendsQueue queue = new VKFriendsQueue(root);
            VKUser result = queue.getNextUser();
            Assert.AreEqual(expected, result, "Method getNextUser() doesn`t extract user from queue correctly");
        }
        /// <summary>
        /// Test for extracting user from queue. Test method getNextUser() after that all objects are extracted.
        /// </summary>
        [TestMethod]
        public void getNextUserTest3()
        {
            VKUser expected = null;
            VKUser root = new VKUser(29411485);
            VKFriendsQueue queue = new VKFriendsQueue(root);
            queue.getNextUser();
            VKUser result = queue.getNextUser();
            Assert.AreEqual(expected, result, "Method getNextUser() doesn`t extract user from queue correctly");
        }
    }
}
