using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndDomesticInquiryOfferRepository : IIndDomesticInquiryOfferRepository
    {
        ErpDbContext _db;
        public IndDomesticInquiryOfferRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndDomesticInquiryOffer indDomesticInquiryOffer)
        {
            _db.IndDomesticInquiryOffers.Add(indDomesticInquiryOffer);
            _db.SaveChanges();
        }

        public void Edit(IndDomesticInquiryOffer indDomesticInquiryOffer)
        {
            IndDomesticInquiryOffer existingRecord = _db.IndDomesticInquiryOffers.Find(indDomesticInquiryOffer.Id);
            if (existingRecord != null)
            {
                existingRecord.InquiryKey = indDomesticInquiryOffer.InquiryKey;
                existingRecord.OfferMadeOn = indDomesticInquiryOffer.OfferMadeOn;
                existingRecord.CustomerId = indDomesticInquiryOffer.CustomerId;
                existingRecord.OfferedBy = indDomesticInquiryOffer.OfferedBy;
                existingRecord.OfferedRate = indDomesticInquiryOffer.OfferedRate;
                existingRecord.PaymentTermsId = indDomesticInquiryOffer.PaymentTermsId;
                existingRecord.Remarks = indDomesticInquiryOffer.Remarks;

                existingRecord.CreatedOn = indDomesticInquiryOffer.CreatedOn;
                existingRecord.CreatedBy = indDomesticInquiryOffer.CreatedBy;
                existingRecord.ModifiedBy = indDomesticInquiryOffer.ModifiedBy;
                existingRecord.ModifiedOn = DateTime.Now;

                _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IndDomesticInquiryOffer FindById(int id)
        {
            var rev = _db.IndDomesticInquiryOffers.Find(id);
            return rev;
        }

        public IEnumerable<IndDomesticInquiryOffer> GetAllIndDomesticInquiryOffers()
        {
            IEnumerable<IndDomesticInquiryOffer> inqs = _db.IndDomesticInquiryOffers.ToList();
            return inqs;
        }

        public bool IsDuplicate(IndDomesticInquiryOffer indDomesticInquiryOffer)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndDomesticInquiryOffer indDomesticInquiryOffer)
        {
            var existingRecord = _db.IndDomesticInquiryOffers.Find(indDomesticInquiryOffer.Id);

            if (existingRecord != null)
            {
                _db.IndDomesticInquiryOffers.Remove(existingRecord);
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
