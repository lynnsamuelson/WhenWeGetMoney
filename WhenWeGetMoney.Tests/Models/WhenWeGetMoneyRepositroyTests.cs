using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WhenWeGetMoney.Models;
using Moq;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WhenWeGetMoney.Tests.Models
{
    [TestClass]
    public class WhenWeGetMoneyRepositroyTests
    {

        private Mock<WhenWeGetMoneyContext> mock_context;
        private Mock<DbSet<Family>> mock_family_set;
        private Mock<DbSet<Wish>> mock_wish_set;
        private ApplicationUser test_user;

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

        
        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<WhenWeGetMoneyContext>();
            mock_family_set = new Mock<DbSet<Family>>();
            mock_wish_set = new Mock<DbSet<Wish>>();
            mock_wish_set = new Mock<DbSet<Wish>>();
            repository = new WhenWeGetMoneyRepository(mock_context.Object);
            test_user = new ApplicationUser { Email = "test5@example.com", Id = "myid-whoo" };
        }



        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_family_set = null;
            mock_wish_set = null;
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
        public void WhenWeGetMoneyEnsureFamilyNameIsAvailable()
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

        //[TestMethod]
        //public void WhenWeGetMoneyEnsureICanSearchByName()
        //{
        //    //Arrange
        //    var expected = new List<Family>
        //    {
        //        new Family {FamilyName = "Rice", TypeOfFamily = 4, FamilyUserID = 8 },
        //        new Family {FamilyName = "Samuelson", TypeOfFamily = 2, FamilyUserID = 6 },
        //        new Family {FamilyName = "Olson", TypeOfFamily = 1, FamilyUserID = 9 },
        //        new Family {FamilyName = "Sonson", TypeOfFamily = 2, FamilyUserID = 7 },
        //        new Family {FamilyName = "Sharsonville", TypeOfFamily = 2, FamilyUserID = 6 }



        //    };
        //    mock_family_set.Object.AddRange(expected);
        //    ConnectMocksToDataStore(expected);
        //    // Act
        //    string search_term = "son";
        //    List<Family> expected_users = new List<Family>
        //    {
        //        new Family {FamilyName = "Olson", TypeOfFamily = 1, FamilyUserID = 9 },
        //        new Family {FamilyName = "Samuelson", TypeOfFamily = 2, FamilyUserID = 6 },
        //        new Family {FamilyName = "Sharsonville", TypeOfFamily = 2, FamilyUserID = 6 },
        //        new Family {FamilyName = "Sonson", TypeOfFamily = 2, FamilyUserID = 7 }
        //    };

        //    List<Family> actual_users = repository.SearchByName(search_term);

        //    // Assert
        //    Assert.AreEqual(expected_users[0].FamilyName, actual_users[0].FamilyName);
        //    Assert.AreEqual(expected_users[1].FamilyName, actual_users[1].FamilyName);
        //    Assert.AreEqual(expected_users[2].FamilyName, actual_users[2].FamilyName);
        //}

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
            string picture = "baseball";
            string url = "www.baseball.com";
            mock_wish_set.Setup(j => j.Add(It.IsAny<Wish>())).Callback((Wish s) => expected_wishes.Add(s));
            // Act
            bool successful = repository.CreateWish(Family1, content, picture, url);

            // Assert
            Assert.AreEqual(1, repository.GetAllWishes().Count);
            // Should this return true?
            //Assert.IsTrue(successful);
        }

       

        [TestMethod]
        public void WhenWeGetMoneyRepositoyEnsureICanCreateAFamily()
        {
            DateTime base_time = DateTime.Now;
            List<Family> family_user_data_source = new List<Family>();
            ConnectMocksToDataStore(family_user_data_source);
            string user_familyname = "Anderson";
            decimal user_money = 0;
            mock_family_set.Setup(j => j.Add(It.IsAny<Family>())).Callback((Family s) => family_user_data_source.Add(s));

            //Act
            bool successful = repository.CreateFamily(test_user, user_familyname, user_money);

            //Assert
            Family family_user = repository.GetAllFamilies().Where(u => u.RealUser.Id == test_user.Id).SingleOrDefault();
            Assert.IsNotNull(family_user);
            Assert.AreEqual(test_user.Id, family_user.RealUser.Id);
            Assert.AreEqual(1, repository.GetAllFamilies().Count);

        }


        [TestMethod]
        public void WhenWeGetMoneyRepositoryEnsureICanNotCreateAFamilyWithDuplicateHandle()
        {
            // Arrange
            DateTime base_time = DateTime.Now;
            List<Family> family_user_data_source = new List<Family>
            {
                new Family { FamilyUserID= 1, FamilyName = "Anderson"}
            };// This is our database table
            ConnectMocksToDataStore(family_user_data_source);
            //string user_id = User.Identity.GetUserId();
            string user_FamilyName = "Anderson";
            decimal user_money = 0;
            // Forces .DbSetd to behave like List.Add
            mock_family_set.Setup(j => j.Add(It.IsAny<Family>())).Callback((Family s) => family_user_data_source.Add(s));

            // Act
            bool successful = repository.CreateFamily(test_user, user_FamilyName, user_money);

            // Assert
            Assert.IsFalse(successful);
            Assert.AreEqual(1, repository.GetAllFamilies().Count);
        }


    }
}
