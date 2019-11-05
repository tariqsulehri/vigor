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

    public class HR_SalaryMasterRepository : IHR_SalaryMasterRepository
    {

        private readonly ErpDbContext _db;
        public HR_SalaryMasterRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_SalaryMaster HR_SalaryMaster)
        {
            _db.HR_SalaryMaster.Add(HR_SalaryMaster);
            _db.SaveChanges();
        }

        public void Edit(HR_SalaryMaster HR_SalaryMaster)
        {
            _db.Entry(HR_SalaryMaster).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_SalaryMaster FindById(string id)
        {
            var department = _db.HR_SalaryMaster.Find(id);
            return department;
        }

        public IEnumerable<HR_SalaryMaster> GetAllHR_SalaryMaster()
        {
            return _db.HR_SalaryMaster.ToList();
        }

        public bool IsDuplicate(HR_SalaryMaster HR_SalaryMaster)
        {
            if (HR_SalaryMaster.EmployeeSalaryMasterId == "")
            {
                return _db.HR_SalaryMaster.Any(x => x.EmployeeNo == HR_SalaryMaster.EmployeeNo);
            }

            if (HR_SalaryMaster.EmployeeSalaryMasterId != "")
            {
                HR_SalaryMaster reg = _db.HR_SalaryMaster.FirstOrDefault(x => x.EmployeeNo == HR_SalaryMaster.EmployeeNo);
                if (reg != null && reg.EmployeeSalaryMasterId != HR_SalaryMaster.EmployeeSalaryMasterId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_SalaryMaster.Find(id);

            if (existingRecord != null)
            {
                _db.HR_SalaryMaster.Remove(existingRecord);
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

        IEnumerable<HR_ShortLeaves> IHR_SalaryMasterRepository.GetAllHR_SalaryMaster()
        {
            return _db.HR_ShortLeaves.ToList();
        }
    }
}
