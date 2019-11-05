using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CpaRepository : ICpaRepository
    {
        private ErpDbContext db;

        public CpaRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(Cpa Cpa)
        {
            db.Cpas.Add(Cpa);
            db.SaveChanges();
        }

        public void Edit(Cpa Cpa)
        {
            try
            {
                var existingRecord = db.Cpas.Find(Cpa.CpaNo);
                db.Entry(existingRecord).CurrentValues.SetValues(Cpa);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(Cpa Cpa)
        {
            var existingRecord = db.Cpas.Find(Cpa.CpaNo);

            if (existingRecord != null)
            {
                db.Cpas.Remove(existingRecord);
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

        public Cpa FindById(string CpaNo)
        {
            return db.Cpas.Find(CpaNo);
        }

        public bool IsDuplicate(Cpa Cpa)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cpa> GetAllCpas()
        {
            return db.Cpas.ToList();
        }
    }
}