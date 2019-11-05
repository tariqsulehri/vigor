using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Indenting.IndentExport;
namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class IndExportInquiryReviewController : Controller
    {
        private IndExportInquiryReviewRepository _reviewRepository;
        private IndExportInquiryRepository _indExportInquiryRepository;
        private IndInquiryReviewQuestionRepository _indInquiryReviewQuestion;
        public IndExportInquiryReviewController()
        {
            _reviewRepository = new IndExportInquiryReviewRepository();
            _indExportInquiryRepository = new IndExportInquiryRepository();
            _indInquiryReviewQuestion = new IndInquiryReviewQuestionRepository();
        }
        // GET: Indent/InquieryReview
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            IndExportInquiry model = new IndExportInquiry();
            var inq = _indExportInquiryRepository.FindById(id);
            model.CreatedOn = inq.InquiryDate;
            model.Id = inq.Id;
            model.InquiryKey = inq.InquiryKey;
            ViewBag.Department = inq.HrDepartment.Title;
            ViewBag.Customer = inq.FinParty.Title;
         //   model.IndInquiryReviewQuestion = _indInquiryReviewQuestion.GetAllQuestions().ToList();
            return PartialView("~/Areas/Indent/Views/IndExportInquiryReview/ExportInquieryReview.cshtml", model);
        }

        // POST: Indent/Inquiry/Create
        [HttpPost]
        public ActionResult Create(IndDomesticInquiryReview model)
        {
            try
            {
                model = GetInquieryQuestion(model);

                model.CreatedOn = DateTime.Now;
                model.CreatedBy = 1;
                model.ModifiedOn = DateTime.Now;
                //   model.IndDomesticInquiry = _indDomesticInquiryRepository.FindById(model.InquiryId);
                model.InquiryKey = model.InquiryKey;
                foreach (var question in model.indInquiryReviewQuestion)
                {
                    model.Status = question.IsActive;
                    model.InqReviewQuestionId =Convert.ToInt32( question.InquiryReviewQuestion);
                    //indDomesticInquiryReviewRepository.Add(model);
                }
                return RedirectToAction("Create", "IndentDomestic", new { id = model.InquiryId }); ;


            }
            catch (Exception e)
            {

                return RedirectToAction("Create", "IndentDomestic", new { id = model.InquiryId }); ;
            }
        }


        private IndDomesticInquiryReview GetInquieryQuestion(IndDomesticInquiryReview model)
        {
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
                        model.indInquiryReviewQuestion.Add(inquiryReviewQuestion);
                    }
                }

            }

            return model;
        }


    }
}