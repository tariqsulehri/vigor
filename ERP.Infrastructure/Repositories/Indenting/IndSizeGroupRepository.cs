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
    public class IndSizeGroupRepository : IIndSizeGroupRepository
    {
        private ErpDbContext db;
        public IndSizeGroupRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndSizeGroup indSizeGroup)
        {
            db.IndSizeGroup.Add(indSizeGroup);
            db.SaveChanges();
        }

        public void Edit(IndSizeGroup indSizeGroup)
        {
            try
            {
                var existingRecord = db.IndSizeGroup.Find(indSizeGroup.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indSizeGroup);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndSizeGroup FindById(int id)
        {
            IndSizeGroup rc = db.IndSizeGroup.Find(id);
            return rc;
        }

        public IEnumerable<IndSizeGroup> GetAllIndSizeGroups()
        {
            return db.IndSizeGroup.ToList();
        }

        public bool IsDuplicate(IndSizeGroup indSizeGroup)
        {
            if (indSizeGroup.Id == 0)
            {
                return db.IndSizeGroup.Any(x => x.Description == indSizeGroup.Description);
            }

            if (indSizeGroup.Id != 0)
            {
                IndSizeGroup rc = db.IndSizeGroup.FirstOrDefault(x => x.Description == indSizeGroup.Description);
                if (rc != null && rc.Id != indSizeGroup.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndSizeGroup indSizeGroup)
        {
            var existingRecord = db.IndSizeGroup.Find(indSizeGroup.Id);

            if (existingRecord != null)
            {
                db.IndSizeGroup.Remove(existingRecord);
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
