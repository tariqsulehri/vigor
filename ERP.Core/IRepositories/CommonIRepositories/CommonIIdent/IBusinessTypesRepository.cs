using System.Collections.Generic;
using ERP.Core.Models.Common;

namespace ERP.Core.IRepositories.CommonIRepositories.CommonIIdent
{
    public interface IBusinessTypesRepository
    {
        void Add(BusinessTypes businessTypes);
        void Edit(BusinessTypes businessTypes);
	 bool IsDuplicate(BusinessTypes businessTypes);		  
        bool Remove(int bcode);
        BusinessTypes FindById(int bcode);
        IEnumerable<BusinessTypes> GetAllBusinessTypes();
    }
}
