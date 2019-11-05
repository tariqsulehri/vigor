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
    public class CurrencyRepository : ICurrencyRepository
    {

        private ErpDbContext db;
        public CurrencyRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(Currency currency)
        {
            db.Currency.Add(currency);
            db.SaveChanges();
        }

        public void Edit(Currency currency)
        {
            try
            {
                var existingRecord = db.Currency.Find(currency.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(currency);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public Currency FindById(int id)
        {
            Currency c = db.Currency.Find(id);
            return c;
        }

        public IEnumerable<Currency> GetAllCurrencys()
        {
            return db.Currency.ToList();
        }

        public bool IsDuplicate(Currency currency)
        {
            if (currency.Id == 0)
            {
                return db.Currency.Any(x => x.Description == currency.Description);
            }

            if (currency.Id != 0)
            {
                Currency rc = db.Currency.FirstOrDefault(x => x.Description == currency.Description);
                if (rc != null && rc.Id != currency.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(Currency currency)
        {
            var existingRecord = db.Currency.Find(currency.Id);

            if (existingRecord != null)
            {
                db.Currency.Remove(existingRecord);
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
