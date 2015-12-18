using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WhenWeGetMoney;

namespace WhenWeGetMoney.Models
{
    public class Family : IComparable
    {

        [Key]
        public int FamilyUserID { get; set; }
        public string FamilyName { get; set; }
        public int TypeOfFamily { get; set; }

        public List<Wish> Wishes { get; set; }
        public virtual MoneyPot money { get; set; }

        public int CompareTo(object obj)
        {
            Family other_family = obj as Family;
            int answer = this.FamilyName.CompareTo(other_family.FamilyName);
            return answer;
        }

        //public void AddWishToFamily(Wish wishToAdd)
        //{
        //    wishToAdd.Author = this;
        //}
    }
}