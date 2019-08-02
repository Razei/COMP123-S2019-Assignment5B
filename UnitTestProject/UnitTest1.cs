using System;
using COMP123_S2019_Assignment5B;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(Program.selectForm.ConnectedToDatabase());
        }
    }
}
