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
    public class IndSizeRepository : IIndSizeRepository
    {
        private ErpDbContext db;
        public IndSizeRepository()
        {
            db = new ErpDbContext();

        }
        public void Add(IndSize indSize)
        {
            db.IndSize.Add(indSize);
            db.SaveChanges();
        }

        public void Edit(IndSize indSize)
        {
            try
            {
                var existingRecord = db.IndSize.Find(indSize.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indSize);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndSize FindById(int id)
        {
            IndSize rc = db.IndSize.Find(id);
            return rc;

        }

        public IEnumerable<IndSize> GetAllIndSizes()
        {
            return db.IndSize.ToList();
        }

        public bool IsDuplicate(IndSize indSize)
        {
            if (indSize.Id == 0)
            {
                return db.IndSize.Any(x => x.Description == indSize.Description);
            }

            if (indSize.Id != 0)
            {
                IndSize rc = db.IndSize.FirstOrDefault(x => x.Description == indSize.Description);
                if (rc != null && rc.Id != indSize.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndSize indSize)
        {
            var existingRecord = db.IndSize.Find(indSize.Id);

            if (existingRecord != null)
            {
                db.IndSize.Remove(existingRecord);
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
