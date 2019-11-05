using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Finance;
using ERP.Infrastructure.Repositories.FinRepository;
using ERP.Infrastructure.Repositories.HR;
using ERP.Infrastructure.Repositories.Party;
using ERP.Infrastructure.Repositories.Common;
using ERP.Infrastructure.Repositories.Parties;


namespace VIGOR.Areas.GL.Controllers
{
    public class fnGeneralLedgerController : Controller
    {
        private FinVoucherRepository voucher;
        private FinVoucher model;
        private CoaL5Repository coaL5Repository;
        private FinVTypeRepository vTypeRepository;
        private HrEmployeeRepository hrEmployeeRepository;
        private FinPartyRepository finPartyRepository;
        private CityRepository cityRepository;
        private HrDepartmentRepository hrDepartmentRepository;
        public fnGeneralLedgerController()
        {
            voucher = new FinVoucherRepository();
            model = new FinVoucher();
            vTypeRepository = new FinVTypeRepository();
            coaL5Repository = new CoaL5Repository();
            hrEmployeeRepository = new HrEmployeeRepository();
            finPartyRepository = new FinPartyRepository();
            cityRepository = new CityRepository();
            hrDepartmentRepository = new HrDepartmentRepository();

        }

        public ActionResult VoucherPrint(string vKey)
        {
            model = voucher.GetFinVoucherByKey(vKey);
            ViewBag.FinVoucher = vTypeRepository.FindByVType(model.Vtype);
            return PartialView("_VoucherPrint",model);
        }


        public ActionResult GeneralLedgerReport() { return View(); }
        public ActionResult GeneralLedgerCriteria(DateTime? frDateTime, DateTime? toDateTime, string glCode, Int32? deptId, Int32? locId, Int32? empId, Int32? custId)
        {
            List<FinLedger> ledger = new List<FinLedger>();
            List<FinLedger> listOpeningBalance = new List<FinLedger>();
            string[] values = glCode.Split(',');
            for (int i = 0; i < values.Length; i++)
            {

                if (!String.IsNullOrEmpty(values[i].Trim()))
                {
                    var lst = voucher.GetAllFinLedger().Where(a =>
                         a.GlCode.Equals(values[i]) && a.CreateDate >= frDateTime && a.CreateDate <= toDateTime &&
                         (deptId > 0 ? (a.DeptId == deptId) : (1 == 1)) &&
                         (locId > 0 ? (a.LocId == locId) : (1 == 1)) &&
                         (empId > 0 ? (a.EmpId == empId) : (1 == 1)) &&
                         (custId > 0 ? (a.CustomerId == custId) : (1 == 1))).ToList();
                var openingbal=    voucher.GetAllFinLedger().Where(model => model.CreateDate < frDateTime && model.GlCode.Equals(values[i]) &&
                                                             (deptId > 0 ? (model.DeptId == deptId) : (1 == 1)) &&
                                                             (locId > 0 ? (model.LocId == locId) : (1 == 1)) &&
                                                             (empId > 0 ? (model.EmpId == empId) : (1 == 1)) &&
                                                             (custId > 0 ? (model.CustomerId == custId) : (1 == 1))).Sum(a => a.Debit - a.Credit);
                    FinLedger obj= new FinLedger();
                    obj.GlCode = values[i].Trim();
                    obj.Debit = openingbal;
                    listOpeningBalance.Add(obj);
                    if (lst.Count > 0){foreach (var item in lst){ledger.Add(item);} }
                }
            }
            ViewBag.openingBalance = listOpeningBalance;
            
            string criteria = string.Empty;
            criteria = " For the Period : " + frDateTime.Value.ToString("dd/MM/yyyy") + "  To : " +
                       toDateTime.Value.ToString("dd/MM/yyyy") + " <br />"+// + "Account : " + glCode + " - " + coaL5Repository.FindById(glCode).Title + "<br />" +
                (deptId > 0 ? (" Department : ") + hrDepartmentRepository.FindById((int)deptId).Title : "") +
                  (locId > 0 ? (" Location : ") + cityRepository.FindById((int)locId).Name : "") +
                  (empId > 0 ? (" Employee : ") + hrEmployeeRepository.FindById((int)empId).Title : "") +
                  (custId > 0 ? (" Customer : ") + finPartyRepository.FindById((int)custId).Title : "");

            ViewBag.Criteria = criteria;



            return PartialView("~/Areas/GL/Views/fnGeneralLedger/_gernalLedger.cshtml", ledger);
        }
    }
}
