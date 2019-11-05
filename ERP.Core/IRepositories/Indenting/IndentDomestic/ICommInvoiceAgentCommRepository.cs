using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface ICommInvoiceAgentCommRepository
    {
        void Add(CommInvoiceAgentComm commInvoiceAgentComm);
        void Edit(CommInvoiceAgentComm commInvoiceAgentComm);
        bool Remove(CommInvoiceAgentComm commInvoiceAgentComm);
        CommInvoiceAgentComm FindById(int id);
        bool IsDuplicate(CommInvoiceAgentComm commInvoiceAgentComm);
        IEnumerable<CommInvoiceAgentComm> GetAllIndCommInvoiceAgentComm();
    }
}
