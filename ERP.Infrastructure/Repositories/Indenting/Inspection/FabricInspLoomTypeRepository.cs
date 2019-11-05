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
    public class FabricInspLoomTypeRepository : IFabricInspLoomTypeRepository
    {
        private ErpDbContext db;

        public FabricInspLoomTypeRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricInspLoomType fabricInspLoomType)
        {
            db.FabricInspLoomType.Add(fabricInspLoomType);
            db.SaveChanges();
        }

        public void Edit(FabricInspLoomType fabricInspLoomType)
        {
            try
            {
                var existingRecord = db.FabricInspLoomType.Find(fabricInspLoomType.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabricInspLoomType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspLoomType FindById(int id)
        {
            FabricInspLoomType c = db.FabricInspLoomType.Find(id);
            return c;
        }

        public IEnumerable<FabricInspLoomType> GetAllFabricInspLoomType()
        {
            return db.FabricInspLoomType.ToList();
        }

        public bool IsDuplicate(FabricInspLoomType fabricInspLoomType)
        {
            if (fabricInspLoomType.Id == 0)
            {
                return db.FabricInspLoomType.Any(x => x.Description == fabricInspLoomType.Description);
            }

            if (fabricInspLoomType.Id != 0)
            {
                FabricInspLoomType rc = db.FabricInspLoomType.FirstOrDefault(x => x.Description == fabricInspLoomType.Description);
                if (rc != null && rc.Id != fabricInspLoomType.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsDuplicate(FabricType fabricInspLoomType)
        {
            if (fabricInspLoomType.Id == 0)
            {
                return db.FabricInspLoomType.Any(x => x.Description == fabricInspLoomType.Description);
            }

            if (fabricInspLoomType.Id != 0)
            {
                FabricInspLoomType rc = db.FabricInspLoomType.FirstOrDefault(x => x.Description == fabricInspLoomType.Description);
                if (rc != null && rc.Id != fabricInspLoomType.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(FabricInspLoomType fabricInspLoomType)
        {
            var existingRecord = db.FabricInspLoomType.Find(fabricInspLoomType.Id);

            if (existingRecord != null)
            {
                db.FabricInspLoomType.Remove(existingRecord);
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
