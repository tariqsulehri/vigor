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

    public class HR_SalaryDetailRepository : IHR_SalaryDetailRepository
    {

        private readonly ErpDbContext _db;
        public HR_SalaryDetailRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_SalaryDetail HR_SalaryDetail)
        {
            _db.HR_SalaryDetail.Add(HR_SalaryDetail);
            _db.SaveChanges();
        }

        public void Edit(HR_SalaryDetail HR_SalaryDetail)
        {
            try
            {
                var existingRecord = _db.HR_SalaryDetail.Find(HR_SalaryDetail.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_SalaryDetail);

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_SalaryDetail FindById(string id)
        {
            var department = _db.HR_SalaryDetail.Find(id);
            return department;
        }

        public IEnumerable<HR_SalaryDetail> GetAllHR_SalaryDetail()
        {
            return _db.HR_SalaryDetail.ToList();
        }

        public bool IsDuplicate(HR_SalaryDetail HR_SalaryDetail)
        {
            if (HR_SalaryDetail.EmployeeSalaryMasterId == "")
            {
                return _db.HR_SalaryDetail.Any(x => x.Mode == HR_SalaryDetail.Mode);
            }

            if (HR_SalaryDetail.EmployeeSalaryMasterId != "")
            {
                HR_SalaryDetail reg = _db.HR_SalaryDetail.FirstOrDefault(x => x.Mode == HR_SalaryDetail.Mode);
                if (reg != null && reg.EmployeeSalaryMasterId != HR_SalaryDetail.EmployeeSalaryMasterId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_SalaryDetail.Find(id);

            if (existingRecord != null)
            {
                _db.HR_SalaryDetail.Remove(existingRecord);
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
