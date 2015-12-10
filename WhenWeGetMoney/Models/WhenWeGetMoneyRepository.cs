using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WhenWeGetMoney.Models
{
    public class WhenWeGetMoneyRepository 
    {

        private WhenWeGetMoneyContext _context;
        public WhenWeGetMoneyContext Context { get  { return _context; } }

        public WhenWeGetMoneyRepository()
        {
            _context = new WhenWeGetMoneyContext();
        }

        public WhenWeGetMoneyRepository(WhenWeGetMoneyContext a_context)
        {
            _context = a_context;
        }

        public List<Family> GetAllFamilies()
        {
            var query = from Families in _context.Families select Families;
            return query.ToList();
        }

        public List<Wish> GetAllWishes()
        {
            var query = from Wishes in _context.Wishes select Wishes;
            return query.ToList();
        }

        public List<MoneyPot> GetAllMoneyPots()
        {
            var query = from MoneyPot in _context.MoneyPots select MoneyPot;
            return query.ToList();
        }

        public Family GetFamilyByName(string FamilyName)
        {
            // SQL: select * from JitterUsers AS users where users.Handle = handle;
            var query = from family in _context.Families where family.FamilyName == FamilyName select family;
            // IQueryable<JitterUser> query = from user in _context.JitterUsers where user.Handle == handle select user;
            // We need to make sure there's exactly one user returned. hmmmm.

            return query.SingleOrDefault();
        }

        public bool IsFamilyNameAvailable(string name)
        {
            bool available = false;
            try
            {
                Family some_user = GetFamilyByName(name);
                if (some_user == null)
                {
                    available = true;
                }
            }
            catch (InvalidOperationException) { }

            return available;
        }

        public List<Family> SearchByName(string search_term)
        {
           
            // SQL: select * from JitterUsers AS users where users.FirstName like '%search_term%' OR users.LastName like '%search_term%';
            var query = from family in _context.Families select family;
            List<Family> found_users = query.Where(user => Regex.IsMatch(user.FamilyName, search_term, RegexOptions.IgnoreCase)).ToList();
            found_users.Sort();
            return found_users;
        }

        public bool CreateWish(Family family1, string content)
        {
            Wish a_wish = new Wish { Content = content, Date = DateTime.Now, Author = family1 };
            bool is_added = true;
            try
            {
                Wish added_wish = _context.Wishes.Add(a_wish);
                _context.SaveChanges();
                // Why is this null? Are the Docs inaccurate?
                /*
                if (added_jot == null)
                {
                    is_added = false;
                }*/
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

        public bool CreateMoneyPot(Family family1, decimal dollarAmount)
        {
            MoneyPot a_dollars = new MoneyPot { DollarAmount = dollarAmount, DateUpdated = DateTime.Now };
            bool is_added = true;
            try
            {
                MoneyPot added_dollars = _context.MoneyPots.Add(a_dollars);
                _context.SaveChanges();
                // Why is this null? Are the Docs inaccurate?
                /*
                if (added_jot == null)
                {
                    is_added = false;
                }*/
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
    }
}