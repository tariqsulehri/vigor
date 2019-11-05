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
    public class HR_EmployeeTypeRepository : IHR_EmployeeTypeRepository
    {

        private readonly ErpDbContext _db;
        public HR_EmployeeTypeRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_EmployeeType HR_EmployeeType)
        {
            _db.HR_EmployeeType.Add(HR_EmployeeType);
            _db.SaveChanges();
        }

        public void Edit(HR_EmployeeType HR_EmployeeType)
        {
            try
            {
                var existingRecord = _db.HR_EmployeeType.Find(HR_EmployeeType.EmployeeTypeID);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_EmployeeType);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_EmployeeType FindById(string id)
        {
            var department = _db.HR_EmployeeType.Find(id);
            return department;
        }

        public IEnumerable<HR_EmployeeType> GetAllHR_EmployeeType()
        {
            return _db.HR_EmployeeType.ToList();
        }

        public bool IsDuplicate(HR_EmployeeType HR_EmployeeType)
        {
            if (HR_EmployeeType.EmployeeTypeID == "")
            {
                return _db.HR_EmployeeType.Any(x => x.Description == HR_EmployeeType.Description);
            }

            if (HR_EmployeeType.EmployeeTypeID != "")
            {
                HR_EmployeeType reg = _db.HR_EmployeeType.FirstOrDefault(x => x.Description == HR_EmployeeType.Description);
                if (reg != null && reg.EmployeeTypeID != HR_EmployeeType.EmployeeTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_EmployeeType.Find(id);

            if (existingRecord != null)
            {
                _db.HR_EmployeeType.Remove(existingRecord);
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
