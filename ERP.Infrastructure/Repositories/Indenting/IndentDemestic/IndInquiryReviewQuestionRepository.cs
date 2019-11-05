using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.IRepositories.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndInquiryReviewQuestionRepository:IIndInquiryReviewQuestionRepository
    {
        ErpDbContext db=new ErpDbContext();
        public void Add(IndInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public void Edit(IndInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public IndInquiryReviewQuestion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(IndInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndInquiryReviewQuestion> GetAllQuestions()
        {
           return db.IndInquiryReviewQuestions.ToList();
        }
    }
}
