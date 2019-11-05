using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Party;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerBrandRepository : ICustomerBrandRepository
    {

        private readonly ErpDbContext _db;

        public CustomerBrandRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(CustomerBrand customerBrand)
        {
            _db.CustomerBrands.Add(customerBrand);
            _db.SaveChanges();
        }

        public void Edit(CustomerBrand customerBrand)
        {
            _db.Entry(customerBrand).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.CustomerBrands.Find(id);

            if (existingRecord != null)
            {
                _db.CustomerBrands.Remove(existingRecord);
            }
            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            }
            ;
        }

        public CustomerBrand FindById(int id)
        {
            var existingRecord = _db.CustomerBrands.Find(id);
            return existingRecord;
        }
        public IEnumerable<CustomerBrand> GetAllCustomerBrand()
        {
            return _db.CustomerBrands.ToList();
        }
    }
}