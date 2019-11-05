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
    public class YarnInspectionReportTypeRepository : IYarnInspectionReportTypeRepository
    {
        private ErpDbContext db;
        public YarnInspectionReportTypeRepository()
        {
            db = new ErpDbContext();    
        }

        public void Add(YarnInspectionReportType yarnInspectionReportType)
        {
            db.YarnInspectionReportType.Add(yarnInspectionReportType);
            db.SaveChanges();
        }

        public void Edit(YarnInspectionReportType yarnInspectionReportType)
        {
            try
            {
                var existingRecord = db.YarnInspectionReportType.Find(yarnInspectionReportType.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(yarnInspectionReportType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public YarnInspectionReportType FindById(int id)
        {
            YarnInspectionReportType rc = db.YarnInspectionReportType.Find(id);
            return rc;
        }
        
        public IEnumerable<YarnInspectionReportType> GetAllYarnInspectionReportTypes()
        {
            return db.YarnInspectionReportType.ToList();
        }

        public bool IsDuplicate(YarnInspectionReportType yarnInspectionReportType)
        {
            if (yarnInspectionReportType.Id == 0)
            {
                return db.YarnInspectionReportType.Any(x => x.Description == yarnInspectionReportType.Description);
            }

            if (yarnInspectionReportType.Id != 0)
            {
                YarnInspectionReportType rc = db.YarnInspectionReportType.FirstOrDefault(x => x.Description == yarnInspectionReportType.Description);
                if (rc != null && rc.Id != yarnInspectionReportType.Id)
                {
                    return true;
                }
            }

            return false;

        }

        public bool Remove(YarnInspectionReportType yarnInspectionReportType)
        {
            var existingRecord = db.YarnInspectionReportType.Find(yarnInspectionReportType.Id);

            if (existingRecord != null)
            {
                db.YarnInspectionReportType.Remove(existingRecord);
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
