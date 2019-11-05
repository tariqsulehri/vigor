using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HrDepartmentRepository : IHrDepartmentIRepository
    {
        private readonly ErpDbContext _db;
        public HrDepartmentRepository()
        {
            _db =  new ErpDbContext();
        }
        public void Add(HrDepartment hrDepartment)
        {
            _db.HrDepartments.Add(hrDepartment);
            _db.SaveChanges();
        }

        public void Edit(HrDepartment hrDepartment)
        {
            _db.Entry(hrDepartment).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            
        }
		  public bool IsDuplicate(HrDepartment hrDepartment)
        {

            if (hrDepartment.id == 0)
            {
                return _db.HrDepartments.Any(x => x.Title == hrDepartment.Title);
            }

            if (hrDepartment.id != 0)
            {
                HrDepartment reg = _db.HrDepartments.FirstOrDefault(x => x.Title == hrDepartment.Title);
                if (reg != null && reg.id != hrDepartment.id)
                {
                    return true;
                }
            }
            return false;
        }												  
        public bool Remove(int id)
        {
            var existingRecord = _db.HrDepartments.Find(id);

            if (existingRecord != null)
            {
                _db.HrDepartments.Remove(existingRecord);
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

        public HrDepartment FindById(int id)
        {
            var department = _db.HrDepartments.Find(id);
            return department;
        }

        public IEnumerable<HrDepartment> GetAllDepartment()
        {
            return _db.HrDepartments.ToList();
        }
    }
}
