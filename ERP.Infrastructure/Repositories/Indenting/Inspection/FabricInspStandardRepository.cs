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
    public class FabricInspStandardRepository : IFabricInspStandardRepository
    {
        private ErpDbContext db;

        public FabricInspStandardRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricInspStandard fabricInspStandard)
        {
            db.FabricInspStandard.Add(fabricInspStandard);
            db.SaveChanges();
        }

        public void Edit(FabricInspStandard fabricInspStandard)
        {
            try
            {
                var existingRecord = db.FabricInspStandard.Find(fabricInspStandard.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(fabricInspStandard);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public FabricInspStandard FindById(int id)
        {
            FabricInspStandard c = db.FabricInspStandard.Find(id);
            return c;
        }

        public IEnumerable<FabricInspStandard> GetAllfabricInspStandard()
        {
            return db.FabricInspStandard.ToList();
        }

        public bool IsDuplicate(FabricInspStandard fabricInspStandard)
        {
            if (fabricInspStandard.Id == 0)
            {
                return db.FabricInspStandard.Any(x => x.Description == fabricInspStandard.Description);
            }

            if (fabricInspStandard.Id != 0)
            {
                FabricInspStandard rc = db.FabricInspStandard.FirstOrDefault(x => x.Description == fabricInspStandard.Description);
                if (rc != null && rc.Id != fabricInspStandard.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(FabricInspStandard FabricInspStandard)
        {
            var existingRecord = db.FabricInspStandard.Find(FabricInspStandard.Id);

            if (existingRecord != null)
            {
                db.FabricInspStandard.Remove(existingRecord);
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
