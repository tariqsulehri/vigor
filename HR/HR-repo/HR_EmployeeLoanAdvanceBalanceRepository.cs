using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HR_EmployeeLoanAdvanceBalanceRepository : IHR_EmployeeLoanAdvanceBalanceRepository
    {
        private readonly ErpDbContext _db;
        public HR_EmployeeLoanAdvanceBalanceRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_EmployeeLoanAdvanceBalance HR_EmployeeLoanAdvanceBalance)
        {
            _db.HR_EmployeeLoanAdvanceBalance.Add(HR_EmployeeLoanAdvanceBalance);
            _db.SaveChanges();
        }

        public void Edit(HR_EmployeeLoanAdvanceBalance HR_EmployeeLoanAdvanceBalance)
        {
            _db.Entry(HR_EmployeeLoanAdvanceBalance).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_EmployeeLoanAdvanceBalance FindById(string id)
        {
            var department = _db.HR_EmployeeLoanAdvanceBalance.Find(id);
            return department;
        }

        public IEnumerable<HR_EmployeeLoanAdvanceBalance> GetAllHR_EmployeeLoanAdvanceBalance()
        {
            return _db.HR_EmployeeLoanAdvanceBalance.ToList();
        }

        public bool IsDuplicate(HR_EmployeeLoanAdvanceBalance HR_EmployeeLoanAdvanceBalance)
        {
            if (HR_EmployeeLoanAdvanceBalance.LoanAdvanceID == 0)
            {
                return _db.HR_EmployeeLoanAdvanceBalance.Any(x => x.AdvanceAmountBalance == HR_EmployeeLoanAdvanceBalance.AdvanceAmountBalance);
            }

            if (HR_EmployeeLoanAdvanceBalance.LoanAdvanceID != 0)
            {
                HR_EmployeeLoanAdvanceBalance reg = _db.HR_EmployeeLoanAdvanceBalance.FirstOrDefault(x => x.AdvanceAmountBalance == HR_EmployeeLoanAdvanceBalance.AdvanceAmountBalance);
                if (reg != null && reg.LoanAdvanceID != HR_EmployeeLoanAdvanceBalance.LoanAdvanceID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_EmployeeLoanAdvanceBalance.Find(id);

            if (existingRecord != null)
            {
                _db.HR_EmployeeLoanAdvanceBalance.Remove(existingRecord);
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
