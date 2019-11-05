using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.InspExport;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Infrastructure.Repositories.Indenting.InspExport
{
    public class FabricInspReportExportRepository : IFabricInspReportExportRepository
    {
        private ErpDbContext db;
        public FabricInspReportExportRepository()
        {
            ErpDbContext db = new ErpDbContext();
        }

        public void Add(FabricInspReportExport FabricInspReportExport)
        {
            db.FabricInspReportExport.Add(FabricInspReportExport);
            db.SaveChanges();
        }

        public void Edit(FabricInspReportExport FabricInspReportExport)
        {
            try
            {
                var existingRecord = db.FabricInspReportExport.Find(FabricInspReportExport.InspectionSerialNoID);
                db.Entry(existingRecord).CurrentValues.SetValues(FabricInspReportExport);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspReportExport FindById(string id)
        {
            FabricInspReportExport c = db.FabricInspReportExport.Find(id);
            return c;
        }

        public IEnumerable<FabricInspReportExport> GetAllFabricInspReportExport()
        {
            return db.FabricInspReportExport.ToList();
        }

        public bool IsDuplicate(FabricInspReportExport FabricInspReportExport)
        {
            return false;
        }

        public IEnumerable<FabricInspReportExport> GetAllFabricInspReportExports()
        {
            return db.FabricInspReportExport.ToList();
        }


        public bool Remove(FabricInspReportExport FabricInspReportExport)
        {
            var existingRecord = db.FabricInspReportExport.Find(FabricInspReportExport.InspectionSerialNoID);

            if (existingRecord != null)
            {
                db.FabricInspReportExport.Remove(existingRecord);
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