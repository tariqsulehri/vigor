
using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class SalesTaxOfficeRepository:ISalesTaxOfficeRepository
    {
        ErpDbContext db;
        public SalesTaxOfficeRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(SalesTaxOffice salesTaxOffice)
        {
            db.SalesTaxOffice.Add(salesTaxOffice);
            db.SaveChanges();
        }

        public void Edit(SalesTaxOffice salesTaxOffice)
        {
            try
            {
                var existingRecord = db.SalesTaxOffice.Find(salesTaxOffice.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(salesTaxOffice);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }
        public bool Remove(SalesTaxOffice salesTaxOffice)
        {
            SalesTaxOffice er = db.SalesTaxOffice.Find(salesTaxOffice.Id);
            if (er != null)
            {
                db.SalesTaxOffice.Remove(er);
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
        public SalesTaxOffice FindById(int id)
        {
            SalesTaxOffice so = db.SalesTaxOffice.Find(id);
            return so;
        }
        public bool IsDuplicate(SalesTaxOffice salesTaxOffice)
        {
            if (salesTaxOffice.Id == 0)
            {
                return db.SalesTaxOffice.Any(x => x.Description == salesTaxOffice.Description);
            }

            if (salesTaxOffice.Id != 0)
            {
                SalesTaxOffice rc = db.SalesTaxOffice.FirstOrDefault(x => x.Description == salesTaxOffice.Description);
                if (rc != null && rc.Id != salesTaxOffice.Id)
                {
                    return true;
                }
            }

            return false;
        }
        public IEnumerable<SalesTaxOffice> GetAllSalesTaxOffices()
        {
            return db.SalesTaxOffice.ToList();
        }




    }
}
