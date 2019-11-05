using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface IStateRepository
    {
        void Add(State state);
        void Edit(State state);
        bool Remove(int scode);
        State FindById(int scode);
         bool IsDuplicate(State state);
        IEnumerable<State> GetAllStates();

    }
}
