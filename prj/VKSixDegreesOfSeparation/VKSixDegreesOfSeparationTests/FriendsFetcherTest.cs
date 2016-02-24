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

        [TestMethod]
        public async Task basicTest()
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
    }
}
