using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.Inspection;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class KnittedFabricInspDyedRepository: IKnittedFabricInspDyedRepository
    {
        public ErpDbContext db;
        public KnittedFabricInspDyedRepository()
        {
                db=  new ErpDbContext();
        }
        public void Add(KnittedFabricInspDyed KnittedFabricInspDyed)
        {
            db.KnittedFabricInspDyed.Add(KnittedFabricInspDyed);
            db.SaveChanges();
        }

        public void Edit(KnittedFabricInspDyed KnittedFabricInspDyed)
        {
            //try
            //{
            //    var existingRecord = db.KnittedFabricInspDyed.Find(KnittedFabricInspDyed.InspectionCode);
            //    db.Entry(existingRecord).CurrentValues.SetValues(KnittedFabricInspDyed);
            //    db.SaveChanges();

            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);  
            //    throw ex;
            //}
        }

        public KnittedFabricInspDyed FindById(string id)
        {
            KnittedFabricInspDyed c = db.KnittedFabricInspDyed.Find(id);
            return c;
        }

        public IEnumerable<KnittedFabricInspDyed> GetAllKnittedFabricInspDyed()
        {
            return db.KnittedFabricInspDyed.ToList();
        }

        public bool IsDuplicate(KnittedFabricInspDyed KnittedFabricInspDyed)
        {
            return false;
        }

        public IEnumerable<KnittedFabricInspDyed> GetAllKnittedFabricInspDyeds()
        {
            return db.KnittedFabricInspDyed.ToList();
        }


        public bool Remove(KnittedFabricInspDyed KnittedFabricInspDyed)
        {

            //var existingRecord = db.KnittedFabricInspDyed.Find(KnittedFabricInspDyed.InspectionCode);

            //if (existingRecord != null)
            //{
            //    db.KnittedFabricInspDyed.Remove(existingRecord);
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