using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HR_EmployeeAllowancesRepository : IHR_EmployeeAllowancesRepository
    {
        private readonly ErpDbContext _db;
        public HR_EmployeeAllowancesRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_EmployeeAllowances HR_EmployeeAllowances)
        {
            _db.HR_EmployeeAllowances.Add(HR_EmployeeAllowances);
            _db.SaveChanges();
        }

        public void Edit(HR_EmployeeAllowances HR_EmployeeAllowances)
        {
            try
            {
                var existingRecord = _db.HR_EmployeeAllowances.Find(HR_EmployeeAllowances.id);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_EmployeeAllowances);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_EmployeeAllowances FindById(string id)
        {
            var department = _db.HR_EmployeeAllowances.Find(id);
            return department;
        }

        public IEnumerable<HR_EmployeeAllowances> GetAllHR_EmployeeAllowances()
        {
            return _db.HR_EmployeeAllowances.ToList();
        }

        public bool IsDuplicate(HR_EmployeeAllowances HR_EmployeeAllowances)
        {
            if (HR_EmployeeAllowances.AllowanceID == "")
            {
                return _db.HR_EmployeeAllowances.Any(x => x.Mode == HR_EmployeeAllowances.Mode);
            }

            if (HR_EmployeeAllowances.AllowanceID != "")
            {
                HR_EmployeeAllowances reg = _db.HR_EmployeeAllowances.FirstOrDefault(x => x.Mode == HR_EmployeeAllowances.Mode);
                if (reg != null && reg.AllowanceID != HR_EmployeeAllowances.AllowanceID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_EmployeeAllowances.Find(id);

            if (existingRecord != null)
            {
                _db.HR_EmployeeAllowances.Remove(existingRecord);
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
