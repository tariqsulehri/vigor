using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.CommonIRepositories.CommonParty;
using ERP.Core.Models.Common.Party;

namespace ERP.Infrastructure.Repositories.Common.PatryCommon
{
    public class MachineRepository : IMachineRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(Machine machine)
        {
            _db.Machines.Add(machine);
            _db.SaveChanges();
        }
        public void Edit(Machine modifiedMachine)
        {
			var existingMachine = _db.Machines.Find(modifiedMachine.Id);
            if(existingMachine!=null)
            {
                existingMachine.Details = modifiedMachine.Details;
                existingMachine.IsActive = modifiedMachine.IsActive;
                existingMachine.Name = modifiedMachine.Name;
                _db.Entry(existingMachine).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public bool Remove(int mcode)
        {
            var existingMachine = _db.Machines.Find(mcode);

            if (existingMachine != null)
            {
                _db.Machines.Remove(existingMachine);
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
        public Machine FindById(int mcode)
        {
            var machine = _db.Machines.Find(mcode);
            return machine;
        }

        public bool IsDuplicate(Machine machine)
        {
            if (machine.Id == 0)
            {
                return _db.Machines.Any(x => x.Name == machine.Name);
            }

            if (machine.Id != 0)
            {
                Machine reg = _db.Machines.FirstOrDefault(x => x.Name == machine.Name);
                if (reg != null && reg.Id != machine.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Machine> GetAllMachines()
        {
            IEnumerable<Machine> machines = _db.Machines.ToList();
            return machines;
        }
    }
}

