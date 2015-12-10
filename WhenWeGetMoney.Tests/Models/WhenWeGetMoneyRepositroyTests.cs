﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WhenWeGetMoney.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace WhenWeGetMoney.Tests.Models
{
    [TestClass]
    public class WhenWeGetMoneyRepositroyTests
    {

        private Mock<WhenWeGetMoneyContext> mock_context;
        private Mock<DbSet<Family>> mock_family_set;
        private Mock<DbSet<Wish>> mock_wish_set;
        private Mock<DbSet<MoneyPot>> mock_moneyPot_set;

        private WhenWeGetMoneyRepository repository;

        private void ConnectMocksToDataStore(IEnumerable<Family> data_store)
        {
            var data_source = data_store.AsQueryable<Family>();
            
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Families).Returns(mock_family_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Wish> data_store)
        {
            var data_source = data_store.AsQueryable<Wish>();

            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_wish_set.As<IQueryable<Wish>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Wishes).Returns(mock_wish_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<MoneyPot> data_store)
        {
            var data_source = data_store.AsQueryable<MoneyPot>();

            mock_moneyPot_set.As<IQueryable<MoneyPot>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_moneyPot_set.As<IQueryable<MoneyPot>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_moneyPot_set.As<IQueryable<MoneyPot>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_moneyPot_set.As<IQueryable<MoneyPot>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.MoneyPots).Returns(mock_moneyPot_set.Object);
        }
        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<WhenWeGetMoneyContext>();
            mock_family_set = new Mock<DbSet<Family>>();
            mock_wish_set = new Mock<DbSet<Wish>>();
            mock_wish_set = new Mock<DbSet<Wish>>();
            mock_moneyPot_set = new Mock<DbSet<MoneyPot>>();
            repository = new WhenWeGetMoneyRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_family_set = null;
            mock_wish_set = null;
            mock_moneyPot_set = null;
            repository = null;
        }

        [TestMethod]
        public void WhenWeGetMoneyContextEnsureCanCreateInstance()
        {
            WhenWeGetMoneyContext context = new WhenWeGetMoneyContext();
            Assert.IsNotNull(context);
        }
        [TestMethod]
        public void WhenWeGetMoneyRepositoryEnsureCanCreateRepository()
        {
            WhenWeGetMoneyRepository repository = new WhenWeGetMoneyRepository();
            Assert.IsNotNull(repository);
        }
        [TestMethod]
        public void WhenWeGetMoneyRepositoryEnsureCanGetAllFamilies()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice" },
                new Family {FamilyName = "Wade" }
            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            var actual = repository.GetAllFamilies();

            //Assert
            Assert.AreEqual("Rice", actual.First().FamilyName);
            CollectionAssert.AreEqual(expected, actual);
        }

       [TestMethod]
       public void WhenWeGetMoneyEnsureIHaveAContext()
        {
            // Arrange
            // Act
            var actual = repository.Context;
            // Assert
            Assert.IsInstanceOfType(actual, typeof(WhenWeGetMoneyContext));
        }



    [TestMethod]
        public void WhenWeGetMoneyEnsureICanGetAllWishes()
        {
            //Arrange
            List<Wish> expected = new List<Wish>
            {
                new Wish { Content = "Disney World" },
                new Wish { Content = "Legos" }
            };
            mock_wish_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            List<Wish> actual = repository.GetAllWishes();

            //Assert
            Assert.AreEqual("Disney World", actual.First().Content);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWeGetMoneyEnsureICanGetAllMoneyPots()
        {
            //Arrange
            List<MoneyPot> expected = new List<MoneyPot>
            {
                new MoneyPot { MoneyPotId = 1 },
                new MoneyPot { MoneyPotId = 2 }
            };
            mock_moneyPot_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            List<MoneyPot> actual = repository.GetAllMoneyPots();

            //Assert
            Assert.AreEqual(1, actual.First().MoneyPotId);
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}
