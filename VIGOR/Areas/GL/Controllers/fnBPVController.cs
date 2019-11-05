using ERP.Core.Models.Finance;
using ERP.Infrastructure.Repositories.FinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Common;
using ERP.Core.Models.Admin;


namespace VIGOR.Areas.GL.Controllers
{
    public class fnBPVController : Controller
    {
        FinVoucherRepository voucherRepo;
        CoaL5Repository coaL5Repository;
        private FinFescalYearDetailRepository finFescalYearDetailRepository;

        decimal debit = 0;
        decimal credit = 0;
        public fnBPVController()
        {
            voucherRepo = new FinVoucherRepository();
            coaL5Repository = new CoaL5Repository();
            finFescalYearDetailRepository = new FinFescalYearDetailRepository();
        }
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
                    a = voucherRepo.getVoucherWithAccount(dateFrom, dateTo, GlCode).Where(vt => vt.Vtype.Equals(vType)).ToList(); //voucherRepo.GetAllFinVouchers(vType).ToList();
                if (!string.IsNullOrEmpty(GlCode) && !string.IsNullOrEmpty(Detail))
                    a = voucherRepo.getVoucherWithAccountAndDetail(dateFrom, dateTo, GlCode, Detail).Where(vt => vt.Vtype.Equals(vType)).ToList();
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
                    IsPosted = x.isPosted.Equals(true) ? "Posted" : "Un-Posted",
                    ViewURL = "/GL/fnBPV/BPVView?vKey=" + x.VKey

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

        public ActionResult BPVView(string VKey)
        {
            FinVoucher model = new FinVoucher();
            model = voucherRepo.GetFinVoucherByKey(VKey);
            model.AccountCode = model.FinVoucherDetail.Where(a => a.Credit > 0).FirstOrDefault().GlCode;
            model.CheqNo = model.FinVoucherDetail.Where(a => a.Credit > 0).FirstOrDefault().ChequeNo;
            model.dtDetail = model.FinVoucherDetail.Where(a => a.Credit > 0).FirstOrDefault().Detail;
            return View(model);
        }

        // GET: GL/fnBPV/Create
        public ActionResult Create()
        {
            FinVoucher model = new FinVoucher();
            model.VoucherDate = DateTime.Now;
            model.FescalMonth = Convert.ToString(finFescalYearDetailRepository.GetAllFescalYearDetails().Where(a => a.StartDate.Date <= System.DateTime.Now.Date && a.EndDate.Date >= System.DateTime.Now.Date).FirstOrDefault().Id);

            return View(model);
        }

        // POST: GL/fnBPV/Create
        [HttpPost]
        public ActionResult Create(FinVoucher model, FormCollection collection)
        {

            List<FinVoucherDetail> lst = new List<FinVoucherDetail>();
            try
            {
                lst = GetLedgerDetail(model);
                if (ModelState.IsValid)
                {


                    if (debit > 0 && credit > 0 && debit == credit)
                    {
                        model.Vtype = "003";
                        model.PostedDate = System.DateTime.Now;
                        model.CreateUserId = 1;
                        model.CreateDate = System.DateTime.Now;
                        model.ModifiedOn = System.DateTime.Now;
                        model.IsEdited = true;
                        model.TotalDebit = debit;
                        model.TotalCredit = credit;
                        voucherRepo.Add(model, lst);
                        TempData["clientMessage"] = "Your Voucher has successfully Saved";
                    }
                    else
                    {
                        TempData["clientMessage"] = "Please Enter valid Debit and Credit Amount";
                        List<FinVoucherDetail> lst1 = new List<FinVoucherDetail>();
                        lst = new List<FinVoucherDetail>();
                        lst = GetLedgerDetail(model);

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
                lst = GetLedgerDetail(model);

                foreach (var dt in lst)
                {
                    dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                    lst1.Add(dt);

                }
                model.FinVoucherDetail = lst1;
                return View(model);
            }
        }

        // GET: GL/fnBPV/Edit/5
        public ActionResult Edit(string VKey)
        {
            FinVoucher model = new FinVoucher();
            model = voucherRepo.GetFinVoucherByKey(VKey);
            model.AccountCode = model.FinVoucherDetail.Where(a => a.Credit > 0).FirstOrDefault().GlCode;
            model.CheqNo = model.FinVoucherDetail.Where(a => a.Credit > 0).FirstOrDefault().ChequeNo;
            model.dtDetail = model.FinVoucherDetail.Where(a => a.Credit > 0).FirstOrDefault().Detail;
            return View(model);
        }

        // POST: GL/fnBPV/Edit/5
        [HttpPost]
        public ActionResult Edit(FinVoucher model, FormCollection collection)
        {
            List<FinVoucherDetail> lst = new List<FinVoucherDetail>();
            try
            {
                lst = GetLedgerDetail(model);
                if (ModelState.IsValid)
                {
                    if (debit > 0 && credit > 0 && debit == credit)
                    {
                        model.Vtype = "003";
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
                        lst = GetLedgerDetail(model);

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
                lst = GetLedgerDetail(model);

                foreach (var dt in lst)
                {
                    dt.CoaL5 = coaL5Repository.FindById(dt.GlCode);
                    lst1.Add(dt);

                }
                model.FinVoucherDetail = lst1;
                return View(model);
            }
        }

        // GET: GL/fnBPV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/fnBPV/Delete/5
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

        private List<FinVoucherDetail> GetLedgerDetail(FinVoucher model)

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
                        { _detailObj.Detail = (Request.Form["det[" + index + "][Detail]"].Trim()); }

                        _detailObj.GlCode = (Request.Form["det[" + index + "][GlCode]"]);
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Debit]"]))
                        {
                            _detailObj.Debit = Convert.ToDecimal(Request.Form["det[" + index + "][Debit]"].Trim());
                            debit = debit + Convert.ToDecimal(_detailObj.Debit);
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
                        if (_detailObj.Debit > 0)
                            lstFinVoucherDetail.Add(_detailObj);

                    }

                }
            }
            _detailObj = new FinVoucherDetail();
            _detailObj.Detail = model.dtDetail;
            _detailObj.GlCode = model.AccountCode;
            _detailObj.Credit = debit;
            _detailObj.DeptId = 1;
            _detailObj.LocId = 2;
            _detailObj.EmpId = 1;
            _detailObj.CustomerId = 5;
            credit = debit;
            _detailObj.ChequeDate = DateTime.Now;
            _detailObj.ClearingDate = DateTime.Now;
            lstFinVoucherDetail.Add(_detailObj);
            return lstFinVoucherDetail;
        }


    }
}
