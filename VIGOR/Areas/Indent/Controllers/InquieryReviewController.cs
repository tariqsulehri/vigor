using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Common;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.Indent.Controllers
{
    public class InquieryReviewController : Controller
    {
        private ERP.Infrastructure.ErpDbContext _db = new ErpDbContext();
        private IndDomesticInquiryReviewRepository indDomesticInquiryReviewRepository;
        private IndDomesticInquiryRepository _indDomesticInquiryRepository;
        private IndInquiryReviewQuestionRepository _indInquiryReviewQuestion;
        public InquieryReviewController()
        {
            indDomesticInquiryReviewRepository = new IndDomesticInquiryReviewRepository();
            _indDomesticInquiryRepository = new IndDomesticInquiryRepository();
            _indInquiryReviewQuestion = new IndInquiryReviewQuestionRepository();
        }
        // GET: Indent/InquieryReview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            IndDomesticInquiryReview model = new IndDomesticInquiryReview();
            FinPartyRepository finParty = new FinPartyRepository();
            var inq = _indDomesticInquiryRepository.FindById(id);
            model.CreatedOn = inq.InquiryDate;
            model.InquiryId = inq.Id;
            model.InquiryKey = inq.InquiryKey;
            model.BuyerId = inq.CustomerId;
            model.InquiryId = inq.Id;
            ViewBag.SellerId = new SelectList(from v in finParty.GetAllParties()
                                             join offerVender in inq.IndDomesticInquiryOffers on v.Id equals offerVender.CustomerId
                                             select new
                                             {
                                                 Id = v.Id,
                                                 Title = v.Title
                                             }, "Id", "Title");
            ViewBag.Department = inq.HrDepartment.Title;
            if (String.IsNullOrEmpty(inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().NewCommodity))
                ViewBag.Product = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().Product.Description;
            else
                ViewBag.Product = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().NewCommodity;

            ViewBag.Quantity = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().Quantity;
            ViewBag.UosId = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().UnitOfSale.Description;
            var inquiryReview = inq.IndDomesticInquiryReviews.Where(a=>a.Status).ToList();
            var inquiryReviewQuestions = _indInquiryReviewQuestion.GetAllQuestions().ToList();
            foreach (var question in inquiryReviewQuestions)
            {
                question.IsActive = false;
            }
                foreach (var review in inquiryReview)
            {
                foreach (var question in inquiryReviewQuestions)
                {
                    if (review.InqReviewQuestionId == question.Id)
                    {
                        if (review.Status)
                            question.IsActive = true;
                    }
                }
            }
                model.indInquiryReviewQuestion = inquiryReviewQuestions;
          /*
           if (inquiryReview.Count > 0)
            {
                model.indInquiryReviewQuestion = (from s in inquiryReviewQuestions
                                                  join review in inquiryReview on s.Id equals review.InqReviewQuestionId
                                                  where review.InquiryId.Equals(inq.Id)
                                                  select s).ToList();
            }
            else
            {
                model.indInquiryReviewQuestion = inquiryReviewQuestions;
            }
            */



            return PartialView("~/Areas/Indent/Views/InquieryReview/_Review.cshtml", model);
        }

        // POST: Indent/Inquiry/Create
        [HttpPost]
        public ActionResult Create(IndDomesticInquiryReview model)
        {
            try
            {

                List<IndInquiryReviewQuestion> lstIndInquiryReviewQuestions = new List<IndInquiryReviewQuestion>();
                lstIndInquiryReviewQuestions = GetInquieryQuestion();
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = 1;
                model.ModifiedOn = DateTime.Now;
                model.InquiryKey = model.InquiryKey;
                indDomesticInquiryReviewRepository.Remove(model);
                IndDomesticInquiry IndDomesticInquiry = new IndDomesticInquiry();
                if (model.InquiryId > 0)
                {
                   
                    IndDomesticInquiry.Id = model.InquiryId;
                    IndDomesticInquiry.InquiryStatus = Convert.ToString((char)InquieryStatus.InProcess);
                    IndDomesticInquiry.IsClosed = "N";
                    _indDomesticInquiryRepository.UpdateInquieryStatus(IndDomesticInquiry);
                }
                foreach (var question in lstIndInquiryReviewQuestions)
                {
                    model.Status = question.IsActive;
                    model.InqReviewQuestionId = (question.Id);
                    //indDomesticInquiryReviewRepository.Remove(model);
                    indDomesticInquiryReviewRepository.Add(model);
                }
                return RedirectToAction("Create", "IndentDomestic", new { id = model.InquiryId });


            }
            catch (Exception e)
            {
                throw e;

            }
        }


        private List<IndInquiryReviewQuestion> GetInquieryQuestion()
        {
            List<IndInquiryReviewQuestion> lstIndInquiryReviewQuestions = new List<IndInquiryReviewQuestion>();
            IndInquiryReviewQuestion inquiryReviewQuestion;
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
                    inquiryReviewQuestion = new IndInquiryReviewQuestion();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][InquiryReviewQuestion]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][QuestionID]"]))
                        { inquiryReviewQuestion.Id = Convert.ToInt32(Request.Form["det[" + index + "][QuestionID]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][InquiryReviewQuestion]"]))
                        { inquiryReviewQuestion.InquiryReviewQuestion = (Request.Form["det[" + index + "][InquiryReviewQuestion]"]); }
                        if (Request.Form["det[" + index + "][IsActive]"] != null && Request.Form["det[" + index + "][IsActive]"] == "true,false")
                        {
                            inquiryReviewQuestion.IsActive = true;
                        }
                        else
                        {
                            inquiryReviewQuestion.IsActive = false;
                        }
                        lstIndInquiryReviewQuestions.Add(inquiryReviewQuestion);
                    }
                }

            }

            return lstIndInquiryReviewQuestions;
        }


    }
}