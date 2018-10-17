using System;
using CLTicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void profileUsernameSetter()
        {
            Profile myprofile = new Profile("Mike", "test");

            Assert.AreEqual("Mike", myprofile.Username);;
        }
    }
}
