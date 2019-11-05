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
    public class UnitOfSaleRepository : IUnitOfSaleRepository
    {
        private ErpDbContext db;
        public UnitOfSaleRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(UnitOfSale unitOfSale)
        {
            db.UnitOfSale.Add(unitOfSale);
            db.SaveChanges();
        }

        public void Edit(UnitOfSale unitOfSale)
        {
            try
            {
                var existingRecord = db.UnitOfSale.Find(unitOfSale.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(unitOfSale);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public UnitOfSale FindById(int id)
        {
            UnitOfSale rc = db.UnitOfSale.Find(id);
            return rc;
        }

        public IEnumerable<UnitOfSale> GetAllUnitOfSales()
        {
            return db.UnitOfSale.ToList();
        }

        public bool IsDuplicate(UnitOfSale unitOfSale)
        {
            if (unitOfSale.Id == 0)
            {
                return db.UnitOfSale.Any(x => x.Description == unitOfSale.Description);
            }

            if (unitOfSale.Id != 0)
            {
                UnitOfSale rc = db.UnitOfSale.FirstOrDefault(x => x.Description == unitOfSale.Description);
                if (rc != null && rc.Id != unitOfSale.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(UnitOfSale unitOfSale)
        {
            var existingRecord = db.UnitOfSale.Find(unitOfSale.Id);

            if (existingRecord != null)
            {
                db.UnitOfSale.Remove(existingRecord);
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
