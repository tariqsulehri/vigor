namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_SalaryMasterRepository
    {
        void Add(HR_SalaryMaster HR_SalaryMaster);
        void Edit(HR_SalaryMaster HR_SalaryMaster);
        bool IsDuplicate(HR_SalaryMaster HR_SalaryMaster);
        bool Remove(string id);
        HR_SalaryMaster FindById(string id);
        IEnumerable<HR_ShortLeaves> GetAllHR_SalaryMaster();
    }
}
