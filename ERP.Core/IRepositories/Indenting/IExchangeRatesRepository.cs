using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IExchangeRatesRepository
    {
        void Add(ExchangeRates exchangeRates);
        void Edit(ExchangeRates exchangeRates);
        bool Remove(ExchangeRates exchangeRates);
        ExchangeRates FindById(int id);
        bool IsDuplicate(ExchangeRates exchangeRates);
        IEnumerable<ExchangeRates> GetAllExchangeRates();
    }
}
