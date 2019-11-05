using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticInquiryRepository
    {
        void Add(IndDomesticInquiry indDomesticInquiry);
        void Edit(IndDomesticInquiry indDomesticInquiry);
        bool Remove(IndDomesticInquiry indDomesticInquiry);
        IndDomesticInquiry FindById(int id);
        bool IsDuplicate(IndDomesticInquiry indDomesticInquiry);
        IEnumerable<IndDomesticInquiry> GetAllDomecticInquires();

    }
}
