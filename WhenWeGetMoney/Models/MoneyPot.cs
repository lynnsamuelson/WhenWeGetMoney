using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhenWeGetMoney.Models
{
    public class MoneyPot
    {
        public virtual Family FundsAvailable { get; set; }
        public decimal DollarAmount { get; set; }
        [key]
        public int MoneyPotId { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}