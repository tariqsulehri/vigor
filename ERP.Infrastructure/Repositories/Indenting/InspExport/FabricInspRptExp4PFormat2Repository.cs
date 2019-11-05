using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.InspExport;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Infrastructure.Repositories.Indenting.InspExport
{
    public class FabricInspRptExp4PFormat2Repository : IFabricInspRptExp4PFormat2Repository
    {
        private ErpDbContext db;

        public FabricInspRptExp4PFormat2Repository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2)
        {
            db.FabricInspRptExp4PFormat2.Add(FabricInspRptExp4PFormat2);
            db.SaveChanges();
        }

        public void Edit(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2)
        {
            try
            {
                var existingRecord = db.FabricInspRptExp4PFormat2.Find(FabricInspRptExp4PFormat2.InspectionSerialNo);
                db.Entry(existingRecord).CurrentValues.SetValues(FabricInspRptExp4PFormat2);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspRptExp4PFormat2 FindById(string id)
        {
            FabricInspRptExp4PFormat2 c = db.FabricInspRptExp4PFormat2.Find(id);
            return c;
        }

        public IEnumerable<FabricInspRptExp4PFormat2> GetAllFabricInspRptExp4PFormat2()
        {
            return db.FabricInspRptExp4PFormat2.ToList();
        }

        public bool IsDuplicate(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2)
        {
            return false;
        }

        public IEnumerable<FabricInspRptExp4PFormat2> GetAllFabricInspRptExp4PFormat2s()
        {
            return db.FabricInspRptExp4PFormat2.ToList();
        }


        public bool Remove(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2)
        {
            var existingRecord = db.FabricInspRptExp4PFormat2.Find(FabricInspRptExp4PFormat2.InspectionSerialNo);

            if (existingRecord != null)
            {
                db.FabricInspRptExp4PFormat2.Remove(existingRecord);
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