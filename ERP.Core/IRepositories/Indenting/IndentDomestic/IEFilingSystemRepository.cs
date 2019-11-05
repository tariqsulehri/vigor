using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IEFilingSystemRepository
    {
        void Add(EFilingSystem IndDomesticEFiling);
        void Edit(EFilingSystem IndDomesticEFiling);
        bool Remove(EFilingSystem IndDomesticEFiling);
        EFilingSystem FindById(int id);
        bool IsDuplicate(EFilingSystem IndDomesticEFiling);
        IEnumerable<EFilingSystem> GetAllIndDomesticEFilings();
    }
}
