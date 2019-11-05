using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class FabricSampleRepository : IFabricSampleRepository
    {
        private ErpDbContext db;
        public FabricSampleRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(FabricSample fabricSample)
        {
            db.FabricSample.Add(fabricSample);
            db.SaveChanges();
        }

        public void Edit(FabricSample fabricSample)
        {
            var result = db.FabricSample.SingleOrDefault(b => b.Id == fabricSample.Id);
            if (result != null)
            {
                try
                {
                   // db.FabricSample.Attach(fabricSample);
                    db.Entry(fabricSample).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public FabricSample FindById(int id)
        {
            FabricSample rc = db.FabricSample.Find(id);
            return rc;
        }

        public IEnumerable<FabricSample> GetAllFabricSamples()
        {
            return db.FabricSample.ToList();
        }

        public bool Remove(FabricSample fabricSample)
        {
            var existingRecord = db.FabricSample.Find(fabricSample.Id);

            if (existingRecord != null)
            {
                db.FabricSample.Remove(existingRecord);
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
