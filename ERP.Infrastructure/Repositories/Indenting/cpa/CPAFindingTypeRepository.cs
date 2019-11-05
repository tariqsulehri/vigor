using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CPAFindingTypeRepository : ICPAFindingTypeRepository
    {
        private ErpDbContext db;
        public CPAFindingTypeRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CPAFindingType CPAFindingType)
        {
            db.CPAFindingTypes.Add(CPAFindingType);
            db.SaveChanges();
        }

        public void Edit(CPAFindingType CPAFindingType)
        {
            try
            {
                var existingRecord = db.CPAFindingTypes.Find(CPAFindingType.CPAFindingID);
                db.Entry(existingRecord).CurrentValues.SetValues(CPAFindingType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CPAFindingType CPAFindingType)
        {
            var existingRecord = db.CPAFindingTypes.Find(CPAFindingType.CPAFindingID);

            if (existingRecord != null)
            {
                db.CPAFindingTypes.Remove(existingRecord);
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

        public CPAFindingType FindById(int CPAFindingID)
        {
            CPAFindingType ft = db.CPAFindingTypes.Find(CPAFindingID);
            return ft;
        }

        public bool IsDuplicate(CPAFindingType CPAFindingType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CPAFindingType> GetAllCPAFindingTypes()
        {
            return db.CPAFindingTypes.ToList();
        }
    }
}