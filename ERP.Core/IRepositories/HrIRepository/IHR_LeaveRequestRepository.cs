namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_LeaveRequestRepository
    {
        void Add(HR_LeaveRequest HR_ShortLeaves);
        void Edit(HR_LeaveRequest HR_ShortLeaves);
        bool IsDuplicate(HR_LeaveRequest HR_ShortLeaves);
        bool Remove(string id);
        HR_LeaveRequest FindById(string id);
        IEnumerable<HR_LeaveRequest> GetAllHr_LeaveRequest();
    }
}
