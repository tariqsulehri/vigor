using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.viewModels;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.Indent.Controllers
{
    public class DomesticCommInvController : Controller
    {
        private IndDomesticRepository _indDomestic;
        private IndCommissionInvoiceRepository _indCommissionInvoiceRepository;
        private CommInvoiceAgentCommRepository _commInvoiceAgentCommRepository;
        private FinPartyRepository _party;

        public DomesticCommInvController()
        {
            _indDomestic = new IndDomesticRepository();
            _indCommissionInvoiceRepository = new IndCommissionInvoiceRepository();
            _commInvoiceAgentCommRepository = new CommInvoiceAgentCommRepository();
            _party = new FinPartyRepository();
        }
        // GET: Indent/DomesticCommInv
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime FromDate, DateTime Todate)
        {
            ViewBag.FromDate = FromDate;
            ViewBag.Todate = Todate;
            
            ViewBag.Commissions = _indCommissionInvoiceRepository.GetAllIndIndCommissionInvoice()
                .Where(a => a.InvoiceDate >= FromDate && a.InvoiceDate <= Todate);

            return View(_indCommissionInvoiceRepository.GetAllIndIndCommissionInvoice()
                .Where(a => a.InvoiceDate >= FromDate && a.InvoiceDate <= Todate));
        }
        public ActionResult GetDetails(Boolean isClosed, int contractNo, DateTime dateFrom, DateTime dateTo)
        {
            IEnumerable<CommInvoice_VM> data = new List<CommInvoice_VM>();

            var indentLocal = _indDomestic.FindById(contractNo);

            if (isClosed)
            {
                data = _indCommissionInvoiceRepository.GetIndetnDispatchesSummaryByIndent(contractNo);
            }
            else
            {
                data = _indCommissionInvoiceRepository.GetIndetnDispatchesSummaryByDate(contractNo, dateFrom, dateTo);
            }
            decimal total = 0;
            foreach (var item in data)
            {
                total += item.Amount;
            }
            ViewBag.total = total;
            ViewBag.CommInvData = data;
            List<IndCommission> lstindCommissions = new List<IndCommission>();
            foreach (var item in indentLocal.IndCommission)
            {
                item.CalculatedCommissionValue = (total * item.CommissionRate) / 100;
                lstindCommissions.Add(item);
            }
            indentLocal.IndCommission = lstindCommissions;
            ViewBag.indentLocal = indentLocal;
            return View();
        }
        public ActionResult LookUpContracts()
        {
            return View();
        }
        public ActionResult LookUp(DateTime FromDate, DateTime ToDate, int? IndentNO, int? DeptID, int? SCNO, string status)//, DateTime ToDate,string IndentNO,int? DeptID,int? SCNO
        {
            bool closed = status == "0" ? true : false;
            var contract = _indDomestic.GetAllIndDomectic()
                .Where(a => a.DepartmentID.Equals(DeptID) || DeptID.Equals(null) || DeptID.Equals(0))
                /*.Where(a => a.IndentKey.Equals(IndentNO) || IndentNO.Equals(null))*/
                .Where(a => a.IndentDate >= FromDate && a.IndentDate <= ToDate).Where(a => a.IndentStatus.Equals(closed));
            var collection = contract.Select(x => new
            {
                Id = x.Id,
                IndentDate = x.IndentDate.ToString("yyyy-MM-dd"),
                IndentKey = x.IndentKey,
                Saller = _party.FindById(x.CustomerIDasSeller).Title,
                CustomerBuyerName = _party.FindById(x.CustomerIDasBuyer).Title

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadData(int id)
        {
            var data = _indDomestic.FindById(id);
            IndCommissionInvoice indCommission = new IndCommissionInvoice();
            if (data != null)
            {
                indCommission.IndentId = data.Id;
                indCommission.IndentDomestic = data;
                indCommission.CommissionInvoiceKey = _indCommissionInvoiceRepository.GetInvoiceKey();
            }
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View(indCommission);
        }
        // GET: Indent/DomesticCommInv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Indent/DomesticCommInv/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Indent/DomesticCommInv/Create
        [HttpPost]
        public ActionResult Create(IndCommissionInvoice commeInvoice)
        {
            try
            {
                var IndentDomestic = _indDomestic.FindById(commeInvoice.IndentId);
                //commeInvoice.IndentDomestic = new IndDomestic();
                //commeInvoice.IndentDomestic = IndentDomestic;
                commeInvoice.CurrencyId = IndentDomestic.CurrencyId;
                commeInvoice.Currency = IndentDomestic.Currency;
                commeInvoice.ExchangeRate = IndentDomestic.ExchangeRate;
                #region IndCommissionInvoice
                commeInvoice.ModifiedBy = 0;
                commeInvoice.CreatedBy = 0;
                commeInvoice.CreatedOn = DateTime.Now;
                commeInvoice.ModifiedOn = DateTime.Now;
                commeInvoice.InvoiceDate = DateTime.Now;
                commeInvoice.PostedOn = DateTime.Now;
                commeInvoice.SuppliorInvoiceDate = DateTime.Now;
                commeInvoice.Signature = "-";
                commeInvoice.SuppliorInvoiceNo = "-";
                commeInvoice.IndentKey = IndentDomestic.IndentKey;
                commeInvoice.CommissionInvoiceKey = _indCommissionInvoiceRepository.GetInvoiceKey();
                #endregion
                #region indCommissionDetail
                IEnumerable<CommInvoice_VM> data = new List<CommInvoice_VM>();
                if (IndentDomestic.isClosed)
                {
                    data = _indCommissionInvoiceRepository.GetIndetnDispatchesSummaryByIndent(IndentDomestic.Id);
                }
                else
                {
                    data = _indCommissionInvoiceRepository.GetIndetnDispatchesSummaryByDate(IndentDomestic.Id, commeInvoice.DispatchIncludeFrom, commeInvoice.DispatchIncludeTo);
                }
                foreach (var item in data)
                {
                    var indDomDet = new IndCommissionInvoiceDetail
                    {
                        CommissionInvoiceKey = commeInvoice.CommissionInvoiceKey,
                        CommissionInvoiceNo = commeInvoice.Id,
                        CompanyId = LoggedinUser.Company.Id.ToString(),
                        Rate = item.Rate,
                        Quantity = item.Quantity,
                        UnitOfSaleId = 1,
                        Total = item.Amount,
                        IndentId = commeInvoice.IndentId,
                        IndentKey = commeInvoice.IndentKey = IndentDomestic.IndentKey
                    };
                    commeInvoice.IndCommissionDetail.Add(indDomDet);
                }
                #endregion
                #region IndCommissionAgentComm
                CommInvoiceAgentComm commInvoiceAgentComm = new CommInvoiceAgentComm();
                commeInvoice.CommInvoiceAgentComm = new List<CommInvoiceAgentComm>();
                commInvoiceAgentComm = GetTablesData(commeInvoice, IndentDomestic);
                commeInvoice.CommInvoiceAgentComm.Add(commInvoiceAgentComm);
                #endregion

                ModelState.Remove("SuppliorInvoiceNo");
                ModelState.Remove("Signature");
                ModelState.Remove("IndentKey");
                ModelState.Remove("CommissionInvoiceKey");
                ModelState.Remove("IndentDomestic");

                if (ModelState.IsValid)
                {
                    try
                    {
                        _indCommissionInvoiceRepository.Add(commeInvoice);

                    }
                    catch (Exception e)
                    {
                    }
                }


                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }
        private CommInvoiceAgentComm GetTablesData(IndCommissionInvoice commeInvoice, IndDomestic IndentDomestic)
        {
            int commissionId = 0;
            foreach (var indCommission in IndentDomestic.IndCommission)
            {
                commissionId = indCommission.Id;
            }
            IndDomestic _indDomestic;
            CommInvoiceAgentComm commInvoiceAgentComm = new CommInvoiceAgentComm();

            var indDomesticList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("CustomerIdCommPaidTo"))
                    indDomesticList.Add(k.ToString());
            }
            try
            {
                _indDomestic = new IndDomestic();
                foreach (var Key in indDomesticList)
                {
                    var index = "0";
                    index = Key.Replace("][CustomerIdCommPaidTo]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][CustomerIdCommPaidTo]"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CustomerIdCommPaidTo]"]))
                        {
                            var commInvoiceAgent = new CommInvoiceAgentComm
                            {
                                CommissionDiscountRemarks = "-",
                                CommissionDiscountValue = 0,
                                CommissionNetValue = Convert.ToDecimal(Request.Form["det[" + index + "][NetCalculatedCommissionValue]"]),
                                CommissionRate = Convert.ToDecimal(Request.Form["det[" + index + "][CommissionRate]"]),
                                CommissionType = Request.Form["det[" + index + "][CommissionType]"],
                                CommissionValue = Convert.ToDecimal(Request.Form["det[" + index + "][CalculatedCommissionValue]"]),
                                CommPaidTo = Convert.ToInt32(Request.Form["det[" + index + "][CustomerIdCommPaidTo]"]),
                                CommPaidFrom = Convert.ToInt32(Request.Form["det[" + index + "][CustomerIdCommPaidFrom]"]),
                                CompanyId = LoggedinUser.Company.Id,
                                IndentId = commeInvoice.IndentId,
                                IndentKey = IndentDomestic.IndentKey,
                                isLocalCurrency = true,
                                ModifiedBy = 0,
                                ModifiedOn = DateTime.Now,
                                SaleContractCommID = "-",
                                SalesTaxValue = Convert.ToDecimal(Request.Form["det[" + index + "][sales]"]),
                                CommissionInvoiceNoKey = IndentDomestic.InquiryKey,
                                CommissionInvoiceKey = commeInvoice.CommissionInvoiceKey,
                                CustomerIDCommPaidFrom_Ref = "000000",
                                CustomerIDCommPaidTo_Ref = "000000",
                                CommissionId = commissionId
                            };
                            commInvoiceAgentComm = commInvoiceAgent;
                          
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return commInvoiceAgentComm;
        }

        // GET: Indent/DomesticCommInv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/DomesticCommInv/Edit/5
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

        // GET: Indent/DomesticCommInv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/DomesticCommInv/Delete/5
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
