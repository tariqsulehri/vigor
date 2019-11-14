using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class YarnInspectionRepository : IYarnInspectionRepository
    {
        private ErpDbContext db;
        public YarnInspectionRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(YarnInspection yarnInspection)
        {
            db.YarnInspection.Add(yarnInspection);
            db.SaveChanges();
        }

        public void Edit(YarnInspection yarnInspection)
        {
            try
            {
                var existingRecord = db.YarnInspection.Find(yarnInspection.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(yarnInspection);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }


        }

        public YarnInspection FindById(int id)
        {
            YarnInspection rc = db.YarnInspection.Find(id);
            return rc;
        }

        public IEnumerable<YarnInspection> GetAllYarnInspections()
        {
            return db.YarnInspection.ToList();
        }

        public bool Remove(YarnInspection yarnInspection)
        {
            throw new NotImplementedException();
        }
    }
}
