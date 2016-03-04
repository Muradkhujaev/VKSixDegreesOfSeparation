using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class VKFetcherTests
    {
        [TestMethod]
        public void httpRequestGetFriendsTest()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/friends.get?uid=198489790");
            Assert.AreNotEqual(null, result, "Method httpRequest() doesn`t get http response correctly");
        }

        [TestMethod]
        public void httpRequestGetPhotoTest1()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/users.get?fields=photo_100&user_ids=avagyan23");
            Assert.AreNotEqual(null, result, "Method httpRequest() doesn`t get http response correctly");
        }

        [TestMethod]
        public void httpRequestGetPhotoTest2()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/users.get?fields=photo_100&user_ids=225301333");
            Assert.AreEqual(true, result.Contains("camera_100.png"), "Method httpRequest() doesn`t get http response correctly");
        }

        [TestMethod]
        public void httpRequestTest()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/users.get?fields=photo_100&user_ids=");
            Assert.AreEqual("{\"response\":[]}", result, "Method httpRequest() doesn`t get http response correctly");
        }
    }
}
