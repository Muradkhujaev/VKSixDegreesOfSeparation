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
        /// <summary>
        /// Test for getting not null response (not null friends) from http request.
        /// </summary>
        [TestMethod]
        public void httpRequestGetFriendsTest()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/friends.get?uid=198489790");
            Assert.AreNotEqual(null, result, "Method httpRequest() doesn`t get http response correctly");
        }
        /// <summary>
        /// Test for getting not null response (not null photo) from http request.
        /// </summary>
        [TestMethod]
        public void httpRequestGetPhotoTest1()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/users.get?fields=photo_100&user_ids=avagyan23");
            Assert.AreNotEqual(null, result, "Method httpRequest() doesn`t get http response correctly");
        }
        /// <summary>
        /// Test for getting definit response from http request for user without photo.
        /// </summary>
        [TestMethod]
        public void httpRequestGetPhotoTest2()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/users.get?fields=photo_100&user_ids=225301333");
            Assert.AreEqual(true, result.Contains("camera_100.png"), "Method httpRequest() doesn`t get http response correctly");
        }
        /// <summary>
        /// Test for getting empty response from http request without id.
        /// </summary>
        [TestMethod]
        public void httpRequestTest()
        {
            VKFetcher fetcher = new VKFetcher();
            string result = fetcher.httpRequest("https://api.vk.com/method/users.get?fields=photo_100&user_ids=");
            Assert.AreEqual("{\"response\":[]}", result, "Method httpRequest() doesn`t get http response correctly");
        }
    }
}
