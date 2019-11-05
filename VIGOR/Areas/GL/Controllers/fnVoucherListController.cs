using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Common;
using ERP.Core.Models.Finance;
using ERP.Infrastructure.Repositories.FinRepository;
using Microsoft.Ajax.Utilities;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnVoucherListController : Controller
    {
        private FinVoucherRepository voucher;
        private FinVTypeRepository vType;
        public fnVoucherListController()
        {
            voucher = new FinVoucherRepository();
            vType = new FinVTypeRepository();
        }
        // GET: GL/VoucherList
        public ActionResult Index()
        {


            return View();
        }

        // GET: GL/VoucherList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GL/VoucherList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GL/VoucherList/Create
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

        // GET: GL/VoucherList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GL/VoucherList/Edit/5
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

        // GET: GL/VoucherList/Delete/5
        public ActionResult Delete(string vKey, string Url)
        {
            if (!string.IsNullOrEmpty(vKey))
            {
                voucher.Remove(vKey);
            }
            return Redirect(Url);
        }

        // POST: GL/VoucherList/Delete/5
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


        [HttpGet]
        public ActionResult GetVouchers(string type, string status)
        {
            var Vouchers = voucher.GetAllFinVouchers().Where(a => a.Vtype.Equals(type.Trim()) && a.IsPosted.Equals(status == "0" ? false : true)); //&& a.IsPosted.Equals(status == "0" ? false : true)
            var collection = Vouchers.Select(x => new
            {
                VoucherNo = x.VoucherNo,
                VKey = x.VKey,
                VoucherDate = x.VoucherDate.ToString("dd-MM-yyyy"),
                TotalDebit = x.TotalDebit,
                TotalCredit = x.TotalCredit,
                Detail = x.Detail,
                Vtype = vType.FindByVType(x.Vtype).Vtype,
                IsPosted = x.IsPosted == true ? "Posted" : "Un-Post",

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult PostVoucher(List<string> SelectedVoucher, string authKey)
        {
            string message = string.Empty;
            try
            {
                if (SecurityConstants.SecVoucherKey.Equals(authKey))
                {
                    if (SelectedVoucher.Count > 0)
                    {
                        FinVoucher vouchermodel;
                        foreach (var obj in SelectedVoucher)
                        {
                            vouchermodel = new FinVoucher();
                            vouchermodel = voucher.GetFinVoucherByKey(obj.Trim());
                            vouchermodel.IsPosted = true;
                            vouchermodel.IsEdited = false;
                            vouchermodel.PostedDate = DateTime.Now;
                            vouchermodel.PostedUserId = 1;
                            vouchermodel.dtDetail = "_dtdetail";
                            vouchermodel.AccountCode = "0";
                            voucher.PostorUnpost(vouchermodel);
                        }
                        message = SelectedVoucher.Count + " is successfully Posted";
                        return Json(message, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    message = "Authentication Security Key is InValid";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UnPostVoucher(List<string> SelectedVoucher, string authKey)
        {

            string message = string.Empty;
            try
            {
                if (SecurityConstants.SecVoucherKey.Equals(authKey))
                {
                    if (SelectedVoucher.Count > 0)
                    {
                        FinVoucher vouchermodel;
                        foreach (var obj in SelectedVoucher)
                        {
                            vouchermodel = new FinVoucher();
                            vouchermodel = voucher.GetFinVoucherByKey(obj);
                            vouchermodel.IsPosted = false;
                            vouchermodel.IsEdited = true;
                            vouchermodel.dtDetail = "_dtdetail";
                            vouchermodel.AccountCode = "0";
                            voucher.PostorUnpost(vouchermodel);
                        }
                        message = SelectedVoucher.Count + " is successfully Un Posted";
                        return Json(message, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    message = "Authentication Security Key is InValid";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { }
            return Json(message, JsonRequestBehavior.AllowGet);

        }
    }
}
