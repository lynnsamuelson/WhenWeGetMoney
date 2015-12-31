using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhenWeGetMoney.Controllers;
using WhenWeGetMoney.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Moq;
using Newtonsoft.Json;

namespace WhenWeGetMoney.Tests.Controllers
{
   
    [TestClass]
    public class WishControllerTests
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

        //[TestMethod]
        //public void WishControllerEnsureICanGetAllWishes()
        //{
        //    // Arrange
        //    mock_wish_set = new Mock<DbSet<Wish>>();
        //    mock_context = new Mock<WhenWeGetMoneyContext>();
        //    WhenWeGetMoneyRepository repositoroy = new WhenWeGetMoneyRepository(mock_context.Object);

        //    List<Wish> expected = new List<Wish>
        //    {
        //        new Wish { Author = new Family {FamilyUserID = "7" }, Content = "Disney World", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "disneyworld.com" },
        //        new Wish { Author = new Family {FamilyUserID = 6 }, Content = "Toyota Prius", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "toyta.com/prius" },
        //        new Wish { Author = new Family {FamilyUserID = 5 }, Content = "TV", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "sony.com" },
        //        new Wish { Author = new Family {FamilyUserID = 7 }, Content = "Hard Drive", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "newegg.com" },
        //        new Wish { Author = new Family {FamilyUserID = 4 }, Content = "Dolly", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "matel.com" },
        //        new Wish { Author = new Family {FamilyUserID = 3 }, Content = "Beatle's Album", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "amazon.com" },
        //        new Wish { Author = new Family {FamilyUserID = 2 }, Content = "computer", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "dell.com" },
        //        new Wish { Author = new Family {FamilyUserID = 1 }, Content = "Samsung Galaxy6", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "samsung.com" },
        //        new Wish { Author = new Family {FamilyUserID = 6 }, Content = "New Windows", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "windowworld.com" },
        //        new Wish { Author = new Family {FamilyUserID = 5 }, Content = "Bathroom Renovation", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "homedepot.com" },
        //        new Wish { Author = new Family {FamilyUserID = 4 }, Content = "Alaskan Cruise", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "carnival.com" },
        //        new Wish { Author = new Family {FamilyUserID = 3 }, Content = "Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" },
        //        new Wish { Author = new Family {FamilyUserID = 2 }, Content = "Inground Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" }

        //    };
        //    mock_wish_set.Object.AddRange(expected);
        //    ConnectMocksToDataStore(expected);

        //    TestController my_controller = new TestController(repositoroy);

        //    // Act
        //    String actual = my_controller.Get();
        //    var json = JsonConvert.SerializeObject(expected);

        //    //Assert
        //    Assert.AreEqual(json, actual);
        //}

        [TestMethod]
        public void WishControllerICanGetWishesFromCurrentUser()
        {

        }
    }
}
