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
    public class HR_CINCRRepository : IHR_CINCRRepository
    {
        private readonly ErpDbContext _db;
        public HR_CINCRRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_CINCR HR_CINCR)
        {
            _db.HR_CINCR.Add(HR_CINCR);
            _db.SaveChanges();
        }

        public void Edit(HR_CINCR HR_CINCR)
        {
            _db.Entry(HR_CINCR).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_CINCR FindById(string id)
        {
            var department = _db.HR_CINCR.Find(id);
            return department;
        }

        public IEnumerable<HR_CINCR> GetAllHR_CINCR()
        {
            return _db.HR_CINCR.ToList();
        }

        public bool IsDuplicate(HR_CINCR HR_CINCR)
        {
            throw new NotImplementedException();
            //if (HR_CINCR.id == "")
            //{
            //    return _db.HR_CINCR.Any(x => x.Incident  == HR_CINCR.Incident);
            //}

            //if (HR_CINCR.EmployeeAttendanceID != "")
            //{
            //    HR_CINCR reg = _db.HR_CINCR.FirstOrDefault(x => x.Description == HR_CINCR.Description);
            //    if (reg != null && reg.EmployeeAttendanceID != HR_CINCR.EmployeeAttendanceID)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_CINCR.Find(id);

            if (existingRecord != null)
            {
                _db.HR_CINCR.Remove(existingRecord);
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
