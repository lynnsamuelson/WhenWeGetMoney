using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhenWeGetMoney.Models;

namespace WhenWeGetMoney.Tests.Models
{
    [TestClass]
    public class MoneyPotTests
    {
        [TestMethod]
        public void MoneyPotEnsureCanCreateInstanceOf()
        {
            MoneyPot money = new MoneyPot();
            Assert.IsNotNull(money);
        }

        [TestMethod]
        public void MoneyPotEnsureHasAllTheThings()
        {
            MoneyPot money = new MoneyPot();
            DateTime expected_time = DateTime.Now;
            //money.DollarAmount = 1001.01m;
            money.MoneyPotId = 2;
            //money.DateUpdated = expected_time;
            //Assert.AreEqual(1001.01m, money.DollarAmount);
            Assert.AreEqual(2, money.MoneyPotId);
            //Assert.AreEqual(expected_time, money.DateUpdated);
        }
        [TestMethod]
        public void MoneyPotEnsureThingsCanBeCreatedWithInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;
            MoneyPot money = new MoneyPot { /*DollarAmount = 1001.01m,*/ MoneyPotId = 2/*, DateUpdated = expected_time*/ };
            //Assert.AreEqual(1001.01m, money.DollarAmount);
            Assert.AreEqual(2, money.MoneyPotId);
            //Assert.AreEqual(expected_time, money.DateUpdated);

        }
    }
}
