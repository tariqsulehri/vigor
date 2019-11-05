using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndGeneralDescriptionsRepository
    {
        void Add(IndGeneralDescriptions indGeneralDescriptions);
        void Edit(IndGeneralDescriptions indGeneralDescriptions);
        bool Remove(IndGeneralDescriptions indGeneralDescriptions);
        IndGeneralDescriptions FindById(int id);

        bool IsDuplicate(IndGeneralDescriptions indGeneralDescriptions);
        IEnumerable<IndGeneralDescriptions> GetAllIndGeneralDescriptions();
    }
}
