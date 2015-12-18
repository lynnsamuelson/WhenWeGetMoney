using System;
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
        public void WhenWeGetmoneyEnsureICanGetFamilyByName()
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
            string FamilyName = "Rice";
            Family actual_user = repository.GetFamilyByName(FamilyName);
            //Assert
            Assert.AreEqual("Rice", actual_user.FamilyName);
        }

        [TestMethod]
        public void WhenWeGetUserByNameDoesNotExist()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice" },
                new Family {FamilyName = "Wade" }
            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            // Act
            string FamilyName = "bogus";
            Family actual_user = repository.GetFamilyByName(FamilyName);
            // Assert
            Assert.IsNull(actual_user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WhenWeGetMoneyFamilyNameFailsMultipleFamilyNames()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice" },
                new Family {FamilyName = "Rice" }
            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            // Act
            string FamilyName = "Rice";
            Family actual_user = repository.GetFamilyByName(FamilyName);
        }

        [TestMethod]
        public void WhenWeGetMoneyEnsureFamileyNameIsAvailable()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice" },
                new Family {FamilyName = "Wade" }
            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            // Act
            string name = "bogus";
            bool is_available = repository.IsFamilyNameAvailable(name);
            // Assert
            Assert.IsTrue(is_available);
        }

        [TestMethod]
        public void WhenWeGetMoneyEnsureFamilyNameIsNotAvailable()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice" },
                new Family {FamilyName = "Wade" }
            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            // Act
            string name = "Rice";
            bool is_available = repository.IsFamilyNameAvailable(name);
            // Assert
            Assert.IsFalse(is_available);
        }

        [TestMethod]
        public void WhenWeGetMoneyEnsureICanSearchByName()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice", TypeOfFamily = 4, FamilyUserID = 8 },
                new Family {FamilyName = "Samuelson", TypeOfFamily = 2, FamilyUserID = 6 },
                new Family {FamilyName = "Olson", TypeOfFamily = 1, FamilyUserID = 9 },
                new Family {FamilyName = "Sonson", TypeOfFamily = 2, FamilyUserID = 7 },
                new Family {FamilyName = "Sharsonville", TypeOfFamily = 2, FamilyUserID = 6 }



            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            // Act
            string search_term = "son";
            List<Family> expected_users = new List<Family>
            {
                new Family {FamilyName = "Olson", TypeOfFamily = 1, FamilyUserID = 9 },
                new Family {FamilyName = "Samuelson", TypeOfFamily = 2, FamilyUserID = 6 },
                new Family {FamilyName = "Sharsonville", TypeOfFamily = 2, FamilyUserID = 6 },
                new Family {FamilyName = "Sonson", TypeOfFamily = 2, FamilyUserID = 7 }
            };

            List<Family> actual_users = repository.SearchByName(search_term);

            // Assert
            Assert.AreEqual(expected_users[0].FamilyName, actual_users[0].FamilyName);
            Assert.AreEqual(expected_users[1].FamilyName, actual_users[1].FamilyName);
            Assert.AreEqual(expected_users[2].FamilyName, actual_users[2].FamilyName);
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
        public void WhenWeGetMoneyEnsureICanCreaeAWish()
        {
            // Arrange
            DateTime base_time = DateTime.Now;
            List<Wish> expected_wishes = new List<Wish>(); // This is our database
            ConnectMocksToDataStore(expected_wishes);
            Family Family1 = new Family { FamilyName = "Rice" };
            string content = "Spring Training";
            mock_wish_set.Setup(j => j.Add(It.IsAny<Wish>())).Callback((Wish s) => expected_wishes.Add(s));
            // Act
            bool successful = repository.CreateWish(Family1, content);

            // Assert
            Assert.AreEqual(1, repository.GetAllWishes().Count);
            // Should this return true?
            //Assert.IsTrue(successful);
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

        [TestMethod]
        public void WhenWeGetMoneyEnsureICanCreateAMoneyPot()
        {
            // Arrange
            DateTime base_time = DateTime.Now;
            List<MoneyPot> expected_money = new List<MoneyPot>(); // This is our database
            ConnectMocksToDataStore(expected_money);
            Family Family1 = new Family { FamilyName = "Rice" };
            decimal dollarAmount = 1001.75m;
            mock_moneyPot_set.Setup(j => j.Add(It.IsAny<MoneyPot>())).Callback((MoneyPot s) => expected_money.Add(s));
            // Act
            bool successful = repository.CreateMoneyPot(Family1, dollarAmount);

            // Assert
            Assert.AreEqual(1, repository.GetAllMoneyPots().Count);

        }

        [TestMethod]
        public void WhenWeGetMoneyRepositoryEnsureICanGetWishesByFamiliyID()
        {
            //Arrange
            List<Wish> expected = new List<Wish>
            {
                new Wish { Author = new Family {FamilyUserID = 7 }, Content = "Disney World", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "disneyworld.com" },
                new Wish { Author = new Family {FamilyUserID = 6 }, Content = "Toyota Prius", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "toyta.com/prius" },
                new Wish { Author = new Family {FamilyUserID = 5 }, Content = "TV", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "sony.com" },
                new Wish { Author = new Family {FamilyUserID = 7 }, Content = "Hard Drive", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "newegg.com" },
                new Wish { Author = new Family {FamilyUserID = 4 }, Content = "Dolly", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "matel.com" },
                new Wish { Author = new Family {FamilyUserID = 3 }, Content = "Beatle's Album", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "amazon.com" },
                new Wish { Author = new Family {FamilyUserID = 2 }, Content = "computer", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "dell.com" },
                new Wish { Author = new Family {FamilyUserID = 1 }, Content = "Samsung Galaxy6", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "samsung.com" },
                new Wish { Author = new Family {FamilyUserID = 6 }, Content = "New Windows", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "windowworld.com" },
                new Wish { Author = new Family {FamilyUserID = 5 }, Content = "Bathroom Renovation", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "homedepot.com" },
                new Wish { Author = new Family {FamilyUserID = 4 }, Content = "Alaskan Cruise", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "carnival.com" },
                new Wish { Author = new Family {FamilyUserID = 3 }, Content = "Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" },
                new Wish { Author = new Family {FamilyUserID = 2 }, Content = "Inground Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" }
            };
            mock_wish_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            List<Family> bratlie =  new List<Family> { new Family() { FamilyUserID = 2, FamilyName = "Bratlie", TypeOfFamily = 4 } };
            mock_family_set.Object.AddRange(bratlie);
            ConnectMocksToDataStore(bratlie);

            List<Wish> expected_wishes = new List<Wish>
            {
                new Wish { Author = new Family {FamilyUserID = 2 }, Content = "computer", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "dell.com" },
                new Wish { Author = new Family {FamilyUserID = 2 }, Content = "Inground Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" }
            };

            //Act
            List<Wish> actual = repository.GetFamilyWishes(bratlie[0]);

            //Assert
            Assert.AreEqual("computer", actual.First().Content);
            //CollectionAssert.AreEqual(expected_wishes, actual);

        }


    }
}
