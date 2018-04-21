using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchingReqTests
{
    [TestClass]
    public class TraserTests
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
    }
}
