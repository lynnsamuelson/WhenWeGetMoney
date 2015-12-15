using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhenWeGetMoney.Models
{
    public class Wish
    {
        public virtual Family Author { get; set; }
        [MaxLength(75)]
        [MinLength(1)]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [key]
        public int WishId { get; set; }
        public int WishPriority { get; set; }
        public string Picture { get; set; }
        public string WishUrl { get; set; }

    }
}