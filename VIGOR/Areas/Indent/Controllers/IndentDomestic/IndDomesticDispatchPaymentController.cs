using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Core.Models.Admin;
using System.Net;

namespace VIGOR.Areas.Indent.Controllers.IndentDomestic
{
    public class IndDomesticDispatchPaymentController : Controller
    {
        private ProductRepository ProductRepository;
        private IndDomesticRepository _indDomestic;
        private IndDomesticPaymentAddOn _indDomesticPaymentAddOn;
        IndDomesticDispatchScheduleRepository _indDomesticDispatchScheduleRepository;
        IndDomesticPaymentAddOnRepository _indDomesticPaymentAddOnRepository;
        public IndDomesticDispatchPaymentController()
        {
            ProductRepository = new ProductRepository();
            _indDomesticDispatchScheduleRepository = new IndDomesticDispatchScheduleRepository();
            _indDomestic = new IndDomesticRepository();
            _indDomesticPaymentAddOn = new IndDomesticPaymentAddOn();
            _indDomesticPaymentAddOnRepository = new IndDomesticPaymentAddOnRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Indent/IndDomesticDispatchPayment/Create
        public ActionResult Create(int id)
        {
            var indent = _indDomestic.FindById(id);
            ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                Prodect => Prodect.Id,
                IndentDetail => IndentDetail.CommodityId,
                (Prodect, IndentDetail) => new
                {
                    Id = Prodect.Id,
                    Description = Prodect.Description
                }), "Id", "Description");

            IndDomesticDispatchSchedule model = new IndDomesticDispatchSchedule();
            model.Id = 0;
            model.TransDate = DateTime.Now;
            model.TypeOfTransaction = "P";
            model.IndentId = id;

