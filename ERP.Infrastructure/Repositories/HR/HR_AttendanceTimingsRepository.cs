using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HR_AttendanceTimingsRepository : IHR_AttendanceTimingsRepository
    {
        private readonly ErpDbContext _db;
        public HR_AttendanceTimingsRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_AttendanceTimings HR_AttendanceTimings)
        {
            _db.HR_AttendanceTimings.Add(HR_AttendanceTimings);
            _db.SaveChanges();
        }

        public string timingExists(HR_AttendanceTimings HR_AttendanceTimings)
        {

            HR_AttendanceTimings existingRecord = _db.HR_AttendanceTimings.Where(s => s.EmployeeAttendanceID == HR_AttendanceTimings.EmployeeAttendanceID && s.AttendanceDate == HR_AttendanceTimings.AttendanceDate).FirstOrDefault();

            if (existingRecord == null) { return "No"; }
            else { return "Yes"; }


        }
        public void Edit(HR_AttendanceTimings HR_AttendanceTimings)
        {
            try
            {
                var existingRecord = _db.HR_AttendanceTimings.Find(HR_AttendanceTimings.EmployeeAttendanceID);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_AttendanceTimings);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_AttendanceTimings FindById(string id)
        {
            var department = _db.HR_AttendanceTimings.Find(id);
            return department;
        }

        public IEnumerable<HR_AttendanceTimings> GetAllHR_AttendanceTimings()
        {
            return _db.HR_AttendanceTimings.ToList();
        }

        public bool IsDuplicate(HR_AttendanceTimings HR_AttendanceTimings)
        {
            throw new NotImplementedException();
            //if (HR_AttendanceTimings.EmployeeAttendanceID == "")
            //{
            //    return _db.HR_AttendanceTimings.Any(x => x.Description == HR_AttendanceTimings.Description);
            //}

            //if (HR_AttendanceTimings.EmployeeAttendanceID != "")
            //{
            //    HR_AttendanceTimings reg = _db.HR_AttendanceTimings.FirstOrDefault(x => x.Description == HR_AttendanceTimings.Description);
            //    if (reg != null && reg.EmployeeAttendanceID != HR_AttendanceTimings.EmployeeAttendanceID)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_AttendanceTimings.Find(id);

            if (existingRecord != null)
            {
                _db.HR_AttendanceTimings.Remove(existingRecord);
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
