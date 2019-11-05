using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
    public interface IIndExportInquiryReviewQuestionRepository
    {
        void Add(IndExportInquiryReviewQuestion question);
        void Edit(IndExportInquiryReviewQuestion question);
        bool Remove(IndExportInquiryReviewQuestion question);
        IndExportInquiryReviewQuestion FindById(int id);
        bool IsDuplicate(IndExportInquiryReviewQuestion question);
        IEnumerable<IndExportInquiryReviewQuestion> GetAllQuestions();
    }
}
