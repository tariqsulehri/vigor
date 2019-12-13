using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class KnittedFabricInspBleachedRepository
    {
        public ErpDbContext db;

        public KnittedFabricInspBleachedRepository()
        {
              ErpDbContext db = new ErpDbContext();  
        }
        public void Add(KnittedFabricInspBleached KnittedFabricInspBleached)
        {
            db.KnittedFabricInspBleacheds.Add(KnittedFabricInspBleached);
            db.SaveChanges();
        }

        public void Edit(KnittedFabricInspBleached KnittedFabricInspBleached)
        {
            //try
            //{
            //    var existingRecord = db.KnittedFabricInspBleacheds.Find(KnittedFabricInspBleached);
            //    db.Entry(existingRecord).CurrentValues.SetValues(KnittedFabricInspBleached);
            //    db.SaveChanges();

            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);  
            //    throw ex;
            //}
        }

        public KnittedFabricInspBleached FindById(string id)
        {
            KnittedFabricInspBleached c = db.KnittedFabricInspBleacheds.Find(id);
            return c;
        }

        public IEnumerable<KnittedFabricInspBleached> GetAllKnittedFabricInspBleached()
        {
            return db.KnittedFabricInspBleacheds.ToList();
        }

        public bool IsDuplicate(KnittedFabricInspBleached KnittedFabricInspBleached)
        {
            return false;
        }

        public IEnumerable<KnittedFabricInspBleached> GetAllKnittedFabricInspBleacheds()
        {
            return db.KnittedFabricInspBleacheds.ToList();
        }


       public bool Remove(KnittedFabricInspBleached KnittedFabricInspBleached)
        {
            //var existingRecord = db.KnittedFabricInspBleacheds.Find(KnittedFabricInspBleached.InspectionCode);

            //if (existingRecord != null)
            //{
            //    db.KnittedFabricInspBleacheds.Remove(existingRecord);
            //}

            //if (db.SaveChanges() == 1)
            //{
            //    return true;

            //}
            //else
            //{
            //    return false;
            //};
            return true;
        }
    }
}