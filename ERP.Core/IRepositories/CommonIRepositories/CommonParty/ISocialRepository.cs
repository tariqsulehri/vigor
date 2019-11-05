using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common.Party;

namespace ERP.Core.IRepositories.CommonIRepositories.CommonParty
{
    public interface ISocialRepository
    {
        void Add(Social socail);
        void Edit(Social social);
        bool Remove(int id);
        Social FindById(int id);
        bool IsDuplicate(Social social);
        IEnumerable<Social> GetAllSocials();
    }
}
