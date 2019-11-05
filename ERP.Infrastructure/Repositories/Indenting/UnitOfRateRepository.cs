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
    public class UnitOfRateRepository : IUnitOfRateRepository
    {
        private ErpDbContext db;
        public UnitOfRateRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(UnitOfRate unitOfRate)
        {
            db.UnitOfRate.Add(unitOfRate);
            db.SaveChanges();
        }

        public void Edit(UnitOfRate unitOfRate)
        {

            try
            {
                var existingRecord = db.UnitOfRate.Find(unitOfRate.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(unitOfRate);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public UnitOfRate FindById(int id)
        {
            UnitOfRate rc = db.UnitOfRate.Find(id);
            return rc;
        }

        public IEnumerable<UnitOfRate> GetAllUnitOfRates()
        {
            return db.UnitOfRate.ToList();
        }

        public bool IsDuplicate(UnitOfRate unitOfRate)
        {
            if (unitOfRate.Id == 0)
            {
                return db.UnitOfRate.Any(x => x.Description == unitOfRate.Description);
            }

            if (unitOfRate.Id != 0)
            {
                UnitOfRate rc = db.UnitOfRate.FirstOrDefault(x => x.Description == unitOfRate.Description);
                if (rc != null && rc.Id != unitOfRate.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(UnitOfRate unitOfRate)
        {
            var existingRecord = db.UnitOfRate.Find(unitOfRate.Id);

            if (existingRecord != null)
            {
                db.UnitOfRate.Remove(existingRecord);
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
