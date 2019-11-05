using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class FabricInspTypeRepository : IFabricInspTypeRepository
    {
        private ErpDbContext db;
        public FabricInspTypeRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricInspType fabricInspType)
        {
            db.FabricInspType.Add(fabricInspType);
            db.SaveChanges();
        }

        public void Edit(FabricInspType fabricInspType)
        {
            try
            {
                var existingRecord = db.FabricInspType.Find(fabricInspType.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabricInspType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspType FindById(int id)
        {
            FabricInspType c = db.FabricInspType.Find(id);
            return c;
        }

        public IEnumerable<FabricInspType> GetAllFabricInspTypes()
        {
            return db.FabricInspType.ToList();
        }

        public bool IsDuplicate(FabricInspType fabricInspType)
        {
            if (fabricInspType.Id == 0)
            {
                return db.FabricInspType.Any(x => x.Description == fabricInspType.Description);
            }

            if (fabricInspType.Id != 0)
            {
                FabricInspType rc = db.FabricInspType.FirstOrDefault(x => x.Description == fabricInspType.Description);
                if (rc != null && rc.Id != fabricInspType.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(FabricInspType fabricInspType)
        {
            var existingRecord = db.FabricInspType.Find(fabricInspType.Id);

            if (existingRecord != null)
            {
                db.FabricInspType.Remove(existingRecord);
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
