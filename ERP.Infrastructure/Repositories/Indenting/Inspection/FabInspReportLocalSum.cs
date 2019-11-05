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
    public class FabInspReportLocalSum : IFabInspReportLocalSumRepository
    {
        private ErpDbContext db;
        public FabInspReportLocalSum()
        {
            db = new ErpDbContext();
        }

        public void Add(Core.Models.Indenting.Inspection.FabInspReportLocalSum fabInspReportLocalSum)
        {
            db.FabInspReportLocalSum.Add(fabInspReportLocalSum);
            db.SaveChanges();
        }

        public void Edit(Core.Models.Indenting.Inspection.FabInspReportLocalSum fabInspReportLocalSum)
        {
            try
            {
                var existingRecord = db.FabInspReportLocalSum.Find(fabInspReportLocalSum.id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabInspReportLocalSum);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

//        public FabInspReportLocalSum FindById(int id)
//        {
//                        FabInspReportLocalSum rc = db.FabInspReportLocalSum.Find(id);
//                        return rc;
//
//        }

        public IEnumerable<Core.Models.Indenting.Inspection.FabInspReportLocalSum> GetAllFabInspReportLocalSum()
        {
            return db.FabInspReportLocalSum.ToList();
        }

        public bool IsDuplicate(Core.Models.Indenting.Inspection.FabInspReportLocalSum fabInspReportLocalSum)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Core.Models.Indenting.Inspection.FabInspReportLocalSum fabInspReportLocalSum)
        {
            var existingRecord = db.FabInspReportLocalSum.Find(fabInspReportLocalSum.id);

            if (existingRecord != null)
            {
                db.FabInspReportLocalSum.Remove(existingRecord);
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
