using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.CommonIRepositories.CommonParty;
using ERP.Core.Models.Common.Party;

namespace ERP.Infrastructure.Repositories.Common.PatryCommon
{
    public class SpecialInstructionRepository :  ISpecialInstructionRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(SpecialInstruction specialInstruction)
        {
            _db.SpecialInstruction.Add(specialInstruction);
            _db.SaveChanges();
        }
        public void Edit(SpecialInstruction modifiedSpecialInstruction)
        {
			  var existingSpecialInstruction = _db.SpecialInstruction.Find(modifiedSpecialInstruction.Id);
            if(existingSpecialInstruction!=null)
            {
                existingSpecialInstruction.IsActive = modifiedSpecialInstruction.IsActive;
                existingSpecialInstruction.Name = modifiedSpecialInstruction.Name;
                _db.Entry(existingSpecialInstruction).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public bool Remove(int mcode)
        {
            var existingSpecialInstruction = _db.SpecialInstruction.Find(mcode);

            if (existingSpecialInstruction != null)
            {
                _db.SpecialInstruction.Remove(existingSpecialInstruction);
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
        public SpecialInstruction FindById(int mcode)
        {
            var specialInstruction = _db.SpecialInstruction.Find(mcode);
            return specialInstruction;
        }
        public bool IsDuplicate(SpecialInstruction specialInstruction)
        {

            if (specialInstruction.Id == 0)
            {
                return _db.SpecialInstruction.Any(x => x.Name == specialInstruction.Name);
            }

            if (specialInstruction.Id != 0)
            {
                SpecialInstruction reg = _db.SpecialInstruction.FirstOrDefault(x => x.Name == specialInstruction.Name);
                if (reg != null && reg.Id != specialInstruction.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<SpecialInstruction> GetAllSpecialInstructions()
        {
            IEnumerable<SpecialInstruction> specialInstructions = _db.SpecialInstruction.ToList();
            return specialInstructions;
        }
    }
}

