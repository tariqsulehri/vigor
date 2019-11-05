using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class CoaL3Repository : ICoaL3Repository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(CoaL3 coaL3)
        {
            _db.CoaL3.Add(coaL3);
            _db.SaveChanges();
        }
        public void Edit(CoaL3 coaL3)
        {
				 CoaL3 oldCoaL3 = _db.CoaL3.Find(coaL3.L3Code);
            if (oldCoaL3 != null)
            {
                oldCoaL3.Title = coaL3.Title;
                oldCoaL3.Active = coaL3.Active;
                _db.Entry(oldCoaL3).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }				 
		
        }
		 public bool IsDuplicate(CoaL3 CoaL3)
        {

            if (string.IsNullOrEmpty(CoaL3.L3Code)) { return _db.CoaL3.Any(x => x.Title == CoaL3.Title); }
            if (!string.IsNullOrEmpty(CoaL3.L3Code))
            {
                CoaL3 oldCoaL3 = _db.CoaL3.FirstOrDefault(x => x.Title == CoaL3.Title);
                if (oldCoaL3 != null && oldCoaL3.L3Code != CoaL3.L3Code)
                {
                    return true;
                }
            }
            return false;
        }																								  
        public bool Remove(string l3Code)
        {
            var existingAccount = _db.CoaL3.Find(l3Code);

            if (existingAccount != null)
            {
                _db.CoaL3.Remove(existingAccount);
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

        public CoaL3 FindById(string l3Code)
        {
            var account = _db.CoaL3.Find(l3Code);
            return account;
        }
        public IEnumerable<CoaL3> GetL3Accounts()
        {
            IEnumerable<CoaL3> accounts = _db.CoaL3.ToList();
            return accounts;
        }

    }
}
