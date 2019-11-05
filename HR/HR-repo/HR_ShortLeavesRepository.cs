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

    public class HR_ShortLeavesRepository : IHR_ShortLeavesRepository
    {

        private readonly ErpDbContext _db;
        public HR_ShortLeavesRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_ShortLeaves HR_ShortLeaves)
        {
            _db.HR_ShortLeaves.Add(HR_ShortLeaves);
            _db.SaveChanges();
        }

        public void Edit(HR_ShortLeaves HR_ShortLeaves)
        {
            _db.Entry(HR_ShortLeaves).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_ShortLeaves FindById(string id)
        {
            var department = _db.HR_ShortLeaves.Find(id);
            return department;
        }

        public IEnumerable<HR_ShortLeaves> GetAllHR_ShortLeaves()
        {
            return _db.HR_ShortLeaves.ToList();
        }

        public bool IsDuplicate(HR_ShortLeaves HR_ShortLeaves)
        {
            if (HR_ShortLeaves.EmployeeAttendanceID == "")
            {
                return _db.HR_ShortLeaves.Any(x => x.EmployeeNo == HR_ShortLeaves.EmployeeNo);
            }

            if (HR_ShortLeaves.EmployeeAttendanceID != "")
            {
                HR_ShortLeaves reg = _db.HR_ShortLeaves.FirstOrDefault(x => x.EmployeeNo == HR_ShortLeaves.EmployeeNo);
                if (reg != null && reg.EmployeeAttendanceID != HR_ShortLeaves.EmployeeAttendanceID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_ShortLeaves.Find(id);

            if (existingRecord != null)
            {
                _db.HR_ShortLeaves.Remove(existingRecord);
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
