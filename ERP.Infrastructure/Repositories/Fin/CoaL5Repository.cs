using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class CoaL5Repository : ICoaL5Repository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(CoaL5 coaL5)
        {
            _db.CoaL5.Add(coaL5);
            _db.SaveChanges();
        }
        public void Edit(CoaL5 coaL5)
        {
			 CoaL5 oldCoaL5 = _db.CoaL5.Find(coaL5.L5Code);
            if (oldCoaL5 != null)
            {
                oldCoaL5.Title = coaL5.Title;
                oldCoaL5.Active = coaL5.Active;
                oldCoaL5.BookType = coaL5.BookType;
                oldCoaL5.IsCust = coaL5.IsCust;
                oldCoaL5.IsDept = coaL5.IsDept;
                oldCoaL5.IsEmp = coaL5.IsEmp;
                oldCoaL5.IsLoc = coaL5.IsLoc;
                oldCoaL5.CreatedBy = coaL5.CreatedBy;
                oldCoaL5.CreatedOn = coaL5.CreatedOn;
                oldCoaL5.ModifiedBy = coaL5.ModifiedBy;
                oldCoaL5.ModifiedOn = coaL5.ModifiedOn;
                _db.Entry(oldCoaL5).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
		 public bool IsDuplicate(CoaL5 coaL5)
        {

            if (string.IsNullOrEmpty(coaL5.L5Code)) { return _db.CoaL5.Any(x => x.Title == coaL5.Title); }
            if (!string.IsNullOrEmpty(coaL5.L5Code))
            {
                CoaL5 oldCoaL5 = _db.CoaL5.FirstOrDefault(x => x.Title == coaL5.Title);
                if (oldCoaL5 != null && oldCoaL5.L5Code != coaL5.L5Code)
                {
                    return true;
                }
            }
            return false;
        }									
        public bool Remove(string l5Code)
        {
            var existingAccount = _db.CoaL5.Find(l5Code);
            if (existingAccount != null)
            {
                _db.CoaL5.Remove(existingAccount);
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

        public CoaL5 FindById(string l5Code)
        {
            var account = _db.CoaL5.Find(l5Code);
            return account;
        }


        public IEnumerable<CoaL5> GetL5Accounts()
        {
            IEnumerable<CoaL5> accounts = _db.CoaL5.ToList();
            return accounts;
        }

    }
}
