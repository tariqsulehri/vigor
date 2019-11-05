using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IUnitOfRateRepository
    {
        void Add(UnitOfRate unitOfRate);
        void Edit(UnitOfRate unitOfRate);
        bool Remove(UnitOfRate unitOfRate);
        UnitOfRate FindById(int id);
        bool IsDuplicate(UnitOfRate unitOfRate);
        IEnumerable<UnitOfRate> GetAllUnitOfRates();

    }
}
