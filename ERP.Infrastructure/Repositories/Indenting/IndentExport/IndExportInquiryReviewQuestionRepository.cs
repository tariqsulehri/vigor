using ERP.Core.IRepositories.Indenting.IndentExport;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting.IndentExport
{
    public class IndExportInquiryReviewQuestionRepository : IIndExportInquiryReviewQuestionRepository
    {
        ErpDbContext db = new ErpDbContext();
        public void Add(IndExportInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public void Edit(IndExportInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndExportInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public IndExportInquiryReviewQuestion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(IndExportInquiryReviewQuestion question)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndExportInquiryReviewQuestion> GetAllQuestions()
        {
            return db.IndExportInquiryReviewQuestions.ToList();
        }
    }
}
