using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Party;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerSocialRepository : ICustomerSocialRepository
    {
        private readonly ErpDbContext _db;

        public CustomerSocialRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(CustomerSocial customerSocials)
        {
            _db.CustomerSocials.Add(customerSocials);
            _db.SaveChanges();
        }

        public void Edit(CustomerSocial customerSocials)
        {
            _db.Entry(customerSocials).State =  EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.CustomerSocials.Find(id);
            if (existingRecord != null)
            {
                _db.CustomerSocials.Remove(existingRecord);
            }
            if (_db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public CustomerSocial FindById(int id)
        {
            var existingRecord = _db.CustomerSocials.Find(id);
            return existingRecord;
        }

        public IEnumerable<CustomerSocial> GetAllCustomerSocial()
        {
            return _db.CustomerSocials.ToList();
        }
    }
}
