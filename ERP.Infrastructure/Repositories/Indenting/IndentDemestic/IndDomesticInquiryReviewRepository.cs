using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;
using AutoMapper;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndDomesticInquiryReviewRepository : IIndDomesticInquiryReviewRepository
    {
        ErpDbContext _db;

        public IndDomesticInquiryReviewRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndDomesticInquiryReview indDomesticInquiryReview)
        {

            _db.IndDomesticInquiryReviews.Add(indDomesticInquiryReview);
            _db.SaveChanges();


        }

        public void Edit(IndDomesticInquiryReview indDomesticInquiryReview)
        {

            IndDomesticInquiryReview existingRecord = _db.IndDomesticInquiryReviews.Find(indDomesticInquiryReview.Id);
            if (existingRecord != null)
            {
                existingRecord.InquiryKey = indDomesticInquiryReview.InquiryKey;
                existingRecord.InqReviewQuestionId = indDomesticInquiryReview.InqReviewQuestionId;
                existingRecord.InquiryId = indDomesticInquiryReview.InquiryId;
                existingRecord.Status = indDomesticInquiryReview.Status;

                existingRecord.CreatedOn = indDomesticInquiryReview.CreatedOn;
                existingRecord.CreatedBy = indDomesticInquiryReview.CreatedBy;
                existingRecord.ModifiedBy = indDomesticInquiryReview.ModifiedBy;
                existingRecord.ModifiedOn = DateTime.Now;

                _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IndDomesticInquiryReview FindById(int id)
        {
            var rev = _db.IndDomesticInquiryReviews.Find(id);
            return rev;

        }

        public IEnumerable<IndDomesticInquiryReview> GetAllDomecticInquiryReviews()
        {
            IEnumerable<IndDomesticInquiryReview> inqs = _db.IndDomesticInquiryReviews.ToList();
            return inqs;
        }

        public IEnumerable<IndDomesticInquiryReview> GetAllIndDomesticInquiryReviews()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(IndDomesticInquiryReview indDomesticInquiry)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndDomesticInquiryReview indDomesticInquiryReview)
        {
          
            var InqReviewQ = ("Delete  from IndDomesticInquiryReviews" +
                                                      " where InquiryId =" + indDomesticInquiryReview.InquiryId);
            _db.Database.ExecuteSqlCommand(InqReviewQ);


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
