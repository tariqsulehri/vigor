namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_LoanAdvanceApplicationRepository
    {
        void Add(HR_LoanAdvanceApplication HR_LoanAdvanceApplication);
        void Edit(HR_LoanAdvanceApplication HR_LoanAdvanceApplication);
        bool IsDuplicate(HR_LoanAdvanceApplication HR_LoanAdvanceApplication);
        bool Remove(string id);
        HR_LoanAdvanceApplication FindById(string id);
        IEnumerable<HR_LoanAdvanceApplication> GetAllHR_LoanAdvanceApplication();
    }
}
