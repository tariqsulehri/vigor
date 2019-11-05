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

    public class HR_LeaveRequestRepository : IHR_LeaveRequestRepository
    {

        private readonly ErpDbContext _db;
        public HR_LeaveRequestRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_LeaveRequest HR_LeaveRequests)
        {
            _db.HR_LeaveRequests.Add(HR_LeaveRequests);
            _db.SaveChanges();
        }

        public void Edit(HR_LeaveRequest HR_LeaveRequests)
        {
            _db.Entry(HR_LeaveRequests).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_LeaveRequest FindById(string id)
        {
            var department = _db.HR_LeaveRequests.Find(id);
            return department;
        }

        public IEnumerable<HR_LeaveRequest> GetAllHr_LeaveRequest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HR_LeaveRequest> GetAllHR_LeaveRequests()
        {
            return _db.HR_LeaveRequests.ToList();
        }

        public bool IsDuplicate(HR_LeaveRequest HR_LeaveRequests)
        {
            if (HR_LeaveRequests.LeaveRequestMasterID == "")
            {
               // return _db.HR_LeaveRequest.Any(x => x.ApplicationDate == HR_LeaveRequests.ApplicationDate);
            }

            if (HR_LeaveRequests.LeaveRequestMasterID != "")
            {
                HR_LeaveRequest reg = _db.HR_LeaveRequests.FirstOrDefault(x => x.ApplicationDate == HR_LeaveRequests.ApplicationDate);
                if (reg != null && reg.LeaveRequestMasterID != HR_LeaveRequests.LeaveRequestMasterID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_LeaveRequests.Find(id);

            if (existingRecord != null)
            {
                _db.HR_LeaveRequests.Remove(existingRecord);
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
