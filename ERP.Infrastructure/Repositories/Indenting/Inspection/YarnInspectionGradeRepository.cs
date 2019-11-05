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
    public class YarnInspectionGradeRepository : IYarnInspectionGradeRepository
    {
        private ErpDbContext db;
        public YarnInspectionGradeRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(YarnInspectionGrade yarnInspectionGrade)
        {
            db.YarnInspectionGrade.Add(yarnInspectionGrade);
            db.SaveChanges();
        }

        public void Edit(YarnInspectionGrade yarnInspectionGrade)
        {
            try
            {
                var existingRecord = db.YarnInspectionGrade.Find(yarnInspectionGrade.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(yarnInspectionGrade);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }

        public YarnInspectionGrade FindById(int id)
        {
            YarnInspectionGrade rc = db.YarnInspectionGrade.Find(id);
            return rc;
        }

        public IEnumerable<YarnInspectionGrade> GetAllYarnInspectionGrades()
        {
            return db.YarnInspectionGrade.ToList();
        }

        public bool IsDuplicate(YarnInspectionGrade yarnInspectionGrade)
        {
            if (yarnInspectionGrade.Id == 0)
            {
                return db.YarnInspectionGrade.Any(x => x.Description == yarnInspectionGrade.Description);
            }

            if (yarnInspectionGrade.Id != 0)
            {
                YarnInspectionGrade rc = db.YarnInspectionGrade.FirstOrDefault(x => x.Description == yarnInspectionGrade.Description);
                if (rc != null && rc.Id != yarnInspectionGrade.Id)
                {
                    return true;
                }
            }

            return false;

        }

        public bool Remove(YarnInspectionGrade yarnInspectionGrade)
        {
            var existingRecord = db.YarnInspectionGrade.Find(yarnInspectionGrade.Id);

            if (existingRecord != null)
            {
                db.YarnInspectionGrade.Remove(existingRecord);
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
