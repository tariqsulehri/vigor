using ERP.Core.IRepositories.Indenting.IndentExport;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting.IndentExport
{
    public class IndExportInquiryReviewRepository : IIndExportInquiryReviewRepository
    {
        ErpDbContext _db;

        public IndExportInquiryReviewRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndExportInquiryReview indExportInquiryReview)
        {

            _db.IndExportInquiryReviews.Add(indExportInquiryReview);
            _db.SaveChanges();


        }

        public void Edit(IndExportInquiryReview indExportInquiryReview)
        {

            IndExportInquiryReview existingRecord = _db.IndExportInquiryReviews.Find(indExportInquiryReview.Id);
            if (existingRecord != null)
            {
                existingRecord.InquiryKey = indExportInquiryReview.InquiryKey;
                existingRecord.InquiryReviewQuestion = indExportInquiryReview.InquiryReviewQuestion;
                existingRecord.InquiryId = indExportInquiryReview.InquiryId;
                existingRecord.Status = indExportInquiryReview.Status;

                existingRecord.CreatedOn = indExportInquiryReview.CreatedOn;
                existingRecord.CreatedBy = indExportInquiryReview.CreatedBy;
                existingRecord.ModifiedBy = indExportInquiryReview.ModifiedBy;
                existingRecord.ModifiedOn = DateTime.Now;

                _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IndExportInquiryReview FindById(int id)
        {
            var rev = _db.IndExportInquiryReviews.Find(id);
            return rev;

        }

        public IEnumerable<IndExportInquiryReview> GetAllDomecticInquiryReviews()
        {
            IEnumerable<IndExportInquiryReview> inqs = _db.IndExportInquiryReviews.ToList();
            return inqs;
        }

        public IEnumerable<IndExportInquiryReview> GetAllIndExportInquiryReviews()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(IndExportInquiryReview indExportInquiry)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndExportInquiryReview indExportInquiryReview)
        {
            var existingRecord = _db.IndExportInquiryReviews.Find(indExportInquiryReview.Id);

            if (existingRecord != null)
            {
                _db.IndExportInquiryReviews.Remove(existingRecord);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }

    }
}
