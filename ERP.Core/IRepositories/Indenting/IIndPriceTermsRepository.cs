using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndPriceTermsRepository
    {
        void Add(IndPriceTerms indPriceTerms);
        void Edit(IndPriceTerms indPriceTerms);
        bool Remove(IndPriceTerms indPriceTerms);
        IndPriceTerms FindById(int id);
        bool IsDuplicate(IndPriceTerms indPriceTerms);
        IEnumerable<IndPriceTerms> GetAllIndPriceTerms();
    }
}
