using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HighOrLow.Engine.Tests
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void CanCreateInstanceOfPosition()
        {
            Position position = new Position("jonatan", 0);
            Assert.AreEqual("jonatan", position.UserName);
            Assert.AreEqual(0, position.Score);
        }
    }
}
