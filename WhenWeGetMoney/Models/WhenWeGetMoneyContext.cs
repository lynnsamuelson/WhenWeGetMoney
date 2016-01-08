using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WhenWeGetMoney.Models
{
    public class WhenWeGetMoneyContext : ApplicationDbContext
    {
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }
    }
}