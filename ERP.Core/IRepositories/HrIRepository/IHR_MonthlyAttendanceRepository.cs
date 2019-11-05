namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_MonthlyAttendanceRepository
    {
        void Add(HR_MonthlyAttendance HR_MonthlyAttendance);
        void Edit(HR_MonthlyAttendance HR_MonthlyAttendance);
        bool IsDuplicate(HR_ShortLeaves HR_MonthlyAttendance);
        bool Remove(string id);
        HR_MonthlyAttendance FindById(string id);
        IEnumerable<HR_MonthlyAttendance> GetAllHR_MonthlyAttendance();
    }
}
