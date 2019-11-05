using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface IFinVTypeRepository
    {
        void Add(FinVType finVtype);
        void Edit(FinVType finVType);
        bool Remove(int id);
        FinVType FindById(int id);
		bool IsDuplicate(FinVType finVType);
									

        FinVType FindByVType(string vType);

        IEnumerable<FinVType> GetAllTypes();
    }
}
