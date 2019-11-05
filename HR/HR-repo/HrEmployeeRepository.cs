using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HrEmployeeRepository : HrEmployeeIRepository
    {
        private readonly ErpDbContext _db;
        public HrEmployeeRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HrEmployee hrEmployee)
        {
            _db.HrEmployee.Add(hrEmployee);
            _db.SaveChanges();
        }

        public void Edit(HrEmployee hrEmployee)
        {
            _db.Entry(hrEmployee).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
		 public bool IsDuplicate(HrEmployee hrEmployee)
        {

            if (hrEmployee.Id == 0)
            {
                return _db.HrEmployee.Any(x => x.Title == hrEmployee.Title);
            }

            if (hrEmployee.Id != 0)
            {
                HrEmployee reg = _db.HrEmployee.FirstOrDefault(x => x.Title == hrEmployee.Title);
                if (reg != null && reg.Id != hrEmployee.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.HrEmployee.Find(id);

            if (existingRecord != null)
            {
                _db.HrEmployee.Remove(existingRecord);
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

        public HrEmployee FindById(int id)
        {
            var employee = _db.HrEmployee.Find(id);
            return employee;
        }

        public IEnumerable<HrEmployee> GetAllEmployees()
        {
            return _db.HrEmployee.ToList();
        }
    }
}
