using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Parties;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerContactPersonRepository : ICustomerContactPersonRepository
    {

        private readonly ErpDbContext _db;
        public CustomerContactPersonRepository()
        {
            _db  =  new ErpDbContext();
        }
        public void Add(CustomerContactPerson customerContactPersons)
        {
            _db.CustomerContactPersons.Add(customerContactPersons);
            _db.SaveChanges();
        }

        public void Edit(CustomerContactPerson customerContactPersons)
        {
            _db.Entry(customerContactPersons).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existtingRecord = _db.CustomerContactPersons.Find(id);
            if (_db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public CustomerContactPerson FindById(int id)
        {
            var existingRecord = _db.CustomerContactPersons.Find(id);
            return existingRecord;
        }

        public IEnumerable<CustomerContactPerson> GetAllContactPersons()
        {
            return _db.CustomerContactPersons.ToList();
        }
    }
}