            ViewBag.CommodityType = indent.CommodityTypeId;
            if (indent.CommodityTypeId > 1)
            {
                var IndDomAddOnTemplates = _indDomesticPaymentAddOnRepository.GetAllIndIndDomesticAddOnTemplates();
                ViewBag.IndDomesticPaymentsAddOnLists = IndDomAddOnTemplates;
            }
            ViewBag.IndentKey = indent.IndentKey;
            return View(model);
        }
        // POST: Indent/IndDomesticDispatchPayment/Create
        [HttpPost]
        public ActionResult Create(IndDomesticDispatchSchedule model, string IndentKey)
        {
            int SrNo = _indDomesticDispatchScheduleRepository.GetSrNo(model.IndentId);
            try
            {
                #region RemoveValidations
                ModelState.Remove("DelayShipmentReason");
                ModelState.Remove("SalesContractDetail");
                ModelState.Remove("LocalDispatchNo");
                ModelState.Remove("isFirstDispatch");
                ModelState.Remove("IsReceivedStinv");
                ModelState.Remove("IsComplaint");
                ModelState.Remove("SalestaxInvoiceNo");
                ModelState.Remove("VehicleNo");
                ModelState.Remove("BiltyNo");
                ModelState.Remove("IsDelayed");
                ModelState.Remove("DelayShipmentReasonDescription");
                #endregion

                int CommodityType = Convert.ToInt16(Request.Form["CommodityType"]);
                ViewBag.CommodityType = CommodityType;
                if (ModelState.IsValid)
                {
                    model.IsDelayed = "N";
                    if (model.IsDelayed == "N")
                    {
                        model.DelayShipmentReason = "_";
                        model.DelayShipmentReasonDescription = "_";
                    }
                    var domesticIndent = _indDomestic.FindById(model.IndentId);
                    model.Balance = model.Quantity * (domesticIndent.IndDomesticDetails
                                        .Where(a => a.IndentId == model.IndentId && a.CommodityId == model.CommodityId)
                                        .FirstOrDefault().Rate);

                    model.CompanyId = LoggedinUser.Company.Id;
                    model.LocalDispatchNo = SrNo.ToString().PadLeft(3, '0') + IndentKey;
                    model.srno = SrNo;
                    model.SalesContractDetail = model.LocalDispatchNo;
                    model.CreatedOn = DateTime.Now;
                    model.ModifiedOn = DateTime.Now;
                    model.SalestaxInvoiceDate = DateTime.Now;
                    model.ContractedDeliveryDate = DateTime.Now;
                    model.TransDate = DateTime.Now;
                    model.IsReceivedStinv = false;
                    model.SalestaxInvoiceNo = "1";
                    model.IsComplaint = "N";
                    model.isFirstDispatch = "1";
                    model.VehicleNo = "00";
                    model.BiltyNo = "00";
                    model.GoodsFarwarderID = 1;


                    var addOn = new List<IndDomesticPaymentAddOn>();
                    if (CommodityType > 1)
                    {
                        addOn = GetAddOnYarn(model);
                    }
                    else
                    {
                        addOn = GetAddOn(model);
                    }
                    for (int i = 0; i < addOn.Count; i++)
                    {
                        try
                        {
                            _indDomesticPaymentAddOnRepository.Add(addOn[i]);
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    _indDomesticDispatchScheduleRepository.Add(model);
                    return null;
                }
                else
                {
                    var indent = _indDomestic.FindById(model.IndentId);
                    ViewBag.IndentKey = indent.IndentKey;
                    ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                        Prodect => Prodect.Id,
                        IndentDetail => IndentDetail.CommodityId,
                        (Prodect, IndentDetail) => new
                        {
                            Id = Prodect.Id,
                            Description = Prodect.Description
                        }), "Id", "Description");
                    if (indent.CommodityTypeId > 1)
                    {
                        var IndDomAddOnTemplates = _indDomesticPaymentAddOnRepository.GetAllIndIndDomesticAddOnTemplates();
                        ViewBag.IndDomesticPaymentsAddOnLists = IndDomAddOnTemplates;
                    }
                    return View(model);
                }
            }
            catch (Exception e)
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
                ViewBag.IndentKey = indent.IndentKey;
                if (indent.CommodityTypeId > 1)
                {
                    var IndDomAddOnTemplates = _indDomesticPaymentAddOnRepository.GetAllIndIndDomesticAddOnTemplates();
                    ViewBag.IndDomesticPaymentsAddOnLists = IndDomAddOnTemplates;
                }
                return View(model);
            }
        }
        public List<IndDomesticPaymentAddOn> GetAddOn(IndDomesticDispatchSchedule model)
        {
            List<IndDomesticPaymentAddOn> addOnList = new List<IndDomesticPaymentAddOn>();
            IndDomesticPaymentAddOn _indDomesticPaymentAddOn;
            var paymentAddOnList = new List<string>();

            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("AddOnTemplate"))
                    paymentAddOnList.Add(k.ToString());

            }
            try
            {
                foreach (var Key in paymentAddOnList)
                {
                    var index = "0";
                    index = Key.Replace("][AddOnTemplate]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][AddOnTemplate]"))
                    {
                        _indDomesticPaymentAddOn = new IndDomesticPaymentAddOn();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][AddOnTemplate]"]))
                        {

                            _indDomesticPaymentAddOn.AddOnType = Request.Form["det[" + index + "][AddOnTemplate]"];
                            _indDomesticPaymentAddOn.Amount = Convert.ToInt32(Request.Form["det[" + index + "][AddOnAmmount]"]);
                            _indDomesticPaymentAddOn.LocalDispatchKey = model.LocalDispatchNo;
                            _indDomesticPaymentAddOn.ProductId = model.CommodityId;
                            _indDomesticPaymentAddOn.LocalDispatchNo = model.IndentId;
                            _indDomesticPaymentAddOn.AddOnEffect = "-";
                            _indDomesticPaymentAddOn.DomesticPaymentAddonCalculatedOn = "01";
                            _indDomesticPaymentAddOn.Quantity = model.Quantity;
                            _indDomesticPaymentAddOn.NetReceviable = model.NetReceviable;
                            _indDomesticPaymentAddOn.TaxPercent = model.IncomeTaxPercent;
                            _indDomesticPaymentAddOn.TaxAmount = model.NetReceviable * model.IncomeTaxPercent / 100;
                            _indDomesticPaymentAddOn.TransactionNo = model.LocalDispatchNo;
                            try
                            {
                                addOnList.Add(_indDomesticPaymentAddOn);
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
            return addOnList;

        }
        public List<IndDomesticPaymentAddOn> GetAddOnYarn(IndDomesticDispatchSchedule model)
        {
            List<IndDomesticPaymentAddOn> addOnList = new List<IndDomesticPaymentAddOn>();
            IndDomesticPaymentAddOn _indDomesticPaymentAddOn;
            var paymentAddOnList = new List<string>();

            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("AddOnId"))
                    paymentAddOnList.Add(k.ToString());

            }
            try
            {
                int serialNo = 0;
                foreach (var Key in paymentAddOnList)
                {
                    var index = "0";
                    index = Key.Replace("][AddOnId]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][AddOnId]"))
                    {
                        _indDomesticPaymentAddOn = new IndDomesticPaymentAddOn();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][AddOnId]"]))
                        {

                            _indDomesticPaymentAddOn.AddOnType = Request.Form["det[" + index + "][AddOnId]"];
                            _indDomesticPaymentAddOn.Amount = Convert.ToDecimal(Request.Form["det[" + index + "][AddOnAmmount]"]);
                            _indDomesticPaymentAddOn.AddOnEffect = Request.Form["det[" + index + "][AddOnEffect]"];
                            _indDomesticPaymentAddOn.LocalDispatchKey = model.LocalDispatchNo;
                            _indDomesticPaymentAddOn.ProductId = model.CommodityId;
                            _indDomesticPaymentAddOn.LocalDispatchNo = model.IndentId;
                            _indDomesticPaymentAddOn.DomesticPaymentAddonCalculatedOn = "-";
                            _indDomesticPaymentAddOn.Quantity = model.Quantity;
                            _indDomesticPaymentAddOn.NetReceviable = model.NetReceviable;
                            _indDomesticPaymentAddOn.TaxPercent = model.IncomeTaxPercent;
                            _indDomesticPaymentAddOn.TaxAmount = model.NetReceviable * model.IncomeTaxPercent / 100;
                            _indDomesticPaymentAddOn.TransactionNo = model.LocalDispatchNo;
                            _indDomesticPaymentAddOn.SerialNumber = ++serialNo;
                            _indDomesticPaymentAddOn.domPaymentAddOnListId = Convert.ToInt32(Request.Form["det[" + index + "][AddOnId]"]);
                            try
                            {
                                addOnList.Add(_indDomesticPaymentAddOn);
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
            return addOnList;

        }
        // GET: Indent/IndDomesticDispatchPayment/Edit/5
        public ActionResult Edit(int id)
        {
            IndDomesticDispatchSchedule model = _indDomesticDispatchScheduleRepository.FindById(id);
            var indent = _indDomestic.FindById(model.IndentId);
            //if (indent.CommodityTypeId > 1)
            //    ViewBag.IndDomesticPaymentsAddOnLists=_indDomesticPaymentAddOnRepository.GetAllIndIndDomesticPaymentsAddOnLists().Where(a=>a.)

            ViewBag.CommodityId = new SelectList(ProductRepository.GetAllProduct().Join(indent.IndDomesticDetails,
                Prodect => Prodect.Id,
                IndentDetail => IndentDetail.CommodityId,
                (Prodect, IndentDetail) => new
                {
                    Id = Prodect.Id,
                    Description = Prodect.Description
                }), "Id", "Description");

            ViewBag.CommodityType = indent.CommodityTypeId;
            ViewBag.IndentKey = indent.IndentKey;
            if (indent.CommodityTypeId > 1)
            {
                var indDomesticPaymentAddOnsList = _indDomesticPaymentAddOnRepository.GetAllIndDomesticPaymentAddOns().Where(a => a.TransactionNo == model.LocalDispatchNo).ToList();
                var indDomAddOnTemplates = _indDomesticPaymentAddOnRepository.GetAllIndIndDomesticAddOnTemplates().ToList();

                foreach (var templates in indDomAddOnTemplates)
                {
                    foreach (var addOn in indDomesticPaymentAddOnsList)
                    {
                        templates.AddOnEffect = addOn.AddOnEffect;
                        templates.AddOnId = Convert.ToInt32(addOn.AddOnType);
                        templates.Amount = addOn.Amount;
                        templates.AddOnType = addOn.AddOnType == "1" ? "P" : "F";
                        indDomesticPaymentAddOnsList.Remove(addOn);
                        break;
                    }
                }
                ViewBag.IndDomesticPaymentsAddOnLists = indDomAddOnTemplates;
            }

            return View(model);
        }

        // POST: Indent/IndDomesticDispatchPayment/Edit/5
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

        // GET: Indent/IndDomesticDispatchPayment/Delete/5
        public ActionResult Delete(int id)
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

        // POST: Indent/IndDomesticDispatchPayment/Delete/5
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
