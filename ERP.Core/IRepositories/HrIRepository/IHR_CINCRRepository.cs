using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_CINCRRepository
    {
        void Add(HR_CINCR HR_CINCR);
        void Edit(HR_CINCR HR_CINCR);
        bool IsDuplicate(HR_CINCR HR_CINCR);
        bool Remove(string id);
        HR_CINCR FindById(string id);
        IEnumerable<HR_CINCR> GetAllHR_CINCR();

    }
}
