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
    public class HR_EmployeeQualificationRepository : IHR_EmployeeQualificationRepository
    {

        private readonly ErpDbContext _db;
        public HR_EmployeeQualificationRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_EmployeeQualification HR_EmployeeQualification)
        {
            _db.HR_EmployeeQualification.Add(HR_EmployeeQualification);
            _db.SaveChanges();
        }

        public void Edit(HR_EmployeeQualification HR_EmployeeQualification)
        {
            try
            {
                var existingRecord = _db.HR_EmployeeQualification.Find(HR_EmployeeQualification.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_EmployeeQualification);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_EmployeeQualification FindById(string id)
        {
            var department = _db.HR_EmployeeQualification.Find(id);
            return department;
        }

        public IEnumerable<HR_EmployeeQualification> GetAllHR_EmployeeQualification()
        {
            return _db.HR_EmployeeQualification.ToList();
        }

       

        public bool IsDuplicate(HR_EmployeeQualification HR_EmployeeQualification)
        {
            if (HR_EmployeeQualification.Id == 0)
            {
                return _db.HR_EmployeeQualification.Any(x => x.DegreeId == HR_EmployeeQualification.DegreeId);
            }

            if (HR_EmployeeQualification.Id != 0)
            {
                HR_EmployeeQualification reg = _db.HR_EmployeeQualification.FirstOrDefault(x => x.DegreeId == HR_EmployeeQualification.DegreeId);
                if (reg != null && reg.Id != HR_EmployeeQualification.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_EmployeeQualification.Find(id);

            if (existingRecord != null)
            {
                _db.HR_EmployeeQualification.Remove(existingRecord);
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

