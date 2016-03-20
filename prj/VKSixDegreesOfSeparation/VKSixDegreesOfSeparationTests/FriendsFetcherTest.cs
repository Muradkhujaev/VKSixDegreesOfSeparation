using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class FriendsFetcherTest
    {
        /// <summary>
        /// Test for getting friends for person with id 325145123.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task fetchFriendsTest1()
        {
            VKUser user = new VKUser(325145123);
            FriendsFetcher fetcher = new FriendsFetcher(user);
            List<VKUser> friends = new List<VKUser>();
            friends.Add(new VKUser(27735856));
            friends.Add(new VKUser(59054252));
            List<VKUser> result = await fetcher.fetchFriends();
            Assert.AreEqual(friends[0].ID, result[0].ID, "Method fetchFriends() don`t find friends correctly");
            Assert.AreEqual(friends[1].ID, result[1].ID, "Method fetchFriends() don`t find friends correctly");
        }
        /// <summary>
        /// Test for getting not empry friends list for person with id 198489790.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task fetchFriendsTest2()
        {
            VKUser user = new VKUser(198489790);
            FriendsFetcher fetcher = new FriendsFetcher(user);
            List<VKUser> result = await fetcher.fetchFriends();
            Assert.AreNotEqual(0, result.Count, "Method fetchFriends() don`t find friends correctly");
        }
    }
}
