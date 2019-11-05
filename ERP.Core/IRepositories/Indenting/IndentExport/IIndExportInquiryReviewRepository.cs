using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
   public  interface IIndExportInquiryReviewRepository
    {
        void Add(IndExportInquiryReview indExportInquiryReview);
        void Edit(IndExportInquiryReview indExportInquiryReview);
        bool Remove(IndExportInquiryReview indExportInquiryReview);
        IndExportInquiryReview FindById(int id);
        bool IsDuplicate(IndExportInquiryReview indExportInquiryReview);
        IEnumerable<IndExportInquiryReview> GetAllIndExportInquiryReviews();

    }
}
