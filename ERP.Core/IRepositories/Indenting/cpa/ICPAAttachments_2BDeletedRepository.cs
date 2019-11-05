using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICPAAttachments_2BDeletedRepository
    {
        void Add(CPAAttachments_2BDeleted CPAAttachments_2BDeleted);
        void Edit(CPAAttachments_2BDeleted CPAAttachments_2BDeleted);
        bool Remove(CPAAttachments_2BDeleted CPAAttachments_2BDeleted);
        CPAAttachments_2BDeleted FindById(string CPAAttachments_2BDeletedID);
        bool IsDuplicate(CPAAttachments_2BDeleted CPAAttachments_2BDeleted);
        IEnumerable<CPAAttachments_2BDeleted> GetAllCPAAttachments_2BDeleteds();
    }
}
