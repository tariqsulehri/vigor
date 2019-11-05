using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Party;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerContactRepository : ICustomerContactRepository
    {
        private readonly ErpDbContext _db;
        public CustomerContactRepository()
        {
            _db =  new ErpDbContext();
        }
        public void Add(CustomerContact customerContact)
        {
            _db.CustomerContacts.Add(customerContact);
            _db.SaveChanges();
        }

        public void Edit(CustomerContact customerContact)
        {
            _db.Entry(customerContact).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existtingRecord = _db.CustomerContacts.Find(id);
            if (_db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public CustomerContact FindById(int id)
        {
            var existingRecord = _db.CustomerContacts.Find(id);
            return existingRecord;
        }

        public IEnumerable<CustomerContact> GetAllCustomerContact()
        {
            return _db.CustomerContacts.ToList();
        }
    }
}
