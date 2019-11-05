using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.Inspection;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class KnittedFabricInspectionRepository : IKnittedFabricInspectionRepository
    {
        public ErpDbContext db;
        public KnittedFabricInspectionRepository()
        {
                db =  new ErpDbContext();
        }
        public void Add(KnittedFabricInspection KnittedFabricInspection)
        {
            db.KnittedFabricInspections.Add(KnittedFabricInspection);
            db.SaveChanges();
        }

        public void Edit(KnittedFabricInspection KnittedFabricInspection)
        {
            try
            {
                var existingRecord = db.KnittedFabricInspections.Find(KnittedFabricInspection.InspectionID);
                db.Entry(existingRecord).CurrentValues.SetValues(KnittedFabricInspection);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public KnittedFabricInspection FindById(string id)
        {
            KnittedFabricInspection c = db.KnittedFabricInspections.Find(id);
            return c;
        }

        public IEnumerable<KnittedFabricInspection> GetAllKnittedFabricInspection()
        {
            return db.KnittedFabricInspections.ToList();
        }

        public bool IsDuplicate(KnittedFabricInspection KnittedFabricInspection)
        {
            return false;
        }

        public IEnumerable<KnittedFabricInspection> GetAllKnittedFabricInspections()
        {
            return db.KnittedFabricInspections.ToList();
        }


        public bool Remove(KnittedFabricInspection KnittedFabricInspection)
        {
            var existingRecord = db.KnittedFabricInspections.Find(KnittedFabricInspection.InspectionID);

            if (existingRecord != null)
            {
                db.KnittedFabricInspections.Remove(existingRecord);
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