using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class KnittedFabricInspGreyRepository
    {

        public ErpDbContext db;

        public KnittedFabricInspGreyRepository()
        {
                ErpDbContext db =  new ErpDbContext();
        }
        public void Add(KnittedFabricInspGrey KnittedFabricInspGrey)
        {
            db.KnittedFabricInspGrey.Add(KnittedFabricInspGrey);
            db.SaveChanges();
        }

        public void Edit(KnittedFabricInspGrey KnittedFabricInspGrey)
        {
            try
            {
                var existingRecord = db.KnittedFabricInspGrey.Find(KnittedFabricInspGrey.InspectionCode);
                db.Entry(existingRecord).CurrentValues.SetValues(KnittedFabricInspGrey);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public KnittedFabricInspGrey FindById(string id)
        {
            KnittedFabricInspGrey c = db.KnittedFabricInspGrey.Find(id);
            return c;
        }

        public IEnumerable<KnittedFabricInspGrey> GetAllKnittedFabricInspGrey()
        {
            return db.KnittedFabricInspGrey.ToList();
        }

        public bool IsDuplicate(KnittedFabricInspGrey KnittedFabricInspGrey)
        {
            return false;
        }

        public IEnumerable<KnittedFabricInspGrey> GetAllKnittedFabricInspGreys()
        {
            return db.KnittedFabricInspGrey.ToList();
        }


        public bool Remove(KnittedFabricInspGrey KnittedFabricInspGrey)
        {
            var existingRecord = db.KnittedFabricInspGrey.Find(KnittedFabricInspGrey.InspectionCode);

            if (existingRecord != null)
            {
                db.KnittedFabricInspGrey.Remove(existingRecord);
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