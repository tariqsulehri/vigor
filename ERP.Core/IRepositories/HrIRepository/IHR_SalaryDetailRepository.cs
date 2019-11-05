namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_SalaryDetailRepository
    {
        void Add(HR_SalaryDetail HR_SalaryDetail);
        void Edit(HR_SalaryDetail HR_SalaryDetail);
        bool IsDuplicate(HR_SalaryDetail HR_SalaryDetail);
        bool Remove(string id);
        HR_SalaryDetail FindById(string id);
        IEnumerable<HR_SalaryDetail> GetAllHR_SalaryDetail();
    }
}
