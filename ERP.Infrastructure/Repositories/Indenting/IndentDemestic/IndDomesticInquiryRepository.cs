using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndDomesticInquiryRepository : IIndDomesticInquiryRepository
    {

        ErpDbContext _db;
        public IndDomesticInquiryRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndDomesticInquiry indDomesticInquiry)
        {
            indDomesticInquiry.InquiryKey = InquiryKey(indDomesticInquiry);
            _db.IndDomesticInquires.Add(indDomesticInquiry);
            _db.SaveChanges();
        }

        public void Edit(IndDomesticInquiry indDomesticInquiry)
        {
            IndDomesticInquiry existingRecord = _db.IndDomesticInquires.Find(indDomesticInquiry.Id);
            if (existingRecord != null)
            {
                using (var context = _db.Database.BeginTransaction())
                {
                    try
                    {

                        existingRecord.InquiryKey = indDomesticInquiry.InquiryKey;
                        existingRecord.Companyid = indDomesticInquiry.Companyid;
                        existingRecord.DepartmentID = indDomesticInquiry.DepartmentID;
                        existingRecord.CommodityTypeId = indDomesticInquiry.CommodityTypeId;
                        existingRecord.InquiryMarket = indDomesticInquiry.InquiryMarket;
                        existingRecord.InquiryDate = indDomesticInquiry.InquiryDate;

                        existingRecord.InquiryStatus = indDomesticInquiry.InquiryStatus;
                        existingRecord.IsClosed = indDomesticInquiry.IsClosed;
                        existingRecord.InquiryClosedDate = indDomesticInquiry.InquiryClosedDate;
                        existingRecord.CustomerId = indDomesticInquiry.CustomerId;

                        existingRecord.PaymenTermsId = indDomesticInquiry.PaymenTermsId;
                        existingRecord.Remarks = indDomesticInquiry.Remarks;

                        existingRecord.CreatedOn = indDomesticInquiry.CreatedOn;
                        existingRecord.CreatedBy = indDomesticInquiry.CreatedBy;
                        existingRecord.ModifiedBy = indDomesticInquiry.ModifiedBy;
                        existingRecord.ModifiedOn = DateTime.Now;

                        _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
										  


                        var cmd = ("DELETE FROM IndDomesticInquiryDetails WHERE InquiryKey = '" + indDomesticInquiry.InquiryKey + "'");
                        _db.Database.ExecuteSqlCommand(cmd);
                        _db.SaveChanges();

                        var cmdOffers = ("DELETE FROM IndDomesticInquiryOffers WHERE InquiryKey = '" + indDomesticInquiry.InquiryKey + "'");
                        _db.Database.ExecuteSqlCommand(cmdOffers);
                        _db.SaveChanges();

                        foreach (var vDetail in indDomesticInquiry.IndDomesticInquiryDetails)
                        {
                            IndDomesticInquiryDetail dtl = new IndDomesticInquiryDetail()
                            {
                                InquiryKey = vDetail.InquiryKey,
                                ProductId = vDetail.ProductId,
                                Quantity = vDetail.Quantity,
                                UosId = vDetail.UosId,
                                NewCommodity = vDetail.NewCommodity
                            };

                            existingRecord.IndDomesticInquiryDetails.Add(dtl);

                        }
                        foreach (var vDetail in indDomesticInquiry.IndDomesticInquiryOffers)
                        {
                            IndDomesticInquiryOffer dtl = new IndDomesticInquiryOffer()
                            {
                                InquiryKey = vDetail.InquiryKey,
                                InquiryId = vDetail.InquiryId,
                                OfferMadeOn = vDetail.OfferMadeOn,
                                CustomerId = vDetail.CustomerId,
                                OfferedBy = vDetail.OfferedBy,
                                OfferedRate = vDetail.OfferedRate,
                                PaymentTermsId = vDetail.PaymentTermsId,
                                Remarks = vDetail.Remarks,
                                CreatedBy = vDetail.CreatedBy,
                                CreatedOn = vDetail.CreatedOn,
                                ModifiedOn = vDetail.ModifiedOn,
                                ModifiedBy = vDetail.ModifiedBy,

                            };

                            existingRecord.IndDomesticInquiryOffers.Add(dtl);

                        }
                        _db.Database.ExecuteSqlCommand(cmd);
                        _db.SaveChanges();
                        context.Commit();
                    }
                    catch (Exception e)
                    {
                        context.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }
        public void UpdateInquieryStatus(IndDomesticInquiry indDomesticInquiry)
        {
            IndDomesticInquiry existingRecord = _db.IndDomesticInquires.Find(indDomesticInquiry.Id);
            if (existingRecord != null)
            {
                using (var context = _db.Database.BeginTransaction())
                {
                    try
                    {
                        existingRecord.InquiryStatus = indDomesticInquiry.InquiryStatus;
                        existingRecord.IsClosed = indDomesticInquiry.IsClosed;
                        existingRecord.InquiryClosedDate = indDomesticInquiry.InquiryClosedDate;
                        _db.SaveChanges();
                        context.Commit();

                    }
                    catch (Exception e)
                    {
                        context.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }
        public IndDomesticInquiry FindById(int id)
        {
            var inq = _db.IndDomesticInquires.Find(id);
            return inq;

        }

        public IEnumerable<IndDomesticInquiry> GetAllDomecticInquires()
        {
            IEnumerable<IndDomesticInquiry> inqs = _db.IndDomesticInquires.ToList();
            return inqs;
        }

        public bool IsDuplicate(IndDomesticInquiry indDomesticInquiry)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndDomesticInquiry indDomesticInquiry)
        {
            var existingRecord = _db.IndDomesticInquires.Find(indDomesticInquiry.Id);

            if (existingRecord != null)
            {
                _db.IndDomesticInquires.Remove(existingRecord);
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

        public string InquiryKey(IndDomesticInquiry indeDomesticInquiry)
        {
            // 13 Digit Keu =  VIL + Q + 2013 + XXXXX   
            int maxno = _db.IndDomesticInquires.Count();
            maxno = maxno + 1;
            string inquiryKey = "VILQ" + indeDomesticInquiry.CreatedOn.ToString("yyyy").PadLeft(4, '0') + maxno.ToString().PadLeft(5, '0');
            return inquiryKey;
        }
    }
}
