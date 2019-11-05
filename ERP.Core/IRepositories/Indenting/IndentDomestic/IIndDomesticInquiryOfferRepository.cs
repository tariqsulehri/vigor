using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticInquiryOfferRepository
    {
        void Add(IndDomesticInquiryOffer indDomesticInquiryOffer);
        void Edit(IndDomesticInquiryOffer indDomesticInquiryOffer);
        bool Remove(IndDomesticInquiryOffer indDomesticInquiryOffer);
        IndDomesticInquiryOffer FindById(int id);
        bool IsDuplicate(IndDomesticInquiryOffer indDomesticInquiryOffer);
        IEnumerable<IndDomesticInquiryOffer> GetAllIndDomesticInquiryOffers();
    }
}
