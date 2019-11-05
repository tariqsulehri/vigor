using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_AllowanceModesRepository
    {
        void Add(HR_AllowanceModes HR_AllowanceModes);
        void Edit(HR_AllowanceModes HR_AllowanceModes);
        bool IsDuplicate(HR_AllowanceModes HR_AllowanceModes);
        bool Remove(string id);
        HR_AllowanceModes FindById(string id);
        IEnumerable<HR_AllowanceModes> GetAllHR_AllowanceModes();
    }

}

