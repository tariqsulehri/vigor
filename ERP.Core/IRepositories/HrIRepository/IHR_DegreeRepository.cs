using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_DegreeRepository
    {
        void Add(HR_Degree HR_Degree);
        void Edit(HR_Degree HR_Degree);
        bool IsDuplicate(HR_Degree HR_Degree);
        bool Remove(string id);
        HR_Degree FindById(string id);
        IEnumerable<HR_Degree> GetAllHR_Degree();

    }
}
