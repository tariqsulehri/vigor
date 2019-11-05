using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CPAFindingNCTypeRepository : ICPAFindingNCTypeRepository
    {
        private ErpDbContext db;

        public CPAFindingNCTypeRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CPAFindingNCType CPAFindingNCType)
        {
            db.CpaFindingNcTypes.Add(CPAFindingNCType);
            db.SaveChanges();
        }

        public void Edit(CPAFindingNCType CPAFindingNCType)
        {
            try
            {
                var existingRecord = db.CpaFindingNcTypes.Find(CPAFindingNCType.CPAFindingNCTypeID);
                db.Entry(existingRecord).CurrentValues.SetValues(CPAFindingNCType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool Remove(CPAFindingNCType CPAFindingNCType)
        {
            var existingRecord = db.CpaFindingNcTypes.Find(CPAFindingNCType.CPAFindingNCTypeID);

            if (existingRecord != null)
            {
                db.CpaFindingNcTypes.Remove(existingRecord);
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

        public CPAFindingNCType FindById(int CPAFindingNCTypeID)
        {
            return db.CpaFindingNcTypes.Find(CPAFindingNCTypeID);
        }

        public bool IsDuplicate(CPAFindingNCType CPAFindingNCType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CPAFindingNCType> GetAllCPAFindingNCTypes()
        {
            return db.CpaFindingNcTypes.ToList();
        }
    }
}