﻿using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Admin;

namespace VIGOR.Areas.Indent.Controllers
{
    public class DispatchController : Controller
    {
        EFilingSystemRepository efileRepo = new EFilingSystemRepository();
        IndDomesticDispatchScheduleRepository _indDomesticDispatchScheduleRepository;
        private ProductRepository ProductRepository;
        private IndDomesticRepository _indDomestic;
        public DispatchController()
        {
            _indDomestic = new IndDomesticRepository();
            _indDomesticDispatchScheduleRepository = new IndDomesticDispatchScheduleRepository();
            ProductRepository = new ProductRepository();
        }
        // GET: Indent/Dispatch
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Attachment(int id)
        {
            EFilingSystem efile = new EFilingSystem();
            List<EFilingSystem> lst = new List<EFilingSystem>();
            var indentDispatch = _indDomesticDispatchScheduleRepository.FindById(id);
            efile.ReferenceID1 = indentDispatch.LocalDispatchNo;
            efile.ReferenceID2 = id.ToString();
            efile.CompanyId = LoggedinUser.Company.Id;
            efile.Company_Key = LoggedinUser.Company.Id.ToString();
            ViewBag.Efile = lst = efileRepo.GetAllIndDomesticEFilings().Where(a => a.ReferenceID1.Equals(efile.ReferenceID1) && a.ReferenceID2 == id.ToString()).ToList();
            return View(efile);
        }
        [HttpPost]
        public ActionResult Attachment(EFilingSystem efile, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                List<EFilingSystem> eFilingSystems = new List<EFilingSystem>();
                eFilingSystems = GetEFiles(efile);
                foreach (var file in files)
                {
                    foreach (var item in eFilingSystems)
                    {
                        if (!String.IsNullOrEmpty(item.EFilingID))
                        {
                            efileRepo.Remove(item);
                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileExtention = Path.GetExtension(file.FileName);
                            if (!string.IsNullOrEmpty(item.EFilingID) && !string.IsNullOrEmpty(item.FileAttached))
                            {
                                System.IO.File.Delete(Server.MapPath("~/File/" + item.FileAttached));
                                file.SaveAs(Path.Combine(Server.MapPath("~/File"), item.EFilingID + fileExtention));
                            }
                            if (String.IsNullOrEmpty(item.EFilingID))
                            {
                                item.EFilingID = efileRepo.NewFileKey(item);
                                item.FileAttached = item.EFilingID + fileExtention;
                                file.SaveAs(Path.Combine(Server.MapPath("~/File"), efile.EFilingID + fileExtention));
                            }
                        }
                        efileRepo.Add(item);
                        eFilingSystems.Remove(item);
                        break;
                    }
                }
                return null;
            }
            catch (Exception e) { throw e; }
        }
        // GET: Indent/Dispatch/Details/5
        public ActionResult Details(int id)
        {
            var data = _indDomestic.FindById(id);
            if (data.isCancelled || data.isClosed || !(data.IndentStatus))
            {
                ModelState.AddModelError("", "You cant not perform operations of closed or cancel Contract");
            }
            return View(data);
        }

