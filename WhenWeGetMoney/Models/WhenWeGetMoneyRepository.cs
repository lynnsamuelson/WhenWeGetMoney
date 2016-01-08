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

        

        public Family GetFamilyByName(string FamilyName)
        {
           
            var query = from family in _context.Families where family.FamilyName == FamilyName select family;
            return query.SingleOrDefault();
        }

        public Family GetFamilyById(string FamilyUserID)
        {
            //int numbId = Int32.Parse(FamilyUserID);
            var query = from u in _context.Families where u.RealUser.Id == FamilyUserID select u;
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
                Family found_user = query.SingleOrDefault<Family>();

                var wishQuery = from wish in _context.Wishes where wish.Author.FamilyUserID == user.FamilyUserID select wish;
                var familyWishes = wishQuery.ToList();

                if (found_user == null)
                {
                    return new List<Wish> { new Wish() { Content = "found_user is null" } };
                }
                return familyWishes;
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

        public void DeleteWish(Wish family_wish)
        {
            //Context.Wishes.RemoveRange(Context.Wishes);
            Context.Wishes.Remove(family_wish);
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

        public bool CreateWish(Family family1, string content, string picture, string wishUrl)
        {
            Wish a_wish = new Wish { Content = content, Date = DateTime.Now, Author = family1, Picture = picture, WishUrl = wishUrl };
            bool is_added = true;
            try
            {
                Wish added_wish = _context.Wishes.Add(a_wish);
                _context.SaveChanges();
               
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

       

        public bool CreateFamily(ApplicationUser app_user, string familyName, decimal dollarAmount)
        { 
            decimal decimalAmount = System.Convert.ToDecimal(dollarAmount);


            bool handle_is_available = this.IsFamilyNameAvailable(familyName);
            if (handle_is_available)
            {
                Family new_user = new Family { RealUser = app_user, FamilyName = familyName, DollarAmount = decimalAmount, MoneyUpdated = DateTime.Now };
               
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