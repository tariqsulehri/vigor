using ERP.Core.IRepositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class IndLeadTimeRepository : IIndLeadTimeRepository
    {
        private ErpDbContext db;
        public IndLeadTimeRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndLeadTime indLeadTime)
        {
            db.IndLeadTime.Add(indLeadTime);
            db.SaveChanges();
        }

        public void Edit(IndLeadTime indLeadTime)
        {
            try
            {
                var existingRecord = db.IndLeadTime.Find(indLeadTime.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indLeadTime);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndLeadTime FindById(int id)
        {
            IndLeadTime c = db.IndLeadTime.Find(id);
            return c;
        }

        public IEnumerable<IndLeadTime> GetAllIndLeadTime()
        {
            return db.IndLeadTime.ToList();
        }

        public bool IsDuplicate(IndLeadTime indLeadTime)
        {
            if (indLeadTime.Id == 0)
            {
                return db.IndLeadTime.Any(x => x.Id == indLeadTime.Id);
            }

            if (indLeadTime.Id != 0)
            {
                IndLeadTime rc = db.IndLeadTime.FirstOrDefault(x => x.Id == indLeadTime.Id);
                if (rc != null && rc.Id != indLeadTime.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndLeadTime indLeadTime)
        {
            var existingRecord = db.IndLeadTime.Find(indLeadTime.Id);

            if (existingRecord != null)
            {
                db.IndLeadTime.Remove(existingRecord);
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