        // GET: Indent/Dispatch/Create
        public ActionResult Create(int id)
        {
            IndDomesticDispatchSchedule model = new IndDomesticDispatchSchedule();
            var indent = _indDomestic.FindById(id);
            model.ContractedDeliveryDate = indent.DelDateValidUpto;
            model.TransDate = DateTime.Now;
            model.TypeOfTransaction = "D";
            ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                        Prodect => Prodect.Id,
                        IndentDetail => IndentDetail.CommodityId,
                        (Prodect, IndentDetail) => new
                        {
                            Id = Prodect.Id,
                            Description = Prodect.Description
                        }), "Id", "Description");

            model.IndentId = id;
            ViewBag.IndentKey = indent.IndentKey;

            model.IsDelayed = model.TransDate > model.ContractedDeliveryDate ? "Y" : "N";
            return View(model);
        }

        // POST: Indent/Dispatch/Create
        [HttpPost]
        public ActionResult Create(IndDomesticDispatchSchedule model, string IndentKey)
        {
            try
            {
                ModelState.Remove("DelayShipmentReason");
                ModelState.Remove("SalesContractDetail");
                ModelState.Remove("LocalDispatchNo");
                ModelState.Remove("isFirstDispatch");
                ModelState.Remove("IsReceivedStinv");
                ModelState.Remove("IsComplaint");
                ModelState.Remove("SalestaxInvoiceNo");

                if (ModelState.IsValid)
                {
                    if (model.IsDelayed == "N")
                    {
                        model.DelayShipmentReason = "_";
                        model.DelayShipmentReasonDescription = "_";
                    }
                    UnitOfSaleRepository _unitOfSaleRepository = new UnitOfSaleRepository();
                    Int32 UnitOsSaleID = Convert.ToInt32(Request.Form["UnitOsSaleID"]);
                    decimal Rate = Convert.ToDecimal(Request.Form["Rate"]);
                    var UOS = _unitOfSaleRepository.FindById(UnitOsSaleID);
                    var domesticIndent = _indDomestic.FindById(model.IndentId);
                    model.Balance = model.Quantity * Rate * UOS.Factor;
                    model.CompanyId = LoggedinUser.Company.Id;
                    model.LocalDispatchNo = LoggedinUser.Company.Id.ToString() + IndentKey;
                    model.SalesContractDetail = model.LocalDispatchNo;
                    model.CreatedOn = DateTime.Now;
                    model.ModifiedOn = DateTime.Now;
                    model.SalestaxInvoiceDate = DateTime.Now;
                    model.IsReceivedStinv = "N";
                    model.SalestaxInvoiceNo = "1";
                    model.IsComplaint = "N";
                    model.isFirstDispatch = "1";
                    _indDomesticDispatchScheduleRepository.Add(model);
                    return null;
                }
                else
                {
                    var indent = _indDomestic.FindById(model.IndentId);
                    ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                        Prodect => Prodect.Id,
                        IndentDetail => IndentDetail.CommodityId,
                        (Prodect, IndentDetail) => new
                        {
                            Id = Prodect.Id,
                            Description = Prodect.Description
                        }), "Id", "Description");
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Indent/Dispatch/Edit/5
        public ActionResult Edit(int id)
        {
            IndDomesticDispatchSchedule model = new IndDomesticDispatchSchedule();
            model = _indDomesticDispatchScheduleRepository.FindById(id);
            var indent = _indDomestic.FindById(model.IndentId);
            ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                Prodect => Prodect.Id,
                IndentDetail => IndentDetail.CommodityId,
                (Prodect, IndentDetail) => new
                {
                    Id = Prodect.Id,
                    Description = Prodect.Description
                }), "Id", "Description");
            return View(model);
        }

        // POST: Indent/Dispatch/Edit/5
        [HttpPost]
        public ActionResult Edit(IndDomesticDispatchSchedule model)
        {
            try
            {

                ModelState.Remove("TypeOfTransaction");
                ModelState.Remove("DelayShipmentReason");
                ModelState.Remove("SalesContractDetail");
                ModelState.Remove("LocalDispatchNo");
                ModelState.Remove("isFirstDispatch");
                ModelState.Remove("IsReceivedStinv");
                ModelState.Remove("IsComplaint");
                ModelState.Remove("SalestaxInvoiceNo");
                if (ModelState.IsValid)
                {
                    if (model.IsDelayed == "N")
                    {
                        model.DelayShipmentReason = "_";
                        model.DelayShipmentReasonDescription = "_";
                    }

                    var domesticIndent = _indDomestic.FindById(model.IndentId);
                    model.Balance = model.Quantity * (domesticIndent.IndDomesticDetails
                                        .Where(a => a.IndentId == model.IndentId && a.CommodityId == model.CommodityId)
                                        .FirstOrDefault().Rate);

                    model.CreatedOn = DateTime.Now;
                    model.ModifiedOn = DateTime.Now;
                    model.SalestaxInvoiceDate = DateTime.Now;
                    model.LocalDispatchNo = "--";
                    model.IsReceivedStinv = "-";
                    //model.TypeOfTransaction = "1";
                    model.SalesContractDetail = "1";
                    model.SalestaxInvoiceNo = "1";
                    model.IsComplaint = "N";
                    model.isFirstDispatch = "1";
                    _indDomesticDispatchScheduleRepository.Edit(model);
                    return null;
                }
                else
                {
                    var indent = _indDomestic.FindById(model.IndentId);
                    ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                        Prodect => Prodect.Id,
                        IndentDetail => IndentDetail.CommodityId,
                        (Prodect, IndentDetail) => new
                        {
                            Id = Prodect.Id,
                            Description = Prodect.Description
                        }), "Id", "Description");
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Indent/Dispatch/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                IndDomesticDispatchSchedule model = new IndDomesticDispatchSchedule();
                model.Id = id;
                _indDomesticDispatchScheduleRepository.Remove(model);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }

        // POST: Indent/Dispatch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }


        public ActionResult GetDispatches(int id)
        {
            var dispatch = _indDomestic.FindById(id);

            var Dispatches = _indDomesticDispatchScheduleRepository.GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && (a.TypeOfTransaction == "D" || a.TypeOfTransaction == "R")).ToList();
            var collection = Dispatches.Select(x => new
            {
                Id = x.Id,
                Date = x.TransDate.ToString("yyyy-MM-dd"),
                Commodity = x.Product.Description,
                Quantity = x.Quantity,
                Balance = x.Balance,
                Name = x.GoodsForwarder.Name,
                IsDelayed = x.IsDelayed,
                Type = Enum.GetName(typeof(ERP.Common.DispatchType), Convert.ToChar(x.TypeOfTransaction)),
                Remarks = x.Remarks
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPayments(int id)
        {
            var dispatch = _indDomestic.FindById(id);

            var Dispatches = _indDomesticDispatchScheduleRepository.GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && a.TypeOfTransaction == "P").ToList();
            var collection = Dispatches.Select(x => new
            {
                Id = x.Id,
                Date = x.TransDate.ToString("yyyy-MM-dd"),
                Quantity = x.Quantity,
                Received = x.ReceivableAfterTaxes,
                Remarks = x.Remarks
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        private List<EFilingSystem> GetEFiles(EFilingSystem model)
        {
            List<EFilingSystem> lstEfile = new List<EFilingSystem>();
            EFilingSystem _efile;
            var EFilingSystem = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("DocumentType"))
                    EFilingSystem.Add(k.ToString());
            }
            try
            {
                foreach (var Key in EFilingSystem)
                {
                    var index = "0";
                    index = Key.Replace("][DocumentType]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][DocumentType]"))
                    {
                        _efile = new EFilingSystem();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][DocumentType]"]))
                        {
                            _efile.DocumentType = (Request.Form["det[" + index + "][DocumentType]"]);
                            _efile.FileDescription = (Request.Form["det[" + index + "][FileDescription]"]);
                            _efile.ReferenceID2 = model.ReferenceID2;
                            _efile.EFilingID = (Request.Form["det[" + index + "][EFilingID]"]);
                            _efile.FileAttached = (Request.Form["det[" + index + "][FileAttached]"]);

                            if (String.IsNullOrEmpty(_efile.FileDescription))
                                _efile.FileDescription = _efile.DocumentType;
                            _efile.TranType = 4;
                            _efile.CompanyId = model.CompanyId;
                            _efile.Company_Key = model.Company_Key;
                            _efile.ReferenceID1 = model.ReferenceID1;
                            _efile.CreatedBy = LoggedinUser.LoggedInUser.Id;
                            _efile.CreatedOn = DateTime.Now;
                            _efile.ModifiedBy = LoggedinUser.LoggedInUser.Id;
                            _efile.ModifiedOn = DateTime.Now;
                            lstEfile.Add(_efile);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return lstEfile;
        }
    }
}
