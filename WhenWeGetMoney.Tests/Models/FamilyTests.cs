using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhenWeGetMoney.Models;

namespace WhenWeGetMoney.Tests.Models
{
    [TestClass]
    public class FamilyTests
    {
        [TestMethod]
        public void FamilyCanCreateInstanceOfAFamily()
        {
            Family family = new Family();
            Assert.IsNotNull(family);
        }

        [TestMethod]
        public void FamilyEnsureIHaveAllTheThings()
        {
            Family family = new Family();
            family.FamilyUserID = 1;
            family.TypeOfFamily = 4;
            Assert.AreEqual(1, family.FamilyUserID);
            Assert.AreEqual(4, family.TypeOfFamily);
        }
    }
}
