using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CpaTypesRepository : ICpaTypesRepository
    {
        private ErpDbContext db;

        public CpaTypesRepository()
        {
            db = new ErpDbContext();
        }


        public void Add(CpaTypes CpaTypes)
        {
            db.CpaTypes.Add(CpaTypes);
            db.SaveChanges();
        }

        public void Edit(CpaTypes CpaTypes)
        {
            try
            {
                var existingRecord = db.CpaTypes.Find(CpaTypes.CpaType1);
                db.Entry(existingRecord).CurrentValues.SetValues(CpaTypes);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CpaTypes CpaTypes)
        {
            var existingRecord = db.CpaTypes.Find(CpaTypes.CpaType1);

            if (existingRecord != null)
            {
                db.CpaTypes.Remove(existingRecord);
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

        public CpaTypes FindById(string CpaTypesNo)
        {
            return db.CpaTypes.Find(CpaTypesNo);
        }

        public bool IsDuplicate(CpaTypes CpaTypes)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CpaTypes> GetAllCpaTypes()
        {
            return db.CpaTypes.ToList();
        }
    }
}