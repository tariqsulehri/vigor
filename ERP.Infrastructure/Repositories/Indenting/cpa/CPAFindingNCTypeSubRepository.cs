using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CPAFindingNCTypeSubRepository : ICPAFindingNCTypeSubRepository
    {
        private ErpDbContext db;
        public CPAFindingNCTypeSubRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CPAFindingNCTypeSub CPAFindingNCTypeSub)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(CPAFindingNCTypeSub CPAFindingNCTypeSub)
        {
            try
            {
                var existingRecord = db.CPAFindingNCTypeSubs.Find(CPAFindingNCTypeSub.CPAFindingNCTypeSubID);
                db.Entry(existingRecord).CurrentValues.SetValues(CPAFindingNCTypeSub);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CPAFindingNCTypeSub CPAFindingNCTypeSub)
        {
            var existingRecord = db.CPAFindingNCTypeSubs.Find(CPAFindingNCTypeSub.CPAFindingNCTypeSubID);

            if (existingRecord != null)
            {
                db.CPAFindingNCTypeSubs.Remove(existingRecord);
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

        public CPAFindingNCTypeSub FindById(int CPAFindingNCTypeSubID)
        {
            return db.CPAFindingNCTypeSubs.Find(CPAFindingNCTypeSubID);
        }

        public bool IsDuplicate(CPAFindingNCTypeSub CPAFindingNCTypeSub)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CPAFindingNCTypeSub> GetAllCPAFindingNCTypeSubs()
        {
            return db.CPAFindingNCTypeSubs.ToList();
        }
    }
}