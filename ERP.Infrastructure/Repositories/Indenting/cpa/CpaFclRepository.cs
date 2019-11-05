using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CpaFclRepository : ICpaFclRepository
    {
        private ErpDbContext db;
        public CpaFclRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CpaFcl CpaFcl)
        {
            db.CpaFcl.Add(CpaFcl);
            db.SaveChanges();
        }

        public void Edit(CpaFcl CpaFcl)
        {
            try
            {
                var existingRecord = db.CpaFcl.Find(CpaFcl.CPaNo);
                db.Entry(existingRecord).CurrentValues.SetValues(CpaFcl);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CpaFcl CpaFcl)
        {
            var existingRecord = db.CpaFcl.Find(CpaFcl.CPaNo);

            if (existingRecord != null)
            {
                db.CpaFcl.Remove(existingRecord);
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

        public CpaFcl FindById(string CpaFclNo)
        {
            CpaFcl rc = db.CpaFcl.Find(CpaFclNo);
            return rc;
        }

        public bool IsDuplicate(CpaFcl CpaFcl)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CpaFcl> GetAllCpaFcls()
        {
            return db.CpaFcl.ToList();
        }
    }
}