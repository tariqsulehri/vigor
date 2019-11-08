using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Core.Models.Party;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Indenting.IndentExport;
namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class IndExportInquiryReviewController : Controller
    {
        private IndExportInquiryReviewRepository _reviewRepository;
        private IndExportInquiryRepository _indExportInquiryRepository;
        private IndInquiryReviewQuestionRepository _indInquiryReviewQuestion;
        private IndExportInquiryOfferRepository _indExportInquiryOfferRepository;
        private IndExportInquiryReviewRepository _indExportInquiryReviewRepository;
        private IndExportInquiryReviewQuestionRepository _indExportInquiryReviewQuestionRepository;
        public IndExportInquiryReviewController()
        {
            _reviewRepository = new IndExportInquiryReviewRepository();
            _indExportInquiryRepository = new IndExportInquiryRepository();
            _indInquiryReviewQuestion = new IndInquiryReviewQuestionRepository();
            _indExportInquiryOfferRepository = new IndExportInquiryOfferRepository();
            _indExportInquiryReviewRepository = new IndExportInquiryReviewRepository();
            _indExportInquiryReviewQuestionRepository = new IndExportInquiryReviewQuestionRepository();
        }
        // GET: Indent/InquieryReview
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            IndExportInquiry model = new IndExportInquiry();
            List<FinParty> finPartyList = new List<FinParty>();
            List<IndExportInquiryOffer> indExportInquiryOfferList = new List<IndExportInquiryOffer>();
            model = _indExportInquiryRepository.FindById(id);
            model.IndExportInquiryDetail = model.IndExportInquiryDetail.Where(a => a.InquiryId == model.Id).ToList();
            model.IndExportInquiryOffer = model.IndExportInquiryOffer.Where(a => a.InquiryId == model.Id).ToList();
            ViewBag.IndExportInquiryReviewQuestions = _indExportInquiryReviewQuestionRepository.GetAllQuestions();
            model.CreatedOn = model.InquiryDate;
            model.Id = model.Id;
            model.InquiryKey = model.InquiryKey;
            ViewBag.Department = model.HrDepartment.Title;
            ViewBag.Customer = model.FinParty.Title;
            foreach (var item in model.IndExportInquiryDetail)
            {
                indExportInquiryOfferList = model.IndExportInquiryOffer.Where(x => x.InquiryDetailNo.Equals(item.InquiryDetailNo)).ToList();
                break;
            }
            foreach (var item in indExportInquiryOfferList)
            {
                FinParty finParty = new FinParty();
                finParty.Id = item.CustomerId;
                finParty.Title = item.FinParty.Title;
                finPartyList.Add(finParty);
            }
            ViewBag.CustomerTitleList = finPartyList;
            List<SelectListItem> CustomerDropDownList = new SelectList(finPartyList, "Id", "Title").ToList();
            ViewBag.CustomerDropDownList = CustomerDropDownList;
            //   model.IndInquiryReviewQuestion = _indInquiryReviewQuestion.GetAllQuestions().ToList();
            return PartialView("~/Areas/Indent/Views/IndExportInquiryReview/ExportInquieryReview.cshtml", model);
        }

        // POST: Indent/Inquiry/Create
        [HttpPost]
        public ActionResult Create(IndExportInquiryReview model)
        {
            try
            {
                string CustomerId = string.Empty;
                List<IndExportInquiryReview> IndExportInquiryReviewList = new List<IndExportInquiryReview>();
                List<IndExportInquiryDetail> IndExportInquiryDetailList = new List<IndExportInquiryDetail>();

                CustomerId = Request.Form["CustomerId"];
                if (string.IsNullOrEmpty(CustomerId))
                {
                    ModelState.AddModelError("CustomerId", "Please select order comfirm to.");
                }
                ModelState.Remove("InquiryReviewQuestion");
                model.InquiryId = model.Id;
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = 1;
                model.ModifiedOn = DateTime.Now;
                model.InquiryKey = model.InquiryKey;
                if (ModelState.IsValid)
                {
                    IndExportInquiryReviewList = GetInquieryQuestion(model);
                    IndExportInquiryDetailList = GetIndExportInquiryDetail();
                    foreach (var question in IndExportInquiryReviewList)
                    {
                        model.InqReviewQuestionId = question.InqReviewQuestionId;
                        model.Status = question.Status;
                        model.InquiryReviewQuestion = question.InquiryReviewQuestion;

                        _indExportInquiryReviewRepository.Add(model);
                    }

                    foreach (var item in IndExportInquiryDetailList)
                    {
                        if (item.InquiryDetailNo != null)
                        {
                            var exportInquiryOfferList = _indExportInquiryOfferRepository.GetAllIndExportInquiryOffers().Where(x => x.InquiryDetailNo == item.InquiryDetailNo && x.CustomerId == int.Parse(CustomerId));
                            foreach (var InquiryOffer in exportInquiryOfferList)
                            {
                                var foundInquiryOffer = _indExportInquiryOfferRepository.FindById(InquiryOffer.Id);
                                foundInquiryOffer.IsFinalized = true;
                                _indExportInquiryOfferRepository.Edit(foundInquiryOffer);
                            }
                        }
                    }
                }
                return null;
                //return RedirectToAction("Index", "IndExportInquiry");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "IndExportInquiry");
            }
        }

        private List<IndExportInquiryReview> GetInquieryQuestion(IndExportInquiryReview model)
        {
            List<IndExportInquiryReview> IndExportInquiryReviewList = new List<IndExportInquiryReview>();
            IndExportInquiryReview _indExportInquiryReview;
            var gridKeysList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("InquiryReviewQuestion"))
                    gridKeysList.Add(k.ToString());
            }
            foreach (var Key in gridKeysList)
            {
                var index = "0";
                index = Key.Replace("][InquiryReviewQuestion]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][InquiryReviewQuestion]"))
                {
                    _indExportInquiryReview = new IndExportInquiryReview();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][InquiryReviewQuestion]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][QuestionID]"]))
                        { _indExportInquiryReview.InqReviewQuestionId = Convert.ToInt32(Request.Form["det[" + index + "][QuestionID]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][InquiryReviewQuestion]"]))
                        { _indExportInquiryReview.InquiryReviewQuestion = (Request.Form["det[" + index + "][InquiryReviewQuestion]"]); }
                        if (Request.Form["det[" + index + "][IsActive]"] != null && Request.Form["det[" + index + "][IsActive]"] == "true,false")
                        {
                            _indExportInquiryReview.Status = true;
                        }
                        else
                        {
                            _indExportInquiryReview.Status = false;
                        }
                        IndExportInquiryReviewList.Add(_indExportInquiryReview);
                    }
                }

            }
            return IndExportInquiryReviewList;
        }

        private List<IndExportInquiryDetail> GetIndExportInquiryDetail()
        {
            List<IndExportInquiryDetail> IndExportInquiryDetailList = new List<IndExportInquiryDetail>();
            IndExportInquiryDetail _indExportInquiryDetail;
            bool isFinalized;
            var gridKeysList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("ProductId"))
                    gridKeysList.Add(k.ToString());
            }
            foreach (var Key in gridKeysList)
            {
                var index = "0";
                index = Key.Replace("][ProductId]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][ProductId]"))
                {
                    _indExportInquiryDetail = new IndExportInquiryDetail();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][ProductId]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][ProductId]"]))
                        { _indExportInquiryDetail.ProductId = Convert.ToInt32(Request.Form["det[" + index + "][ProductId]"]); }
                        if (Request.Form["det[" + index + "][IsFinalized]"] != null && Request.Form["det[" + index + "][IsFinalized]"] == "true,false")
                        {
                            isFinalized = true;
                        }
                        else
                        {
                            isFinalized = false;
                        }
                        if (isFinalized)
                        {
                            if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][InquiryDetailNo]"]))
                            { _indExportInquiryDetail.InquiryDetailNo = (Request.Form["det[" + index + "][InquiryDetailNo]"]); }
                        }
                        IndExportInquiryDetailList.Add(_indExportInquiryDetail);
                    }
                }

            }
            return IndExportInquiryDetailList;
        }

    }
}