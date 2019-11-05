using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface ICompanyRepository
    {
        void Add(Company company);
        void Edit(Company company);
        bool Remove(int ccode);
        Company FindById(int ccode);
        bool IsDuplicate(Company company);	
        IEnumerable<Company> GetAllCompanies();

    }
}
