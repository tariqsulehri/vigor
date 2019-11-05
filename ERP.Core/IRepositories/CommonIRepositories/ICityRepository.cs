using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface ICityRepository
    {
        void Add(City city);
        void Edit(City city);
        bool Remove(int ctcode);
        City FindById(int ctcode);
        bool IsDuplicate(City city);
        IEnumerable<City> GetAllCities();
    }
}
