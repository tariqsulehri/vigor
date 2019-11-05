using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface IFinFescalYearRepository
    {
        void Add(FinFescalYear fescalYear);
        void Edit(FinFescalYear fescalYear);
        bool Remove(int id);
	   bool IsDuplicate(FinFescalYear fescalYear);							   
        FinFescalYear FindById(int id);
        IEnumerable<FinFescalYear> GetAllFescalYears();
    }
}





