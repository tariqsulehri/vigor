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
    public class ExchangeRatesRepository : IExchangeRatesRepository
    {
        private ErpDbContext db;
        public ExchangeRatesRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(ExchangeRates exchangeRates)
        {
            db.ExchangeRates.Add(exchangeRates);
            db.SaveChanges();
        }

        public void Edit(ExchangeRates exchangeRates)
        {
            try
            {
                var existingRecord = db.ExchangeRates.Find(exchangeRates.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(exchangeRates);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public ExchangeRates FindById(int id)
        {
            ExchangeRates c = db.ExchangeRates.Find(id);
            return c;
        }

        public IEnumerable<ExchangeRates> GetAllExchangeRates()
        {
            return db.ExchangeRates.ToList();
        }

        public bool IsDuplicate(ExchangeRates exchangeRates)
        {
            if (exchangeRates.Id == 0)
            {
                return db.ExchangeRates.Any(x => x.CurrencyId == exchangeRates.CurrencyId);
            }

            if (exchangeRates.Id != 0)
            {
                ExchangeRates rc = db.ExchangeRates.FirstOrDefault(x => x.CurrencyId == exchangeRates.CurrencyId);
                if (rc != null && rc.Id != exchangeRates.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(ExchangeRates ExchangeRates)
        {
            var existingRecord = db.ExchangeRates.Find(ExchangeRates.Id);

            if (existingRecord != null)
            {
                db.ExchangeRates.Remove(existingRecord);
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
