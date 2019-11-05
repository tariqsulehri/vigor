using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface ICountryRepository
    {
        void Add(Country country);
        void Edit(Country country);
        bool Remove(int ccode);
        Country FindById(int ccode);
        bool IsDuplicate(Country country);
        IEnumerable<Country> GetAllCountries();
    }
}
