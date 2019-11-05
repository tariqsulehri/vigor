using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface ICurrencyRepository
    {
        void Add(Currency currency);
        void Edit(Currency currency);
        bool Remove(Currency currency);
        Currency FindById(int id);
        bool IsDuplicate(Currency currency);
        IEnumerable<Currency> GetAllCurrencys();
    }
}
