using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class CoaL4Repository : ICoaL4Repository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(CoaL4 coaL4)
        {
            _db.CoaL4.Add(coaL4);
            _db.SaveChanges();
        }
        public void Edit(CoaL4 coaL4)
        {
		 CoaL4 oldCoaL4 = _db.CoaL4.Find(coaL4.L4Code);
            if (oldCoaL4 != null)
            {
                oldCoaL4.Title = coaL4.Title;
                oldCoaL4.Active = coaL4.Active;
                _db.Entry(oldCoaL4).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }												  
			
        }
			  public bool IsDuplicate(CoaL4 coaL4)
        {

            if (string.IsNullOrEmpty(coaL4.L4Code)) { return _db.CoaL4.Any(x => x.Title == coaL4.Title); }
            if (!string.IsNullOrEmpty(coaL4.L4Code))
            {
                CoaL4 oldCoaL4 = _db.CoaL4.FirstOrDefault(x => x.Title == coaL4.Title);
                if (oldCoaL4 != null && oldCoaL4.L4Code != coaL4.L4Code)
                {
                    return true;
                }
            }
            return false;
        }																							  

        public bool Remove(string l4Code)
        {
            var existingAccount = _db.CoaL4.Find(l4Code);
            if (existingAccount != null)
            {
                _db.CoaL4.Remove(existingAccount);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }

        public CoaL4 FindById(string l4Code)
        {
            var account = _db.CoaL4.Find(l4Code);
            return account;
        }
        public IEnumerable<CoaL4> GetL4Accounts()
        {
            IEnumerable<CoaL4> accounts = _db.CoaL4.ToList();
            return accounts;
        }

    }
}
