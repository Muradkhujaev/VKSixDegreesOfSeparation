using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class UserInfoFetcherTests
    {
        /// <summary>
        /// Test for getting information about user by his nick (e.g. deell1)
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task fetchInfoTest()
        {
            UserInfoFetcher fetcher = new UserInfoFetcher("deell1");
            VKUserViewData expected = new VKUserViewData(198489790, "Дильмурад", "deell1", "http://cs629511.vk.me/v629511790/2c646/KZsDKpWrvVQ.jpg");
            VKUserViewData result = await fetcher.fetchInfo();
            Assert.AreEqual(expected.ID, result.ID, "Method fetchInfo() don`t fetch information correctly");
            Assert.AreEqual(expected.Name, result.Name, "Method fetchInfo() don`t fetch information correctly");
            Assert.AreEqual(expected.Nick, result.Nick, "Method fetchInfo() don`t fetch information correctly");
            Assert.AreEqual(expected.PhotoUrl, result.PhotoUrl, "Method fetchInfo() don`t fetch information correctly");
        }
        /// <summary>
        /// Test for getting information for person with empty nick.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task fetchInfoNullTest1()
        {
            UserInfoFetcher fetcher = new UserInfoFetcher("");
            VKUserViewData result = await fetcher.fetchInfo();
            Assert.AreEqual(null, result, "Method fetchInfo() don`t fetch information correctly");
        }
        /// <summary>
        /// Test for getting information for not existing nick.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task fetchInfoNullTest2()
        {
            UserInfoFetcher fetcher = new UserInfoFetcher("deell2");
            VKUserViewData result = await fetcher.fetchInfo();
            Assert.AreEqual(null, result, "Method fetchInfo() don`t fetch information correctly");
        }
    }
}
