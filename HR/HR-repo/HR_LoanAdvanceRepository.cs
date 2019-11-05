using System.Linq;

namespace ERP.Infrastructure.Repositories.HR
{
    using ERP.Core.IRepositories.HrIRepository;
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class HR_LoanAdvanceRepository : IHR_LoanAdvanceRepository
    {

        private readonly ErpDbContext _db;
        public HR_LoanAdvanceRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_LoanAdvance HR_LoanAdvance)
        {
            _db.HR_LoanAdvance.Add(HR_LoanAdvance);
            _db.SaveChanges();
        }

        public void Edit(HR_LoanAdvance HR_LoanAdvance)
        {
            _db.Entry(HR_LoanAdvance).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_LoanAdvance FindById(string id)
        {
            var department = _db.HR_LoanAdvance.Find(id);
            return department;
        }

        public IEnumerable<HR_LoanAdvance> GetAllHR_LoanAdvance()
        {
            return _db.HR_LoanAdvance.ToList();
        }

        public bool IsDuplicate(HR_LoanAdvance HR_LoanAdvance)
        {
            if (HR_LoanAdvance.LoanAdvLedID == "")
            {
                return _db.HR_LoanAdvance.Any(x => x.Amount == HR_LoanAdvance.Amount);
            }

            if (HR_LoanAdvance.LoanAdvLedID != "")
            {
                HR_LoanAdvance reg = _db.HR_LoanAdvance.FirstOrDefault(x => x.Amount == HR_LoanAdvance.Amount);
                if (reg != null && reg.LoanAdvLedID != HR_LoanAdvance.LoanAdvLedID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_LoanAdvance.Find(id);

            if (existingRecord != null)
            {
                _db.HR_LoanAdvance.Remove(existingRecord);
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
    }
}
