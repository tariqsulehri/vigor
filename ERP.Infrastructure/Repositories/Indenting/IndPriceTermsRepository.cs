using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class IndPriceTermsRepository : IIndPriceTermsRepository
    {

        public ErpDbContext _db;

        public IndPriceTermsRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndPriceTerms indPriceTerms)
        {
            _db.IndPriceTerms.Add(indPriceTerms);
            _db.SaveChanges();
        }

        public void Edit(IndPriceTerms indPriceTerms)
        {
            try
            {
                var existingRecord = _db.IndPriceTerms.Find(indPriceTerms.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(indPriceTerms);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(IndPriceTerms indPriceTerms)
        {
            IndPriceTerms pt = _db.IndPriceTerms.Find(indPriceTerms.Id);
            if (pt != null)
            {
                _db.IndPriceTerms.Remove(pt);
                _db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public IndPriceTerms FindById(int id)
        {
            IndPriceTerms pt = _db.IndPriceTerms.Find(id);
            return pt;
        }

        public bool IsDuplicate(IndPriceTerms indPriceTerms)
        {
            if (indPriceTerms.Id == 0)
            {
                return _db.IndPaymentTermses.Any(x => x.Description == indPriceTerms.Description);
            }

            if (indPriceTerms.Id != 0)
            {
                IndPriceTerms rc = _db.IndPriceTerms.FirstOrDefault(x => x.Description == indPriceTerms.Description); 
                if (rc != null && rc.Id != indPriceTerms.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<IndPriceTerms> GetAllIndPriceTerms()
        {
            return _db.IndPriceTerms.ToList();
        }
    }
}

