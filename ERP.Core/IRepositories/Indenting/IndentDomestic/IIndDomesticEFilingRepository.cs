using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticEFilingRepository
    {
        void Add(IndDomesticEFiling IndDomesticEFiling);
        void Edit(IndDomesticEFiling IndDomesticEFiling);
        bool Remove(IndDomesticEFiling IndDomesticEFiling);
        IndDomesticEFiling FindById(int id);
        bool IsDuplicate(IndDomesticEFiling IndDomesticEFiling);
        IEnumerable<IndDomesticEFiling> GetAllIndDomesticEFilings();
    }
}
