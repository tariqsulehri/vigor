using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Core.Models.Party;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class IndExportInquiryController : Controller
    {
        private IndExportInquiryRepository _indExportInquiryRepository;
        private FinPartyRepository _finPartyRepository;

        public IndExportInquiryController()
        {
            _indExportInquiryRepository = new IndExportInquiryRepository();
            _finPartyRepository = new FinPartyRepository();
        }
        // GET: Indent/IndExportInquiry
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime fromDate, DateTime toDate, Int32? commodityId,
            Int32? departmentID, Int32? CustomerId, string Customer)
        {
            ViewBag.IndExportInquiryList = _indExportInquiryRepository.GetAllExportInquires()
                .Where(a => a.CommodityTypeId.Equals(commodityId) || commodityId.Equals(0) || commodityId.Equals(null))
                .Where(a => a.DepartmentID.Equals(departmentID) || departmentID.Equals(0) || departmentID.Equals(null))
                .Where(a => a.CustomerId.Equals(CustomerId) || CustomerId.Equals(0) || CustomerId.Equals(null))
                .Where(a => a.Customer.Trim().Equals(Customer) || Customer.Equals(string.Empty) || Customer.Equals(null))
                .Where(a => a.InquiryDate >= fromDate && a.InquiryDate <= toDate).ToList();

            return View();
        }
        // GET: Indent/IndExportInquiry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult AddAttachments()
        {
            return View();
        }

        public ActionResult ReviewInquiry()
        {
            return View();
        }
        // GET: Indent/IndExportInquiry/Create
        public ActionResult Create(int DepartmentID, int CommodityTypeId)
        {
            IndExportInquiry model = new IndExportInquiry();
            model.InquiryDate = DateTime.Now;
            model.InquiryKey = _indExportInquiryRepository.InquiryKey(model);
            model.DepartmentID = DepartmentID;
            model.CommodityTypeId = CommodityTypeId;
            model.InquiryStatus = Convert.ToChar("Y");
            return View(model);
        }

        // POST: Indent/IndExportInquiry/Create
        [HttpPost]
        public ActionResult Create(IndExportInquiry model)
        {
            if (!String.IsNullOrEmpty(model.Customer))
            {
                ModelState.Remove("CustomerId");
                model.CustomerId = 1;
            }
            else
            {
                model.Customer = " ";
            }
            model.CreatedBy = 1;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 1;
            model.ModifiedOn = DateTime.Now;
            model.Companyid = 2.ToString();
            model.InquiryMarket = "E";
            model.InquieryStatus = "A";
            model.CustomerasBuyer = model.CustomerId;
            model.IsClosed = "C";// 'C';

            ModelState.Remove("Companyid");
            ModelState.Remove("InquiryMarket");
            ModelState.Remove("InquieryStatus");

            if (ModelState.IsValid)
            {
                try
                {
                    model = GetIndExportInquiry(model);
                    model = GetIndExportInquiryOffer(model);
                    _indExportInquiryRepository.Add(model);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                }
            }
            return View(model);
        }

        public ActionResult GetFinPartiesList()
        {
            IEnumerable<FinParty> list = new List<FinParty>();
            list = _finPartyRepository.GetAllParties();
            return View(list);
        }

        // GET: Indent/IndExportInquiry/Edit/5
        public ActionResult Edit(int id)
        {
            List<FinParty> finPartyList = new List<FinParty>();
            List<IndExportInquiryOffer> indExportInquiryOfferList = new List<IndExportInquiryOffer>();
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            var inq = _indExportInquiryRepository.FindById(id);
            inq.IndExportInquiryDetail = inq.IndExportInquiryDetail.Where(a => a.InquiryId == inq.Id).ToList();
            //ViewBag.NewCommodity
            inq.IndExportInquiryOffer = inq.IndExportInquiryOffer.Where(a => a.InquiryId == inq.Id).ToList();

            foreach (var item in inq.IndExportInquiryDetail)
            {
                indExportInquiryOfferList = inq.IndExportInquiryOffer.Where(x => x.InquiryDetailNo.Equals(item.InquiryDetailNo)).ToList();
                break;
            }
            foreach (var item in indExportInquiryOfferList)
            {
                FinParty finParty = new FinParty();
                finParty.Title = item.FinParty.Title;
                finPartyList.Add(finParty);
            }
            ViewBag.CustomerTitleList = finPartyList;
            return View(inq);
        }

        // POST: Indent/IndExportInquiry/Edit/5
        [HttpPost]
        public ActionResult Edit(IndExportInquiry model)
        {
            if (!String.IsNullOrEmpty(model.Customer))
            {
                ModelState.Remove("CustomerId");
                model.CustomerId = 1;
            }
            else
            {
                model.Customer = " ";
            }
            model.ModifiedBy = 1;
            model.ModifiedOn = DateTime.Now;
            model.CustomerasBuyer = model.CustomerId;

            //if (ModelState.IsValid)
            //{
            try
            {
                model = GetIndExportInquiry(model);
                model = GetIndExportInquiryOffer(model);
                _indExportInquiryRepository.Edit(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
            }
            //}
            return View(model);
        }

        // GET: Indent/IndExportInquiry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/IndExportInquiry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region Get Indent Export Inquiry Detail add
        private IndExportInquiry GetIndExportInquiry(IndExportInquiry model)
        {
            var inquiryDetailNo = "";
            int counter = 0;
            IndExportInquiryDetail _IndExportInquiryDetail;
            IndExportInquiryOffer _indExportInquiryOffer;
            var indExportInquiryDetailList = new List<string>();
            var inquiryOfferList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("ProductId"))
                    indExportInquiryDetailList.Add(k.ToString());
            }
            try
            {
                foreach (var Key in indExportInquiryDetailList)
                {
                    var index = "0";
                    index = Key.Replace("][ProductId]", "");
                    index = index.Replace("det[", "");

                    counter = counter + 1;
                    inquiryDetailNo = "00" + counter + model.InquiryKey;


                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][ProductId]"))
                    {
                        _IndExportInquiryDetail = new IndExportInquiryDetail();
                        _indExportInquiryOffer = new IndExportInquiryOffer();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][ProductId]"]))
                        {
                            _IndExportInquiryDetail.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                            _IndExportInquiryDetail.Quantity = Convert.ToDecimal(Request.Form["det[" + index + "][Quantity]"]);
                            _IndExportInquiryDetail.UosId = Convert.ToInt32(Request.Form["det[" + index + "][UosId]"]);
                            _IndExportInquiryDetail.SaleContractIssued = Convert.ToString(Request.Form["det[" + index + "][Sale]"]);
                            _IndExportInquiryDetail.InquiryLineItemRemarks = (Request.Form["det[" + index + "][Remarks]"]);

                            _IndExportInquiryDetail.InquiryId = model.Id;
                            _IndExportInquiryDetail.InquiryKey = model.InquiryKey;
                            _IndExportInquiryDetail.isSampleRecevied = false;
                            _IndExportInquiryDetail.fabricDetail = false;
                            _IndExportInquiryDetail.packingDetail = false;
                            _IndExportInquiryDetail.trimDetail = false;
                            _IndExportInquiryDetail.colorPantoneCode = false;
                            _IndExportInquiryDetail.internalCosting = false;
                            _IndExportInquiryDetail.InquiryDetailNo = inquiryDetailNo;

                            try
                            {
                                model.IndExportInquiryDetail.Add(_IndExportInquiryDetail);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return model;
        }
        #endregion


        #region Get Indent Export Inquiry Offer by dynamic column add
        private IndExportInquiry GetIndExportInquiryOffer(IndExportInquiry model)
        {
            var firstColCustomerId = 0;
            var secondColCustomerId = 0;
            var thirdColCustomerId = 0;
            var fourthColCustomerId = 0;
            var fifthColCustomerId = 0;
            var inquiryDetailNo = "";
            int counter = 0;
            var indExportInquiryDetailList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("ProductId"))
                    indExportInquiryDetailList.Add(k.ToString());
            }
            try
            {
                foreach (var Key in indExportInquiryDetailList)
                {
                    var index = "0";
                    index = Key.Replace("][ProductId]", "");
                    index = index.Replace("det[", "");

                    counter = counter + 1;
                    inquiryDetailNo = "00" + counter + model.InquiryKey;

                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][ProductId]"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][ProductId]"]))
                        {
                            // First Offer Column
                            if (index == "0")
                            {
                                if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][OfferCustomerId1]"]))
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId1]"]);
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount1]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);
                                    firstColCustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId1]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);
                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                if (firstColCustomerId > 0)
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = firstColCustomerId;
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount1]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);

                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            // Second Offer Column
                            if (index == "0")
                            {
                                if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][OfferCustomerId2]"]))
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId2]"]);
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount2]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);
                                    secondColCustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId2]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);
                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                if (secondColCustomerId > 0)
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = secondColCustomerId;
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount2]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);

                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            // Third Offer Column
                            if (index == "0")
                            {
                                if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][OfferCustomerId3]"]))
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId3]"]);
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount3]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);
                                    thirdColCustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId3]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);
                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                if (thirdColCustomerId > 0)
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = thirdColCustomerId;
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount3]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);

                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            // Fourth Offer Column
                            if (index == "0")
                            {
                                if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][OfferCustomerId4]"]))
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId4]"]);
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount4]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);
                                    fourthColCustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId4]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);
                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                if (fourthColCustomerId > 0)
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = fourthColCustomerId;
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount4]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);

                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            // Fifth Offer Column
                            if (index == "0")
                            {
                                if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][OfferCustomerId5]"]))
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId5]"]);
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount5]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);
                                    fifthColCustomerId = Convert.ToInt32(Request.Form["det[" + index + "][OfferCustomerId5]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);
                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                if (fifthColCustomerId > 0)
                                {
                                    IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();
                                    _indExportInquiryOffer.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]);
                                    _indExportInquiryOffer.CustomerId = fifthColCustomerId;
                                    _indExportInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][OfferAmount5]"]);
                                    _indExportInquiryOffer.Remarks = Convert.ToString(Request.Form["det[" + index + "][Remarks]"]);

                                    _indExportInquiryOffer.InquiryId = model.Id;
                                    _indExportInquiryOffer.InquiryKey = model.InquiryKey;
                                    _indExportInquiryOffer.PaymentTermsId = model.PaymenTermsId;
                                    _indExportInquiryOffer.InquiryDetailNo = inquiryDetailNo;

                                    _indExportInquiryOffer = AssignValueIndExportInquiryOffer(_indExportInquiryOffer);

                                    try
                                    {
                                        model.IndExportInquiryOffer.Add(_indExportInquiryOffer);
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return model;
        }
        #endregion


        private IndExportInquiryOffer AssignValueIndExportInquiryOffer(IndExportInquiryOffer model)
        {
            IndExportInquiryOffer _indExportInquiryOffer = new IndExportInquiryOffer();

            _indExportInquiryOffer.CustomerId = model.CustomerId;
            _indExportInquiryOffer.OfferedRate = model.OfferedRate;
            _indExportInquiryOffer.Remarks = model.Remarks;
            _indExportInquiryOffer.InquiryId = model.Id;
            _indExportInquiryOffer.InquiryKey = model.InquiryKey;
            _indExportInquiryOffer.PaymentTermsId = model.PaymentTermsId;
            _indExportInquiryOffer.InquiryDetailNo = model.InquiryDetailNo;
            _indExportInquiryOffer.ProductId = model.ProductId;

            _indExportInquiryOffer.OfferMadeOn = DateTime.Now;
            _indExportInquiryOffer.OfferedBy = "xyz";
            _indExportInquiryOffer.CreatedBy = 0;
            _indExportInquiryOffer.CreatedOn = DateTime.Now;
            _indExportInquiryOffer.ModifiedBy = 0;
            _indExportInquiryOffer.ModifiedOn = DateTime.Now;
            return _indExportInquiryOffer;
        }
    }
}
