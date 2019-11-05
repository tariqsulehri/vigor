using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ERP.Common;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Finance;
using ERP.Infrastructure.Repositories.FinRepository;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnJVController : Controller
    {
        FinVoucherRepository voucherRepo;
        CoaL5Repository coaL5Repository;
        private FinFescalYearDetailRepository finFescalYearDetailRepository;
        decimal debit = 0;
        decimal credit = 0;
        public fnJVController()
        {
            voucherRepo = new FinVoucherRepository();
            coaL5Repository = new CoaL5Repository();
            finFescalYearDetailRepository = new FinFescalYearDetailRepository();
        }
        // GET: GL/JV
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }

        public ActionResult GetList(String vType, DateTime dateFrom, DateTime dateTo, string GlCode, string Detail)
        {

            if (IsValidate.IsvalidateYear(dateFrom, dateTo))
            {
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                var a = new List<ERP.Core.Models.Finance.GeneralVM.VM_Vouchers>();
                if (!string.IsNullOrEmpty(GlCode) && string.IsNullOrEmpty(Detail))
                    a = voucherRepo.getVoucherWithAccount(dateFrom, dateTo, GlCode).Where(vt => vt.Vtype.Equals(vType))
                        .ToList(); //voucherRepo.GetAllFinVouchers(vType).ToList();
                if (!string.IsNullOrEmpty(GlCode) && !string.IsNullOrEmpty(Detail))
                    a = voucherRepo.getVoucherWithAccountAndDetail(dateFrom, dateTo, GlCode, Detail)
                        .Where(vt => vt.Vtype.Equals(vType)).ToList();
                int totalrows = a.Count();
                int totalrowsafterfiltering = a.Count();
                a = a.Skip(start).Take(length).ToList();
                var Collection = a.Select(x => new
                {
                    VKey = x.VKey,
                    VoucherDate = x.VoucherDate.ToString("yyyy-MM-dd"),
                    TotalDebit = x.TotalDebit,
                    TotalCredit = x.TotalCredit,
                    Detail = x.Detail,
                    IsPosted = x.isPosted,
                    ViewURL = "/GL/fnJV/JvView?vKey=" + x.VKey

                });
                return Json(new
                {
                    data = Collection,
                    draw = Request["draw"],
                    recordsTotal = totalrows,
                    recordsFiltered = totalrowsafterfiltering
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json("Not Valid", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult JvView(string VKey)

        { return View(voucherRepo.GetFinVoucherByKey(VKey)); }

        // GET: GL/JV/Create
        public ActionResult Create()
        {
            FinVoucher model = new FinVoucher();
            model.VoucherDate = DateTime.Now;
            model.FescalMonth=Convert.ToString( finFescalYearDetailRepository.GetAllFescalYearDetails().Where(a => a.StartDate.Date <= System.DateTime.Now.Date && a.EndDate.Date >= System.DateTime.Now.Date).ToList().FirstOrDefault().Id);
            return View(model);
        }

        // POST: GL/JV/Create
        [HttpPost]
        public ActionResult Create(FinVoucher model, FormCollection collection)
        {

            List<FinVoucherDetail> lst = new List<FinVoucherDetail>();
            try
            {
                lst = GetLedgerDetail();
                if (ModelState.IsValid)
                {
                    if (debit > 0 && credit > 0 && debit == credit)
                    {
                        model.Vtype = "001";
                        model.PostedDate = System.DateTime.Now;
                        model.CreateUserId = 1;
                        model.CreateDate = System.DateTime.Now;
                        model.ModifiedOn = System.DateTime.Now;
                        model.TotalDebit = debit;
                        model.TotalCredit = credit;
                        model.IsEdited = true;
                        voucherRepo.Add(model, lst);
                        TempData["clientMessage"] = "Your Voucher has successfully Saved";
                    }
                    else
                    {
                        TempData["clientMessage"] = "Please Enter valid Debit and Credit Amount";
                        List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                        lst = new List<FinVoucherDetail>();
                        lst = GetLedgerDetail();

                        foreach (var dt in lst)
                        {
                            dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                            lst1.Add(dt);

                        }
                        model.FinVoucherDetail = lst1;
                        return View(model);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                    foreach (var dt in lst)
                    {
                        dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                        lst1.Add(dt);

                    }
                    model.FinVoucherDetail = lst1;
                    return View(model);
                }
            }
            catch
            {
                TempData["clientMessage"] = "Please Enter valid Voucher Detail";
                List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                lst = new List<FinVoucherDetail>();
                lst = GetLedgerDetail();

                foreach (var dt in lst)
                {
                    dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                    lst1.Add(dt);

                }
                model.FinVoucherDetail = lst1;
                return View(model);
            }
        }

        // GET: GL/JV/Edit/5
        public ActionResult Edit(string VKey)
        { return View(voucherRepo.GetFinVoucherByKey(VKey)); }
        // POST: GL/JV/Edit/5
        [HttpPost]
        public ActionResult Edit(FinVoucher model, FormCollection collection)
        {
            List<FinVoucherDetail> lst = new List<FinVoucherDetail>();
            try
            {
                lst = GetLedgerDetail();
                if (ModelState.IsValid)
                {
                    if (debit > 0 && credit > 0 && debit == credit)
                    {
                        model.Vtype = "001";
                        model.PostedDate = System.DateTime.Now;
                        model.IsEdited = true;
                        model.ModifiedOn = System.DateTime.Now;
                        model.TotalDebit = debit;
                        model.TotalCredit = credit;
                        voucherRepo.Edit(model, model.VKey, lst);
                        TempData["clientMessage"] = "Your Voucher has successfully Update";
                    }
                    else
                    {
                        TempData["clientMessage"] = "Please Enter valid Debit and Credit Amount";
                        List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                        lst = new List<FinVoucherDetail>();
                        lst = GetLedgerDetail();

                        foreach (var dt in lst)
                        {
                            dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                            lst1.Add(dt);
                        }
                        model.FinVoucherDetail = lst1;
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                    foreach (var dt in lst)
                    {
                        dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                        lst1.Add(dt);

                    }
                    model.FinVoucherDetail = lst1;
                    return View(model);
                }
            }
            catch
            {
                TempData["clientMessage"] = "Please Enter valid Voucher Detail";
                List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                lst = new List<FinVoucherDetail>();
                lst = GetLedgerDetail();

                foreach (var dt in lst)
                {
                    dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                    lst1.Add(dt);

                }
                model.FinVoucherDetail = lst1;
                return View(model);
            }
        }

        // GET: GL/JV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/JV/Delete/5
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

        public JsonResult PostVoucher(string vKey)
        {
            try
            {
                FinVoucher vouchermodel = new FinVoucher();
                vouchermodel = voucherRepo.GetFinVoucherByKey(vKey);
                vouchermodel.IsPosted = true;
                vouchermodel.IsEdited = false;
                vouchermodel.PostedDate = DateTime.Now;
                vouchermodel.PostedUserId = 1;
                vouchermodel.dtDetail = "_dtdetail";
                vouchermodel.AccountCode = "0";
                voucherRepo.PostorUnpost(vouchermodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult UnPostVoucher(string vKey)
        {
            try
            {
                FinVoucher vouchermodel = new FinVoucher();
                vouchermodel = voucherRepo.GetFinVoucherByKey(vKey);
                vouchermodel.IsPosted = false;
                vouchermodel.IsEdited = true;
                vouchermodel.dtDetail = "_dtdetail";
                vouchermodel.AccountCode = "0";
                voucherRepo.PostorUnpost(vouchermodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }


        }
        private List<FinVoucherDetail> GetLedgerDetail()

        {
            FinVoucherDetail _detailObj;
            List<FinVoucherDetail> lstFinVoucherDetail = new List<FinVoucherDetail>();
            var gridKeysList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("GlCode"))
                    gridKeysList.Add(k.ToString());
            }
            foreach (var Key in gridKeysList)
            {
                var index = "0";
                index = Key.Replace("][GlCode]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][GlCode]"))
                {
                    _detailObj = new FinVoucherDetail();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][GlCode]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Detail]"]))
                        { _detailObj.Detail = (Request.Form["det[" + index + "][Detail]"]); }
                        else { _detailObj.Detail = string.Empty; }

                        _detailObj.GlCode = (Request.Form["det[" + index + "][GlCode]"]);
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Debit]"]))
                        {
                            _detailObj.Debit = Convert.ToDecimal(Request.Form["det[" + index + "][Debit]"].Trim());
                            debit = debit + Convert.ToDecimal(_detailObj.Debit);
                        }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Credit]"]))
                        {
                            _detailObj.Credit = Convert.ToDecimal(Request.Form["det[" + index + "][Credit]"].Trim());
                            credit = credit + Convert.ToDecimal(_detailObj.Credit);
                        }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][DeptId]"]))
                            _detailObj.DeptId = Convert.ToInt32(Request.Form["det[" + index + "][DeptId]"]);
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][LocId]"]))
                            _detailObj.LocId = Convert.ToInt32(Request.Form["det[" + index + "][LocId]"]);
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][EmpId]"]))
                            _detailObj.EmpId = Convert.ToInt32(Request.Form["det[" + index + "][EmpId]"]);
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CustomerId]"]))
                            _detailObj.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][CustomerId]"]);
                        _detailObj.ChequeDate = DateTime.Now;
                        _detailObj.ClearingDate = DateTime.Now;
                        if (_detailObj.Credit > 0 || _detailObj.Debit > 0)
                            lstFinVoucherDetail.Add(_detailObj);

                    }
                }
            }
            return lstFinVoucherDetail;
        }



    }
}
