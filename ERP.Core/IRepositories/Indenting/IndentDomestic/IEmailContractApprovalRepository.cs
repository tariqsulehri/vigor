using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IEmailContractApprovalRepository
    {
        void Add(EmailContractApproval EmailContractApproval);
        void Edit(EmailContractApproval EmailContractApproval);
        bool Remove(EmailContractApproval EmailContractApproval);
        EmailContractApproval FindById(int id);
        IEnumerable<EmailContractApproval> GetAllEmailContractApprovals();
    }
}
