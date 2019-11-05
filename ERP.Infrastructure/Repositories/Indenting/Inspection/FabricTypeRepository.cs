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
    public class FabricTypeRepository : IFabricTypeRepository
    {
        private ErpDbContext db;
        public FabricTypeRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricType fabricType)
        {
            db.FabricType.Add(fabricType);
            db.SaveChanges();
        }

        public void Edit(FabricType fabricType)
        {
            try
            {
                var existingRecord = db.FabricType.Find(fabricType.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabricType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricType FindById(int id)
        {
            FabricType ft = db.FabricType.Find(id);
            return ft;
        }

        public IEnumerable<FabricType> GetAllFabricTypes()
        {
            return db.FabricType.ToList();
        }

        public bool IsDuplicate(FabricType fabricType)
        {
            if (fabricType.Id == 0)
            {
                return db.FabricType.Any(x => x.Description == fabricType.Description);
            }

            if (fabricType.Id != 0)
            {
                FabricType rc = db.FabricType.FirstOrDefault(x => x.Description == fabricType.Description);
                if (rc != null && rc.Id != fabricType.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(FabricType fabricType)
        {
            var existingRecord = db.FabricType.Find(fabricType.Id);

            if (existingRecord != null)
            {
                db.FabricType.Remove(existingRecord);
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
