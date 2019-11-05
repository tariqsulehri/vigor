using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class FabInspTypePerformedRepository
    {
        private ErpDbContext db;

        public FabInspTypePerformedRepository()
        {
            ErpDbContext db = new ErpDbContext();    
        }

        public void Add(FabInspTypePerformed FabInspTypePerformed)
        {
            db.FabInspTypePerformed.Add(FabInspTypePerformed);
            db.SaveChanges();
        }

        public void Edit(FabInspTypePerformed FabInspTypePerformed)
        {
            try
            {
                var existingRecord = db.FabInspTypePerformed.Find(FabInspTypePerformed);
                db.Entry(existingRecord).CurrentValues.SetValues(FabInspTypePerformed);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabInspTypePerformed FindById(string id)
        {
            FabInspTypePerformed c = db.FabInspTypePerformed.Find(id);
            return c;
        }

        public IEnumerable<FabInspTypePerformed> GetAllFabInspTypePerformed()
        {
            return db.FabInspTypePerformed.ToList();
        }

        public bool IsDuplicate(FabInspTypePerformed FabInspTypePerformed)
        {
            return false;
        }

        public IEnumerable<FabInspTypePerformed> GetAllFabInspTypePerformeds()
        {
            return db.FabInspTypePerformed.ToList();
        }


        public bool Remove(FabInspTypePerformed FabInspTypePerformed)
        {
            var existingRecord = db.FabInspTypePerformed.Find(FabInspTypePerformed.InspTypePerformedID);

            if (existingRecord != null)
            {
                db.FabInspTypePerformed.Remove(existingRecord);
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