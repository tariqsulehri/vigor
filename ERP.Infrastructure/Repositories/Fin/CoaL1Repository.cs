using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class CoaL1Repository : ICoaL1Repository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(CoaL1 coaL1)
        {
            _db.CoaL1.Add(coaL1);
            _db.SaveChanges();
        }
        public void Edit(CoaL1 coaL1)
        {
            _db.Entry(coaL1).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(string l1Code)
        {
            var existingAccount = _db.CoaL1.Find(l1Code);

            if (existingAccount != null)
            {
                _db.CoaL1.Remove(existingAccount);
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
        public CoaL1 FindById(string l1Code)
        {
            var account = _db.CoaL1.Find(l1Code);
            return account;
        }
        public IEnumerable<CoaL1> GetL1Accounts()
        {
            IEnumerable<CoaL1> accounts = _db.CoaL1.ToList();
            return accounts;
        }
        public bool IsDuplicate(CoaL1 coaL1)
        {
            if (string.IsNullOrEmpty(coaL1.L1Code)) { return _db.CoaL5.Any(x => x.Title == coaL1.Title); }
            if (!string.IsNullOrEmpty(coaL1.L1Code))
            {
                CoaL1 oldCoaL1 = _db.CoaL1.FirstOrDefault(x => x.Title == coaL1.Title);
                if (oldCoaL1 != null && oldCoaL1.L1Code != coaL1.L1Code)
                {
                    return true;
                }
            }
            return false;
        }									
    }
}
