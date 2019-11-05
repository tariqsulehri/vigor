namespace ERP.Core.IRepositories.HrIRepository
{
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public interface IHR_ShortLeavesRepository
    {
        void Add(HR_ShortLeaves HR_ShortLeaves);
        void Edit(HR_ShortLeaves HR_ShortLeaves);
        bool IsDuplicate(HR_ShortLeaves HR_ShortLeaves);
        bool Remove(string id);
        HR_ShortLeaves FindById(string id);
        IEnumerable<HR_ShortLeaves> GetAllHR_ShortLeaves();

    }
}
