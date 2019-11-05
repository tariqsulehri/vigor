using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.InspExport;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Infrastructure.Repositories.Indenting.InspExport
{
    public class FabricInspReportExport4PointResultsRepository : IFabricInspReportExport4PointResultsRepository
    {
        private ErpDbContext db;

        public FabricInspReportExport4PointResultsRepository()
        {
            ErpDbContext db =  new ErpDbContext();
        }

        public void Add(FabricInspReportExport4PointResults FabricInspReportExport4PointResults)
        {
            db.FabricInspReportExport4PointResults.Add(FabricInspReportExport4PointResults);
            db.SaveChanges();
        }

        public void Edit(FabricInspReportExport4PointResults FabricInspReportExport4PointResults)
        {
            try
            {
                var existingRecord = db.FabricInspReportExport4PointResults.Find(FabricInspReportExport4PointResults.InspectionSerialNoID);
                db.Entry(existingRecord).CurrentValues.SetValues(FabricInspReportExport4PointResults);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspReportExport4PointResults FindById(string id)
        {
            FabricInspReportExport4PointResults c = db.FabricInspReportExport4PointResults.Find(id);
            return c;
        }

        public IEnumerable<FabricInspReportExport4PointResults> GetAllFabricInspReportExport4PointResults()
        {
            return db.FabricInspReportExport4PointResults.ToList();
        }

        public bool IsDuplicate(FabricInspReportExport4PointResults FabricInspReportExport4PointResults)
        {
            return false;
        }

        public IEnumerable<FabricInspReportExport4PointResults> GetAllFabricInspReportExport4PointResultss()
        {
            return db.FabricInspReportExport4PointResults.ToList();
        }


        public bool Remove(FabricInspReportExport4PointResults FabricInspReportExport4PointResults)
        {
            var existingRecord = db.FabricInspReportExport4PointResults.Find(FabricInspReportExport4PointResults.InspectionSerialNoID);

            if (existingRecord != null)
            {
                db.FabricInspReportExport4PointResults.Remove(existingRecord);
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