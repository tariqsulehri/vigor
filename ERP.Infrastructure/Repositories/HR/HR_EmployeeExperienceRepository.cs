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
    public class HR_EmployeeExperienceRepository : IHR_EmployeeExperienceRepository
    {
        private readonly ErpDbContext _db;
        public HR_EmployeeExperienceRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_EmployeeExperience HR_EmployeeExperience)
        {
            _db.HR_EmployeeExperience.Add(HR_EmployeeExperience);
            _db.SaveChanges();
        }


        public void Edit(HR_EmployeeExperience HR_EmployeeExperience)
        {
            try
            {
                var existingRecord = _db.HR_EmployeeExperience.Find(HR_EmployeeExperience.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_EmployeeExperience);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_EmployeeExperience FindById(string id)
        {
            var department = _db.HR_EmployeeExperience.Find(id);
            return department;
        }

        public IEnumerable<HR_EmployeeExperience> GetAllHR_EmployeeExperience()
        {
            return _db.HR_EmployeeExperience.ToList();
        }

        public bool IsDuplicate(HR_EmployeeExperience HR_EmployeeExperience)
        {
            if (HR_EmployeeExperience.Id == 0)
            {
                return _db.HR_EmployeeExperience.Any(x => x.Designation == HR_EmployeeExperience.Designation);
            }

            if (HR_EmployeeExperience.Id != 0)
            {
                HR_EmployeeExperience reg = _db.HR_EmployeeExperience.FirstOrDefault(x => x.Designation == HR_EmployeeExperience.Designation);
                if (reg != null && reg.Id != HR_EmployeeExperience.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_EmployeeExperience.Find(id);

            if (existingRecord != null)
            {
                _db.HR_EmployeeExperience.Remove(existingRecord);
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
