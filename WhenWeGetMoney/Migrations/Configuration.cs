namespace WhenWeGetMoney.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WhenWeGetMoney.Models.WhenWeGetMoneyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WhenWeGetMoney.Models.WhenWeGetMoneyContext context)
        {
           context.MoneyPots.AddOrUpdate(p => p.DollarAmount,
           new MoneyPot() { DollarAmount = 1001.71m, DateUpdated = DateTime.Now },
           new MoneyPot() { DollarAmount = 1891.34m, DateUpdated = DateTime.Now },
           new MoneyPot() { DollarAmount = 171.82m, DateUpdated = DateTime.Now },
           new MoneyPot() { DollarAmount = 10091.44m, DateUpdated = DateTime.Now },
           new MoneyPot() { DollarAmount = 4001.01m, DateUpdated = DateTime.Now },
           new MoneyPot() { DollarAmount = 21.01m, DateUpdated = DateTime.Now }
           );
           

            context.Families.AddOrUpdate(p => p.FamilyName,
                new Family() { FamilyName = "Bratlie", TypeOfFamily = 4, money = context.MoneyPots.Single<MoneyPot>(s => s.MoneyPotId == 1) },
                new Family() { FamilyName = "Rice", TypeOfFamily = 2, money = context.MoneyPots.Single<MoneyPot>(s => s.MoneyPotId == 2) },
                new Family() { FamilyName = "Anderson", TypeOfFamily = 1, money = context.MoneyPots.Single<MoneyPot>(s => s.MoneyPotId == 3) },
                new Family() { FamilyName = "Wade", TypeOfFamily = 2, money = context.MoneyPots.Single<MoneyPot>(s => s.MoneyPotId == 4)},
                new Family() { FamilyName = "Roberts", TypeOfFamily = 2, money = context.MoneyPots.Single<MoneyPot>(s => s.MoneyPotId == 5) },
                new Family() { FamilyName = "Lambert", TypeOfFamily = 2, money = context.MoneyPots.Single<MoneyPot>(s => s.MoneyPotId == 6) }
                );

            context.Wishes.AddOrUpdate(p => p.Content,
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 5), Content = "Disney World", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "disneyworld.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 6), Content = "Toyota Prius", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "toyta.com/prius" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 7), Content = "TV", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "sony.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 8), Content = "Hard Drive", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "newegg.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 9), Content = "Dolly", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "matel.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 10), Content = "Beatle's Album", Date = DateTime.Now, WishPriority = 2, Picture = "google.com", WishUrl = "amazon.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 5), Content = "computer", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "dell.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 6), Content = "Samsung Galaxy6", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "samsung.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 7), Content = "New Windows", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "windowworld.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 8), Content = "Bathroom Renovation", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "homedepot.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 9), Content = "Alaskan Cruise", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "carnival.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 10), Content = "Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" },
                new Wish { Author = context.Families.Single<Family>(s => s.FamilyUserID == 7), Content = "Inground Pool", Date = DateTime.Now, WishPriority = 1, Picture = "google.com", WishUrl = "pools.com" }

                );



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
