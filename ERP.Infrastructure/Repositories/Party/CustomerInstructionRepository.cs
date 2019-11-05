using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Parties;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerInstructionRepository : ICustomerInstructionRepository
    {
        private readonly ErpDbContext _db;

        public CustomerInstructionRepository()
        {
            _db =  new  ErpDbContext();
        }
        public void Add(CustomerInstruction customerInstruction)
        {
            _db.CustomerInstructions.Add(customerInstruction);
            _db.SaveChanges();
        }

        public void Edit(CustomerInstruction customerInstruction)
        {
            _db.Entry(customerInstruction).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existtingRecord = _db.CustomerInstructions.Find(id);
            if (_db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public CustomerInstruction FindById(int id)
        {
            var existingRecord = _db.CustomerInstructions.Find(id);
            return existingRecord;
        }

        public IEnumerable<CustomerInstruction> GetAllCustomerInstruction()
        {
            return _db.CustomerInstructions.ToList();
        }

    }
}
