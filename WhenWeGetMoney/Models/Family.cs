using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhenWeGetMoney.Models
{
    public class Family
    {

        [Key]
        public int FamilyUserID { get; set; }
        public int TypeOfFamily { get; set; }


      

    }
}