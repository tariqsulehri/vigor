using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.InspExport;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Infrastructure.Repositories.Indenting.InspExport
{
    public class FabricInspReportExport4PointDetailsRepository : IFabricInspReportExport4PointDetailsRepository
    {

        public ErpDbContext db;
        public FabricInspReportExport4PointDetailsRepository()
        {
            ErpDbContext db = new ErpDbContext();
        }

        public void Add(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails)
        {
            db.FabricInspReportExport4PointDetails.Add(FabricInspReportExport4PointDetails);
            db.SaveChanges();
        }

        public void Edit(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails)
        {
            try
            {
                var existingRecord = db.FabricInspReportExport4PointDetails.Find(FabricInspReportExport4PointDetails.InspectionSerialNo);
                db.Entry(existingRecord).CurrentValues.SetValues(FabricInspReportExport4PointDetails);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspReportExport4PointDetails FindById(string id)
        {
            FabricInspReportExport4PointDetails c = db.FabricInspReportExport4PointDetails.Find(id);
            return c;
        }

        public IEnumerable<FabricInspReportExport4PointDetails> GetAllFabricInspReportExport4PointDetails()
        {
            return db.FabricInspReportExport4PointDetails.ToList();
        }

        public bool IsDuplicate(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails)
        {
            return false;
        }

        public IEnumerable<FabricInspReportExport4PointDetails> GetAllFabricInspReportExport4PointDetailss()
        {
            return db.FabricInspReportExport4PointDetails.ToList();
        }


        public bool Remove(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails)
        {
            var existingRecord = db.FabricInspReportExport4PointDetails.Find(FabricInspReportExport4PointDetails.InspectionSerialNo);

            if (existingRecord != null)
            {
                db.FabricInspReportExport4PointDetails.Remove(existingRecord);
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