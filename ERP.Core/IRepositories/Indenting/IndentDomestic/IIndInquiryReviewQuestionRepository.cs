using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
   public interface IIndInquiryReviewQuestionRepository
    {
        void Add(IndInquiryReviewQuestion question);
        void Edit(IndInquiryReviewQuestion question);
        bool Remove(IndInquiryReviewQuestion question);
        IndInquiryReviewQuestion FindById(int id);
        bool IsDuplicate(IndInquiryReviewQuestion question);
        IEnumerable<IndInquiryReviewQuestion> GetAllQuestions();
    }
}
