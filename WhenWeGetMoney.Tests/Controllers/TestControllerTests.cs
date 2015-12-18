using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhenWeGetMoney.Controllers;
using WhenWeGetMoney.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Moq;

namespace WhenWeGetMoney.Tests.Controllers
{
    [TestClass]
    public class TestControllerTests
    {
        private Mock<DbSet<Wish>> mock_wish_set;
        private Mock<WhenWeGetMoneyContext> mock_context;

        private void ConnectMocksToDataStore(IEnumerable<Wish> data_store)
        {
            var data_source = data_store.AsQueryable<Wish>();

            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Wishes).Returns(mock_wish_set.Object);
        }

        [TestMethod]
        public void TestControllerEnsureICanCallGetAction()
        {
            // Arrange
            
            mock_wish_set = new Mock<DbSet<Wish>>();
            mock_context = new Mock<WhenWeGetMoneyContext>();
            WhenWeGetMoneyRepository repositoroy = new WhenWeGetMoneyRepository(mock_context.Object);

            List<Wish> expected = new List<Wish>
            {
                new Wish { Content = "Disney World" },
                new Wish {Content = "Legos" }
            };
            mock_wish_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            TestController my_controller = new TestController(repositoroy);

            // Act
            String actual = my_controller.Get();

            //Assert
            Assert.AreEqual("Legos", actual);
        }
    }
}
