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
    public class IndPaymentTermsRepository : IIndPaymentTermsRepository
    {

        public ErpDbContext _db;

        public IndPaymentTermsRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndPaymentTerms indPaymentTerms)
        {


            _db.IndPaymentTermses.Add(indPaymentTerms);
            _db.SaveChanges();
        }

        public void Edit(IndPaymentTerms indPaymentTerms)
        {
            try
            {
                var existingRecord = _db.IndPaymentTermses.Find(indPaymentTerms.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(indPaymentTerms);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(IndPaymentTerms indPaymentTerms)
        {
            IndPaymentTerms existingRecord = _db.IndPaymentTermses.Find(indPaymentTerms.Id);
            if (existingRecord != null)
            {
                _db.IndPaymentTermses.Remove(existingRecord);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }

        public IndPaymentTerms FindById(int id)
        {
            IndPaymentTerms paymentTerms = _db.IndPaymentTermses.Find(id);
            return paymentTerms;
        }

        public bool IsDuplicate(IndPaymentTerms indPaymentTerms)
        {
            if (indPaymentTerms.Id == 0)
            {
                return _db.IndPaymentTermses.Any(x => x.Description == indPaymentTerms.Description);
            }

            if (indPaymentTerms.Id != 0)
            {
                IndPaymentTerms rc = _db.IndPaymentTermses.FirstOrDefault(x => x.Description == indPaymentTerms.Description);
                if (rc != null && rc.Id != indPaymentTerms.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<IndPaymentTerms> GetAllIndPaymentTerms()
        {
            return _db.IndPaymentTermses.ToList();
        }
    }
}
