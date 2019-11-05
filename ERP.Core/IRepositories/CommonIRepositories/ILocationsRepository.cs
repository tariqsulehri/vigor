using ERP.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface ILocationsRepository
    {
        void Add(Locations locations);
        void Edit(Locations locations);
        bool Remove(Locations location);
        Locations FindById(int Id);
        bool IsDuplicate(Locations Locations);
        IEnumerable<Locations> GetAllLocations();
    }
}
