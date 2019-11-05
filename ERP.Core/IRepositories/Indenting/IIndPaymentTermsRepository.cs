using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndPaymentTermsRepository
    {
        void Add(IndPaymentTerms indPaymentTerms);
        void Edit(IndPaymentTerms indPaymentTerms);
        bool Remove(IndPaymentTerms indPaymentTerms);
        IndPaymentTerms FindById(int id);

        bool IsDuplicate(IndPaymentTerms indPaymentTerms);
        IEnumerable<IndPaymentTerms> GetAllIndPaymentTerms();
    }
}
