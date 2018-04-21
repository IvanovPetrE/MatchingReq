using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchingReqTests
{
    [TestClass]
    public class TraderTests
    {
        [TestMethod]
        public void traderConstructorTest()
        {
            //arrenge
            String[] vals = { "C2","4350","370","120","950","560" };
            String expected = "C2\t4350\t370\t120\t950\t560";
            //act
            MatchingReqClassLibrary.Trader test =new  MatchingReqClassLibrary.Trader(vals);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void buyOrSellPS_buy_A_Test()
        {
            //arrenge
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "b";
            String psType = "A";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t999\t2\t1\t1\t1";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void buyOrSellPS_buy_B_Test()
        {
            //arrenge
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "b";
            String psType = "B";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t999\t1\t2\t1\t1";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void buyOrSellPS_buy_C_Test()
        {
            //arrenge
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "b";
            String psType = "C";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t999\t1\t1\t2\t1";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void buyOrSellPS_buy_D_Test()
        {
            //arrenge
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "b";
            String psType = "D";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t999\t1\t1\t1\t2";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void buyOrSellPS_sell_A_Test()
        {
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "s";
            String psType = "A";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t1001\t0\t1\t1\t1";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void buyOrSellPS_sell_B_Test()
        {
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "s";
            String psType = "B";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t1001\t1\t0\t1\t1";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void buyOrSellPS_sell_C_Test()
        {
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "s";
            String psType = "C";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t1001\t1\t1\t0\t1";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void buyOrSellPS_sell_D_Test()
        {
            String[] vals = { "C2", "1000", "1", "1", "1", "1" };
            String reqType = "s";
            String psType = "D";
            int cost = 1;
            int qt = 1;
            String expected = "C2\t1001\t1\t1\t1\t0";
            //act
            MatchingReqClassLibrary.Trader test = new MatchingReqClassLibrary.Trader(vals);
            test.buyOrSellPS(reqType, psType, cost, qt);
            String actual = test.getTraderData();
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
