﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhenWeGetMoney.Models
{
    public class Wish
    {
        public object Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int WishId { get; set; }
        public int WishPriority { get; set; }
        public string Picture { get; set; }
        public string WishUrl { get; set; }

    }
}