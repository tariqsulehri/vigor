using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class CoaL2Repository : ICoaL2Repository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(CoaL2 coaL2)
        {
            _db.CoaL2.Add(coaL2);
            _db.SaveChanges();
        }
        public void Edit(CoaL2 coaL2)
        {
			CoaL2 oldCoaL2 = _db.CoaL2.Find(coaL2.L2Code);
            if (oldCoaL2 != null)
            {
                coaL2.L1Code = oldCoaL2.L1Code;
                oldCoaL2.Title = coaL2.Title;
                oldCoaL2.Active = coaL2.Active;
                _db.Entry(oldCoaL2).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }					 
        }
			  public bool IsDuplicate(CoaL2 coaL2)
        {

            if (string.IsNullOrEmpty(coaL2.L2Code)) { return _db.CoaL2.Any(x => x.Title == coaL2.Title); }
            if (!string.IsNullOrEmpty(coaL2.L2Code))
            {
                CoaL2 oldCoaL2 = _db.CoaL2.FirstOrDefault(x => x.Title == coaL2.Title);
                if (oldCoaL2 != null && oldCoaL2.L2Code != coaL2.L2Code)
                {
                    return true;
                }
            }
            return false;
        }																							  

        public bool Remove(string l2Code)
        {
            var existingAccount = _db.CoaL2.Find(l2Code);

            if (existingAccount != null)
            {
                _db.CoaL2.Remove(existingAccount);
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

        public CoaL2 FindById(string l2Code)
        {
            var account = _db.CoaL2.Find(l2Code);
            return account;
        }
        public IEnumerable<CoaL2> GetL2Accounts()
        {
            IEnumerable<CoaL2> accounts = _db.CoaL2.ToList();
            return accounts;
        }
        
    }
}
