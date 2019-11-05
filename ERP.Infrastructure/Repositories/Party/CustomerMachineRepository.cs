using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Party;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerMachineRepository : ICustomerMachineRepository
    {
        private readonly ErpDbContext _db;

        public CustomerMachineRepository()
        {
             _db =  new ErpDbContext();
        }
        public void Add(CustomerMachine customerMachine)
        {
            _db.CustomerMachines.Add(customerMachine);
            _db.SaveChanges();
        }

        public void Edit(CustomerMachine customerMachine)
        {
            _db.Entry(customerMachine).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existtingRecord = _db.CustomerMachines.Find(id);
            if (_db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public CustomerMachine FindById(int id)
        {
            var existingRecord = _db.CustomerMachines.Find(id);
            return existingRecord;
        }

        public IEnumerable<CustomerMachine> GetAllCustomerMachines()
        {
            return _db.CustomerMachines.ToList();
        }
    }
}
