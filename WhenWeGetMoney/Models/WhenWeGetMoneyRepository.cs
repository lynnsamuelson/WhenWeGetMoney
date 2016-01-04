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
           
            var query = from family in _context.Families where family.FamilyName == FamilyName select family;
            return query.SingleOrDefault();
        }

        public Family GetFamilyById(string FamilyUserID)
        {
            int numbId = Int32.Parse(FamilyUserID);
            var query = from u in _context.Families where u.FamilyUserID == numbId select u;
            return query.SingleOrDefault();
        }

        public List<Wish> GetFamilyWishes(Family user)
        {
            //var query = from u in _context.Families where u.FamilyUserID == user.FamilyUserID select u;
            //Family found_user = query.Single<Family>();
            //return found_user.Wishes.ToList();

            if (user != null)
            {
                var query = from u in _context.Families where u.FamilyUserID == user.FamilyUserID select u;
                Family found_user = query.Single<Family>();

                if (found_user == null)
                {
                    return new List<Wish> { new Wish() { Content = "found_user is null" } };
                }
                return found_user.Wishes.ToList();
            }
            else
            {
                return new List<Wish> { new Wish() { Content = "found_user is in else" } };

            }
        }
        public void DeleteAllUsers()
        {
            Context.Families.RemoveRange(Context.Families);
            Context.SaveChanges();
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

        public bool CreateFamily(ApplicationUser app_user, string new_FamilyName)
        {
            bool handle_is_available = this.IsFamilyNameAvailable(new_FamilyName);
            if (handle_is_available)
            {
                Family new_user = new Family { RealUser = app_user, FamilyName = new_FamilyName };
                bool is_added = true;
                try
                {
                    Family added_user = _context.Families.Add(new_user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    is_added = false;
                }
                return is_added;
            }
            else
            {
                return false;
            }
        }
    }
}