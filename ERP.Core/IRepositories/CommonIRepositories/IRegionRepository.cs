using System.Collections.Generic;
using ERP.Core.Models.Common;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface IRegionRepository
    {
        void Add(Region region);
        void Edit(Region region);
        bool Remove(int rcode);
        Region FindById(int rcode);
        bool IsDuplicate(Region region);
        IEnumerable<Region> GetAllRegions();


    }
}
