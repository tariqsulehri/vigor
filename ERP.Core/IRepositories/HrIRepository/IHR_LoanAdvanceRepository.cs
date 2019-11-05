namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_LoanAdvanceRepository
    {
        void Add(HR_LoanAdvance HR_LoanAdvance);
        void Edit(HR_LoanAdvance HR_LoanAdHR_LoanAdvancevance);
        bool IsDuplicate(HR_LoanAdvance HR_LoanAdvance);
        bool Remove(string id);
        HR_LoanAdvance FindById(string id);
        IEnumerable<HR_LoanAdvance> GetAllHR_LoanAdvance();
    }
}
