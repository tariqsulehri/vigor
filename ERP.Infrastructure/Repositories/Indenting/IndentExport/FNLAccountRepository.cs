using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentExport
{
    public class FNLAccountRepository
    {

        ErpDbContext db;
        public FNLAccountRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(FNLAccount FNLAccount)
        {
            db.FNLAccounts.Add(FNLAccount);
            db.SaveChanges();
        }

        public void Edit(FNLAccount FNLAccount)
        {
            try
            {
                var existingRecord = db.FNLAccounts.Find(FNLAccount.FNLAccountID);
                db.Entry(existingRecord).CurrentValues.SetValues(FNLAccount);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }

        public FNLAccount FindById(int id)
        {
            var rev = db.FNLAccounts.Find(id);
            return rev;
        }

        public IEnumerable<FNLAccount> GetAllFNLAccounts()
        {
            IEnumerable<FNLAccount> inqs = db.FNLAccounts.ToList();
            return inqs;
        }

        public bool IsDuplicate(FNLAccount FNLAccount)
        {
            if (FNLAccount.FNLAccountID == "")
            {
                return db.FNLAccounts.Any(x => x.DebtorAccount == FNLAccount.DebtorAccount);
            }

            if (FNLAccount.FNLAccountID != "")
            {
                FNLAccount rc = db.FNLAccounts.FirstOrDefault(x => x.DebtorAccount == FNLAccount.DebtorAccount);
                if (rc != null && rc.FNLAccountID != FNLAccount.FNLAccountID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(FNLAccount FNLAccount)
        {
            var existingRecord = db.FNLAccounts.Find(FNLAccount.FNLAccountID);

            if (existingRecord != null)
            {
                db.FNLAccounts.Remove(existingRecord);
            }

            if (db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }
    }
}
