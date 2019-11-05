
using ERP.Core.Models.Indenting.IndentDomestic;
using System.Collections.Generic;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticInquiryReviewRepository
    {
        void Add(IndDomesticInquiryReview indDomesticInquiryReview);
        void Edit(IndDomesticInquiryReview indDomesticInquiryReview);
        bool Remove(IndDomesticInquiryReview indDomesticInquiryReview);
        IndDomesticInquiryReview FindById(int id);
        bool IsDuplicate(IndDomesticInquiryReview indDomesticInquiryReview);
        IEnumerable<IndDomesticInquiryReview> GetAllIndDomesticInquiryReviews();
    }
}
