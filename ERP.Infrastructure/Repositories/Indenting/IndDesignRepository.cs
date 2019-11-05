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
    public class IndDesignRepository : IIndDesignRepository
    {
        private ErpDbContext db;
        public IndDesignRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndDesign indDesign)
        {
            db.IndDesign.Add(indDesign);
            db.SaveChanges();
        }

        public void Edit(IndDesign indDesign)
        {
            try
            {
                var existingRecord = db.IndDesign.Find(indDesign.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indDesign);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndDesign FindById(int id)
        {
            IndDesign rc = db.IndDesign.Find(id);
            return rc;
        }

        public IEnumerable<IndDesign> GetAllIndDesigns()
        {
            return db.IndDesign.ToList();
        }

        public bool IsDuplicate(IndDesign indDesign)
        {
            if (indDesign.Id == 0)
            {
                return db.IndDesign.Any(x => x.Description == indDesign.Description);
            }

            if (indDesign.Id != 0)
            {
                IndDesign rc = db.IndDesign.FirstOrDefault(x => x.Description == indDesign.Description);
                if (rc != null && rc.Id != indDesign.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndDesign indDesign)
        {
            var existingRecord = db.IndDesign.Find(indDesign.Id);

            if (existingRecord != null)
            {
                db.IndDesign.Remove(existingRecord);
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
