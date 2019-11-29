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

    public class HR_MonthlyAttendanceRepository : IHR_MonthlyAttendanceRepository
    {

        private readonly ErpDbContext _db;
        public HR_MonthlyAttendanceRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_MonthlyAttendance HR_MonthlyAttendance)
        {
            _db.HR_MonthlyAttendance.Add(HR_MonthlyAttendance);
            _db.SaveChanges();
        }

        //public void MaxAttenDanceId()
        //{
        //    var a = _db.HR_MonthlyAttendance.Max(x => x.EmployeeAttendanceId.Substring(8, 4)).SingleOrDefault();
        //}

        public void Edit(HR_MonthlyAttendance HR_MonthlyAttendance)
        {
            try
            {
                var existingRecord = _db.HR_MonthlyAttendance.Find(HR_MonthlyAttendance.EmployeeAttendanceId);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_MonthlyAttendance);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_MonthlyAttendance FindById(string id)
        {
            var department = _db.HR_MonthlyAttendance.Find(id);
            return department;
        }

        public IEnumerable<HR_MonthlyAttendance> GetAllHR_MonthlyAttendance()
        {
            return _db.HR_MonthlyAttendance.ToList();
        }

        public bool IsDuplicate(HR_MonthlyAttendance HR_MonthlyAttendance)
        {
            if (HR_MonthlyAttendance.EmployeeAttendanceId == "")
            {
                return _db.HR_MonthlyAttendance.Any(x => x.EmployeeNo == HR_MonthlyAttendance.EmployeeNo);
            }

            if (HR_MonthlyAttendance.EmployeeAttendanceId != "")
            {
                HR_MonthlyAttendance reg = _db.HR_MonthlyAttendance.FirstOrDefault(x => x.EmployeeNo == HR_MonthlyAttendance.EmployeeNo);
                if (reg != null && reg.EmployeeAttendanceId != HR_MonthlyAttendance.EmployeeAttendanceId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDuplicate(HR_ShortLeaves HR_MonthlyAttendance)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_MonthlyAttendance.Find(id);

            if (existingRecord != null)
            {
                _db.HR_MonthlyAttendance.Remove(existingRecord);
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
