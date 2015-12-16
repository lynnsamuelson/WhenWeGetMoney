using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhenWeGetMoney.Controllers;

namespace WhenWeGetMoney.Tests.Controllers
{
    [TestClass]
    public class TestControllerTests
    {
        [TestMethod]
        public void TestControllerEnsureICanCallGetAction()
        {
            // Arrange
            TestController my_controller = new TestController();
            string expected_output = "Monkey Rock!";

            // Act
            string actual_output = my_controller.Get();

            // Assert
            Assert.AreEqual(expected_output, actual_output);
        }
    }
}
