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
    public class IndDelayShipmentCategoryRepository : IIndDelayShipmentCategoryRepository
    {
        private ErpDbContext db;
        public IndDelayShipmentCategoryRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndDelayShipmentCategory indDelayShipmentCategory)
        {
            db.IndDelayShipmentCategory.Add(indDelayShipmentCategory);
            db.SaveChanges();
        }

        public void Edit(IndDelayShipmentCategory indDelayShipmentCategory)
        {
            try
            {
                var existingRecord = db.IndDelayShipmentCategory.Find(indDelayShipmentCategory.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indDelayShipmentCategory);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndDelayShipmentCategory FindById(int id)
        {
            IndDelayShipmentCategory dc = db.IndDelayShipmentCategory.Find(id);
            return dc;
        }

        public IEnumerable<IndDelayShipmentCategory> GetAllIndDelayShipmentCategorys()
        {
            return db.IndDelayShipmentCategory.ToList();
        }

        public bool IsDuplicate(IndDelayShipmentCategory indDelayShipmentCategory)
        {
            if (indDelayShipmentCategory.Id == 0)
            {
                return db.IndDelayShipmentCategory.Any(x => x.Description == indDelayShipmentCategory.Description);
            }

            if (indDelayShipmentCategory.Id != 0)
            {
                IndDelayShipmentCategory rc = db.IndDelayShipmentCategory.FirstOrDefault(x => x.Description == indDelayShipmentCategory.Description);
                if (rc != null && rc.Id != indDelayShipmentCategory.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndDelayShipmentCategory indDelayShipmentCategory)
        {
            var existingRecord = db.IndDelayShipmentCategory.Find(indDelayShipmentCategory.Id);

            if (existingRecord != null)
            {
                db.IndDelayShipmentCategory.Remove(existingRecord);
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
