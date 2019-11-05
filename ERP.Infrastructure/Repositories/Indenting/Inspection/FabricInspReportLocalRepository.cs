using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class FabricInspReportLocalRepository : IFabricInspReportLocalRepository
    {
        private ErpDbContext db;
        public FabricInspReportLocalRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricInspReportLocal fabricInspReportLocal)
        {
            db.FabricInspReportLocal.Add(fabricInspReportLocal);
            db.SaveChanges();
        }

        public void Edit(Core.Models.Indenting.Inspection.FabricInspReportLocal fabricInspReportLocal)
        {
            try
            {
                var existingRecord = db.FabricInspReportLocal.Find(fabricInspReportLocal.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabricInspReportLocal);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public Core.Models.Indenting.Inspection.FabricInspReportLocal FindById(int id)
        {
            FabricInspReportLocal fl = db.FabricInspReportLocal.Find(id);
            return fl;
        }

        public IEnumerable<Core.Models.Indenting.Inspection.FabricInspReportLocal> GetAllFabricInspReportLocal()
        {
            return db.FabricInspReportLocal.ToList();
        }

        public bool IsDuplicate(Core.Models.Indenting.Inspection.FabricInspReportLocal FabricInspReportLocal)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Core.Models.Indenting.Inspection.FabricInspReportLocal FabricInspReportLocal)
        {
            var existingRecord = db.FabricInspReportLocal.Find(FabricInspReportLocal.Id);

            if (existingRecord != null)
            {
                db.FabricInspReportLocal.Remove(existingRecord);
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
