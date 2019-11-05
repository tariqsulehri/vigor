using ERP.Core.IRepositories.Indenting.IndentExport;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting.IndentExport
{
    public class IndExportInquiryOfferRepository : IIndExportInquiryOfferRepository
    {
        ErpDbContext _db;
        public IndExportInquiryOfferRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndExportInquiryOffer indExportInquiryOffer)
        {
            _db.IndExportInquiryOffers.Add(indExportInquiryOffer);
            _db.SaveChanges();
        }

        public void Edit(IndExportInquiryOffer indExportInquiryOffer)
        {
            IndExportInquiryOffer existingRecord = _db.IndExportInquiryOffers.Find(indExportInquiryOffer.Id);
            if (existingRecord != null)
            {
                existingRecord.InquiryKey = indExportInquiryOffer.InquiryKey;
                existingRecord.OfferMadeOn = indExportInquiryOffer.OfferMadeOn;
                existingRecord.CustomerId = indExportInquiryOffer.CustomerId;
                existingRecord.OfferedBy = indExportInquiryOffer.OfferedBy;
                existingRecord.OfferedRate = indExportInquiryOffer.OfferedRate;
                existingRecord.PaymentTermsId = indExportInquiryOffer.PaymentTermsId;
                existingRecord.Remarks = indExportInquiryOffer.Remarks;

                existingRecord.CreatedOn = indExportInquiryOffer.CreatedOn;
                existingRecord.CreatedBy = indExportInquiryOffer.CreatedBy;
                existingRecord.ModifiedBy = indExportInquiryOffer.ModifiedBy;
                existingRecord.ModifiedOn = DateTime.Now;

                _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IndExportInquiryOffer FindById(int id)
        {
            var rev = _db.IndExportInquiryOffers.Find(id);
            return rev;
        }

        public IEnumerable<IndExportInquiryOffer> GetAllIndExportInquiryOffers()
        {
            IEnumerable<IndExportInquiryOffer> inqs = _db.IndExportInquiryOffers.ToList();
            return inqs;
        }

        public bool IsDuplicate(IndExportInquiryOffer indExportInquiryOffer)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndExportInquiryOffer indExportInquiryOffer)
        {
            var existingRecord = _db.IndExportInquiryOffers.Find(indExportInquiryOffer.Id);

            if (existingRecord != null)
            {
                _db.IndExportInquiryOffers.Remove(existingRecord);
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
