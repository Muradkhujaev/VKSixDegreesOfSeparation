using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKSixDegreesOfSeparation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VKSixDegreesOfSeparationTests
{
    [TestClass]
    public class VKConnectionFinderTests
    {
        [TestMethod]
        public async Task getConnectionTest1()
        {
            List<VKUserViewData> list = new List<VKUserViewData>();
            UserInfoFetcher fetcher1 = new UserInfoFetcher("deell1");
            UserInfoFetcher fetcher2 = new UserInfoFetcher("vagyan23");
            VKUser start = new VKUser(198489790);
            VKUser target = new VKUser(29411485);
            VKUserViewData user1 = await fetcher1.fetchInfo();
            VKUserViewData user2 = await fetcher2.fetchInfo();
            list.Add(user1);
            list.Add(user2);
            VKConnectionFinder finder = new VKConnectionFinder(start, target);
            List<VKUserViewData> result = await finder.getConnection();
            Assert.AreEqual(list.Count, result.Count, "Method getConnection() don`t look for connections correctly");
            Assert.AreEqual(list[0].Name, result[0].Name, "Method getConnection() don`t look for connections correctly");
            Assert.AreEqual(list[1].Name, result[1].Name, "Method getConnection() don`t look for connections correctly");
        }
        //Тут ошибка, логичнее возврашать список из одного элемента
        [TestMethod]
        public async Task getConnectionTest2()
        {
            List<VKUserViewData> list = new List<VKUserViewData>();
            UserInfoFetcher fetcher1 = new UserInfoFetcher("deell1");
            UserInfoFetcher fetcher2 = new UserInfoFetcher("deell1");
            VKUser start = new VKUser(198489790);
            VKUser target = new VKUser(198489790);
            VKUserViewData user1 = await fetcher1.fetchInfo();
            list.Add(user1);
            VKConnectionFinder finder = new VKConnectionFinder(start, target);
            List<VKUserViewData> result = await finder.getConnection();
            Assert.AreEqual(list.Count, result.Count, "Method getConnection() don`t look for connections correctly");
            Assert.AreEqual(list[0].Name, result[0].Name, "Method getConnection() don`t look for connections correctly");
            Assert.AreEqual(list[1].Name, result[1].Name, "Method getConnection() don`t look for connections correctly");
        }

        [TestMethod]
        public async Task getConnectionEmptyListTest()
        {
            List<VKUserViewData> list = new List<VKUserViewData>();
            VKUser start = new VKUser(198489790);
            VKUser target = new VKUser(0);
            VKConnectionFinder finder = new VKConnectionFinder(start, target);
            List<VKUserViewData> result = await finder.getConnection();
            Assert.AreEqual(list.Count, result.Count, "Method getConnection() don`t look for connections correctly");            
        }
    }
}
