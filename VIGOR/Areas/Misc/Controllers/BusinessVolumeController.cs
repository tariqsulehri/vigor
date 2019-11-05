using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using ERP.Core.Models.Admin;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using VIGOR.Reports;
using VIGOR.ViewsModel;
using ERP.Infrastructure.Repositories.Parties;
using ERP.Core.Models.Indenting.IndentDomestic;
using System.Net.Mail;

namespace VIGOR.Areas.Misc.Controllers
{
    public class BusinessVolumeController : Controller
    {
        private IndDomesticRepository _indDomestic;
        private FinPartyRepository _finparty;

        public BusinessVolumeController()
        {
            _indDomestic = new IndDomesticRepository();
            _finparty = new FinPartyRepository();
        }
        // GET: Misc/BusinessVolume
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Approvals()
        {
            var contract = _indDomestic.GetAllIndDomectic();
            List<view_IndDomestic_detail> lst = new List<view_IndDomestic_detail>();
            foreach (var item in contract)
            {
                view_IndDomestic_detail obj = new view_IndDomestic_detail()
                {
                    LocalContractNo = item.IndentKey,
                    IndentDate = item.IndentDate,
                    seller = _finparty.FindById(item.CustomerIDasSeller).Title,
                    CustomerAsBuyer = _finparty.FindById(item.CustomerIDasBuyer).Title,
                    Revision = item.RevisionNumber,
                    IndentStatus = item.IndentStatus,
                    indentClosed = item.isClosed,
                    IsApproved = item.IsApproved,
                    indentId = item.Id,
                    IsSubmitForApproval = item.IsSubmitForApproval,
                    DepartmentID = item.DepartmentID,
                    Department = item.HrDepartment.Title
                };
                lst.Add(obj);

            }
            Session["lst"] = lst;
            return PartialView("_Approvals", lst);
        }
        public ActionResult Approved(int id)
        {

            EmailContractApproval email = new EmailContractApproval();
            FinPartyRepository party = new FinPartyRepository();
            if (id > 0)
            {
                var indent = _indDomestic.FindById(id);
                email.FromEmail = LoggedinUser.Company.Email;
                email.ToEmail = party.FindById(indent.CustomerId).EmailAddress;
                email.DepartmentId = indent.DepartmentID;
                email.IndentKey = indent.IndentKey;
                email.IndentId = indent.Id;
                email.ApprovedOn = DateTime.Now;
                ViewBag.ApprovedBy = LoggedinUser.LoggedInUser.FirstName + " " + LoggedinUser.LoggedInUser.LastName;
                email.ApprovedBy = LoggedinUser.LoggedInUser.Id;
            }
            return PartialView("_Approved", email);
        }
        [HttpPost]
        public ActionResult Approved(EmailContractApproval model)
        {
            if (ModelState.IsValid)
            {
                if (model.emailComments)
                {
                    string FromEmail = LoggedinUser.LoggedInUser.FirstName + " " + LoggedinUser.LoggedInUser.LastName;
                    #region Email
                    new EmailContractApprovalRepository().Add(model);
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("waqar_baryar@yahoo.com"));
                    message.Subject = "Your email subject";
                    message.Body = string.Format(body, FromEmail, "waqarasghar497@outlook.com", model.comments);
                    message.IsBodyHtml = true;
                    using (var smtp = new SmtpClient())
                    {
                        smtp.Send(message);
                    }
                    #endregion
                }
                if (model.approved)
                {
                    IndDomestic domesticContrct = new IndDomestic()
                    {
                        Id = model.IndentId,
                        IsSubmitForApproval = true,
                        LastApprovedOn = model.ApprovedOn,
                        IsApproved = true,
                        ApprovedBy = model.ApprovedBy
                    };
                    _indDomestic.Update(domesticContrct);
                }
                return null;
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult Report(int id)
        {
            TempData["Id"] = id;
            return View();
        }
        public CustomeReportAction ContrractReport()
        {
            int? IndId = Convert.ToInt32(TempData["Id"]);
            ReportDocument reportDocument = new ReportDocument();
            string reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "SaleContract.rpt");
            reportDocument = CustomeReportAction.SetUsersInfo(reportPath);
            reportDocument.SetParameterValue("@indId", IndId);
            reportDocument.SetParameterValue("@CompName", LoggedinUser.Company.Name.Trim());
            reportDocument.SetParameterValue("@Address", LoggedinUser.Company.MailAddress);
            reportDocument.SetParameterValue("@Phone", "Phone " + LoggedinUser.Company.Phone);
            reportDocument.SetParameterValue("@Fax", "Fax " + LoggedinUser.Company.Fax);
            reportDocument.SetParameterValue("@WebSite", "WebSite " + LoggedinUser.Company.WebAddress);
            reportDocument.SetParameterValue("@Email", "Email " + LoggedinUser.Company.Email);

            return new CustomeReportAction(reportDocument);
        }
        // GET: Misc/BusinessVolume/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Misc/BusinessVolume/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Misc/BusinessVolume/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Misc/BusinessVolume/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Misc/BusinessVolume/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Misc/BusinessVolume/Delete/5
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
    }
}
