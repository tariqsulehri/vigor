using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_AllowancesRepository
    {
        void Add(HR_Allowances HR_Allowances);
        void Edit(HR_Allowances HR_Allowances);
        bool IsDuplicate(HR_Allowances HR_Allowances);
        bool Remove(string id);
        HR_Allowances FindById(string id);
        IEnumerable<HR_Allowances> GetAllHR_Allowances();
    }
}

 
