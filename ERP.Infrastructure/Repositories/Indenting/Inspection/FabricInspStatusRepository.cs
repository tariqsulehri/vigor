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
    public class FabricInspStatusRepository : IFabricInspStatusRepository
    {
        public ErpDbContext db;
        public FabricInspStatusRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricInspStatus fabricInspStatus)
        {
            db.FabricInspStatus.Add(fabricInspStatus);
            db.SaveChanges();
        }

        public void Edit(FabricInspStatus fabricInspStatus)
        {
            try
            {
                var existingRecord = db.FabricInspStatus.Find(fabricInspStatus.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabricInspStatus);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspStatus FindById(int id)
        {
            FabricInspStatus c = db.FabricInspStatus.Find(id);
            return c;
        }

        public IEnumerable<FabricInspStatus> GetAllFabricInspStatus()
        {
            return db.FabricInspStatus.ToList();
        }

        public bool IsDuplicate(FabricInspStatus fabricInspStatus)
        {
            if (fabricInspStatus.Id == 0)
            {
                return db.FabricInspStatus.Any(x => x.Description == fabricInspStatus.Description);
            }

            if (fabricInspStatus.Id != 0)
            {
                FabricInspStatus rc = db.FabricInspStatus.FirstOrDefault(x => x.Description == fabricInspStatus.Description);
                if (rc != null && rc.Id != fabricInspStatus.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(FabricInspStatus fabricInspStatus)
        {
            var existingRecord = db.FabricInspStatus.Find(fabricInspStatus.Id);

            if (existingRecord != null)
            {
                db.FabricInspStatus.Remove(existingRecord);
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
