using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CpaNcTypeRepository : ICpaNcTypeRepository
    {
        private ErpDbContext db;

        public CpaNcTypeRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(CpaNcType CpaNcType)
        {
            db.CpaNcTypes.Add(CpaNcType);
            db.SaveChanges();
        }

        public void Edit(CpaNcType CpaNcType)
        {
            try
            {
                var existingRecord = db.CpaNcTypes.Find(CpaNcType.CPAFindingID);
                db.Entry(existingRecord).CurrentValues.SetValues(CpaNcType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public CpaNcType FindById(string CpaNcTypeNo)
        {
            return db.CpaNcTypes.Find(CpaNcTypeNo);
        }

        public IEnumerable<CpaNcType> GetAllCpaNCTypes()
        {
            return db.CpaNcTypes.ToList();
        }

        public bool IsDuplicate(CpaNcType CpaNCType)
        {
            throw new NotImplementedException();
        }

        public bool Remove(CpaNcType CpaNcType)
        {
            var existingRecord = db.CpaNcTypes.Find(CpaNcType.CPAFindingID);

            if (existingRecord != null)
            {
                db.CpaNcTypes.Remove(existingRecord);
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