using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhenWeGetMoney.Models;

namespace WhenWeGetMoney.Tests.Models
{
    [TestClass]
    public class WishTests
    {
        [TestMethod]
        public void WishesEnsureCanCreateInstanceOfAWish()
        {
            Wish wish = new Wish();
            Assert.IsNotNull(wish);
        }

        [TestMethod]
        public void WishesEnsureWishHasAllThings()
        {
            Wish wish = new Wish();
            DateTime expected_time = DateTime.Now;
            wish.Author = new Family { FamilyName = "Bernie"};
            wish.Content = "Toyota Prius";
            wish.Date = expected_time;
            wish.WishId = 3;
            wish.WishPriority = 1;
            wish.Picture = "http://www.toyota.com/upcoming-vehicles/prius/";
            wish.WishUrl = "http://www.toyota.com/upcoming-vehicles/prius/";

            Assert.AreEqual("Bernie", wish.Author.FamilyName);
            Assert.AreEqual("Toyota Prius", wish.Content);
            Assert.AreEqual(expected_time, wish.Date);
            Assert.AreEqual(3, wish.WishId);
            Assert.AreEqual(1, wish.WishPriority);
            Assert.AreEqual("http://www.toyota.com/upcoming-vehicles/prius/", wish.Picture);
            Assert.AreEqual("http://www.toyota.com/upcoming-vehicles/prius/", wish.WishUrl);
        }

        [TestMethod]
        public void WishEnsureCanCreateObjectWithInitializerSyntax()
        {
            //Arrange
            DateTime expected_time = DateTime.Now;
            //Act
            Wish wish = new Wish { Author = new Family { FamilyName = "Bernie" }, Content = "Toyota Prius", Date = expected_time, WishId = 3, WishPriority = 1, Picture = "http://www.toyota.com/upcoming-vehicles/prius/", WishUrl = "http://www.toyota.com/upcoming-vehicles/prius/" };
            //Assert
            Assert.AreEqual("Bernie", wish.Author.FamilyName);
            Assert.AreEqual("Toyota Prius", wish.Content);
            Assert.AreEqual(expected_time, wish.Date);
            Assert.AreEqual(3, wish.WishId);
            Assert.AreEqual(1, wish.WishPriority);
            Assert.AreEqual("http://www.toyota.com/upcoming-vehicles/prius/", wish.Picture);
            Assert.AreEqual("http://www.toyota.com/upcoming-vehicles/prius/", wish.WishUrl);
        }
    }
}
