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
    public class HR_EmployeeLeaveBalanceRepository : IHR_EmployeeLeaveBalanceRepository
    {
        private readonly ErpDbContext _db;
        public HR_EmployeeLeaveBalanceRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_EmployeeLeaveBalance HR_EmployeeLeaveBalance)
        {
            _db.HR_EmployeeLeaveBalance.Add(HR_EmployeeLeaveBalance);
            _db.SaveChanges();
        }

        public void Edit(HR_EmployeeLeaveBalance HR_EmployeeLeaveBalance)
        {
            try
            {
                var existingRecord = _db.HR_EmployeeLeaveBalance.Find(HR_EmployeeLeaveBalance.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_EmployeeLeaveBalance);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_EmployeeLeaveBalance FindById(string id)
        {
            var department = _db.HR_EmployeeLeaveBalance.Find(id);
            return department;
        }

        public IEnumerable<HR_EmployeeLeaveBalance> GetAllHR_EmployeeLeaveBalance()
        {
            return _db.HR_EmployeeLeaveBalance.ToList();
        }

        public bool IsDuplicate(HR_EmployeeLeaveBalance HR_EmployeeLeaveBalance)
        {
            if (HR_EmployeeLeaveBalance.Id == 0)
            {
                return _db.HR_EmployeeLeaveBalance.Any(x => x.LeavesInBalance == HR_EmployeeLeaveBalance.LeavesInBalance);
            }

            if (HR_EmployeeLeaveBalance.Id != 0)
            {
                HR_EmployeeLeaveBalance reg = _db.HR_EmployeeLeaveBalance.FirstOrDefault(x => x.LeavesInBalance == HR_EmployeeLeaveBalance.LeavesInBalance);
                if (reg != null && reg.Id != HR_EmployeeLeaveBalance.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UpdatLeaveRequest(HR_LeaveRequest HR_LeaveRequests)
        {
            if (HR_LeaveRequests.IsApproved == true)
            {
                var days = (HR_LeaveRequests.LeaveRequestedTo - HR_LeaveRequests.LeaveRequiredFrom).TotalDays + 1;

                HR_EmployeeLeaveBalance empLeaves = _db.HR_EmployeeLeaveBalance.Where(x => x.EmployeeId == HR_LeaveRequests.EmployeeId).SingleOrDefault();
                if (empLeaves != null)
                {
                    empLeaves.LeavesInBalance = empLeaves.LeavesInBalance - Convert.ToInt32(days);
                    empLeaves.LeavesConsumed = empLeaves.LeavesConsumed + Convert.ToInt32(days);
                }

                var existingRecord = _db.HR_EmployeeLeaveBalance.Where(x => x.EmployeeId == HR_LeaveRequests.EmployeeId).SingleOrDefault();

                _db.Entry(existingRecord).CurrentValues.SetValues(empLeaves);
                _db.SaveChanges();
            }


            HR_LeaveRequest empLeavesRequest = _db.HR_LeaveRequests.Where(x => x.LeaveRequestMasterID == HR_LeaveRequests.LeaveRequestMasterID).SingleOrDefault();
            var existingRecrod1 = _db.HR_LeaveRequests.Where(x => x.LeaveRequestMasterID == HR_LeaveRequests.LeaveRequestMasterID).SingleOrDefault();
            if (HR_LeaveRequests.IsApproved == true)
            {
                empLeavesRequest.IsPending = false;
                empLeavesRequest.ApprovedOn = DateTime.Now;
                empLeavesRequest.IsActive = false;
            }
            else
            {
                empLeavesRequest.IsPending = false;
                empLeavesRequest.IsActive = false;
            }


            _db.Entry(existingRecrod1).CurrentValues.SetValues(empLeavesRequest);
            _db.SaveChanges();
            //------------------------------
            return true;
        }
        public bool Remove(string id)
        {
            var existingRecord = _db.HR_EmployeeLeaveBalance.Find(id);

            if (existingRecord != null)
            {
                _db.HR_EmployeeLeaveBalance.Remove(existingRecord);
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
