using System;
using System.Collections.Generic;
using ERP.Core.IRepositories.Indenting.IndentExport;
using ERP.Core.Models.Indenting.IndentExport;
using System.Linq;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndExportInquiryRepository : IIndExportInquiryRepository
    {

        ErpDbContext _db;
        public IndExportInquiryRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(IndExportInquiry indExportInquiry)
        {
            //indExportInquiry.InquiryKey = InquiryKey(indExportInquiry);
            _db.IndExportInquiries.Add(indExportInquiry);
            _db.SaveChanges();
        }

        public void Edit(IndExportInquiry indExportInquiry)
        {
            IndExportInquiry existingRecord = _db.IndExportInquiries.Find(indExportInquiry.Id);
            if (existingRecord != null)
            {
                using (var context = _db.Database.BeginTransaction())
                {
                    try
                    {

                        existingRecord.InquiryKey = indExportInquiry.InquiryKey;
                        existingRecord.Companyid = indExportInquiry.Companyid;
                        existingRecord.DepartmentID = indExportInquiry.DepartmentID;
                        existingRecord.CommodityTypeId = indExportInquiry.CommodityTypeId;
                        existingRecord.InquiryMarket = indExportInquiry.InquiryMarket;
                        existingRecord.InquiryDate = indExportInquiry.InquiryDate;

                        existingRecord.InquiryStatus = indExportInquiry.InquiryStatus;
                        existingRecord.IsClosed = indExportInquiry.IsClosed;
                        existingRecord.InquiryClosedDate = indExportInquiry.InquiryClosedDate;
                        existingRecord.CustomerId = indExportInquiry.CustomerId;

                        existingRecord.PaymenTermsId = indExportInquiry.PaymenTermsId;
                        existingRecord.Remarks = indExportInquiry.Remarks;

                        existingRecord.CreatedOn = indExportInquiry.CreatedOn;
                        existingRecord.CreatedBy = indExportInquiry.CreatedBy;
                        existingRecord.ModifiedBy = indExportInquiry.ModifiedBy;
                        existingRecord.ModifiedOn = DateTime.Now;

                        _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;

                        var cmd = ("DELETE FROM IndExportInquiryDetails WHERE InquiryKey = '" + indExportInquiry.InquiryKey + "'");
                        _db.Database.ExecuteSqlCommand(cmd);
                        _db.SaveChanges();

                        var cmdOffers = ("DELETE FROM IndExportInquiryOffers WHERE InquiryKey = '" + indExportInquiry.InquiryKey + "'");
                        _db.Database.ExecuteSqlCommand(cmdOffers);
                        _db.SaveChanges();

                        foreach (var vDetail in indExportInquiry.IndExportInquiryDetail)
                        {
                            IndExportInquiryDetail dtl = new IndExportInquiryDetail()
                            {
                                InquiryKey = vDetail.InquiryKey,
                                ProductId = vDetail.ProductId,
                                Quantity = vDetail.Quantity,
                                UosId = vDetail.UosId,
                                InquiryDetailNo = vDetail.InquiryDetailNo,
                                InquiryLineItemRemarks = vDetail.InquiryLineItemRemarks,
                            };

                            existingRecord.IndExportInquiryDetail.Add(dtl);

                        }
                        foreach (var vDetail in indExportInquiry.IndExportInquiryOffer)
                        {
                            IndExportInquiryOffer dtl = new IndExportInquiryOffer()
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
                                InquiryDetailNo = vDetail.InquiryDetailNo,
                                ProductId = vDetail.ProductId,

                            };

                            existingRecord.IndExportInquiryOffer.Add(dtl);

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

        public void UpdateInquieryStatus(IndExportInquiry indExportInquiry)
        {
            IndExportInquiry existingRecord = _db.IndExportInquiries.Find(indExportInquiry.Id);
            if (existingRecord != null)
            {
                using (var context = _db.Database.BeginTransaction())
                {
                    try
                    {
                        existingRecord.InquieryStatus = indExportInquiry.InquieryStatus;
                        existingRecord.IsClosed = indExportInquiry.IsClosed;
                        existingRecord.InquiryClosedDate = indExportInquiry.InquiryClosedDate;
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

        public IndExportInquiry FindById(int id)
        {
            var inq = _db.IndExportInquiries.Find(id);
            return inq;

        }

        public IEnumerable<IndExportInquiry> GetAllExportInquires()
        {
            IEnumerable<IndExportInquiry> inqs  =  _db.IndExportInquiries.ToList();
            return inqs;
        }
        
        public bool Remove(IndExportInquiry indExportInquiry)
        {
            var existingRecord = _db.IndExportInquiries.Find(indExportInquiry.Id);

            if (existingRecord != null)
            {
                _db.IndExportInquiries.Remove(existingRecord);
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

        public string InquiryKey(IndExportInquiry indeExportInquiry)
        {
            // 13 Digit Keu =  VIL + Q + 2013 + XXXXX   
            int maxno = _db.IndExportInquiries.Count();
            maxno = maxno + 1;
            string inquiryKey = "VIEQ" + indeExportInquiry.CreatedOn.ToString("yyyy").PadLeft(4, '0') + maxno.ToString().PadLeft(5, '0');
            return inquiryKey;
        }
    }
}
