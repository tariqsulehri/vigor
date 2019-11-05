using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_AttendanceTimingsRepository
    {
        void Add(HR_AttendanceTimings HR_AttendanceTimings);
        void Edit(HR_AttendanceTimings HR_AttendanceTimings);
        bool IsDuplicate(HR_AttendanceTimings HR_AttendanceTimings);
        bool Remove(string id);
        HR_AttendanceTimings FindById(string id);
        IEnumerable<HR_AttendanceTimings> GetAllHR_AttendanceTimings();

    }
}
