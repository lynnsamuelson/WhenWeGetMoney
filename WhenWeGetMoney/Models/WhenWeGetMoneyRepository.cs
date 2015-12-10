using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}