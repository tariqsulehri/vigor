using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CPAFindingNatureRepository : ICPAFindingNatureRepository

    {
        private ErpDbContext db;
        public CPAFindingNatureRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CPAFindingNature CPAFindingNature)
        {
            db.CPAFindingNatures.Add(CPAFindingNature);
            db.SaveChanges();
        }

        public void Edit(CPAFindingNature CPAFindingNature)
        {
            try
            {
                var existingRecord = db.CPAFindingNatures.Find(CPAFindingNature.CPAFindingNatureID);
                db.Entry(existingRecord).CurrentValues.SetValues(CPAFindingNature );
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CPAFindingNature CPAFindingNature)
        {
            var existingRecord = db.CPAFindingNatures.Find(CPAFindingNature.CPAFindingNatureID);

            if (existingRecord != null)
            {
                db.CPAFindingNatures.Remove(existingRecord);
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

        public CPAFindingNature FindById(int CPAFindingNatureID)
        {
            return db.CPAFindingNatures.Find(CPAFindingNatureID);
        }

        public bool IsDuplicate(CPAFindingNature CPAFindingNature)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CPAFindingNature> GetAllCPAFindingNatures()
        {
           return db.CPAFindingNatures.ToList();
        }
    }
}