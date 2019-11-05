using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.ForeignLedger
{
    public class ForignLedgerController : Controller
    {
        // GET: GL/ForignLedger
        public ActionResult ForiegnCurrencyCOA()
        {
            return View();
        }
        public ActionResult ManageForeignCurrencyAccount()
        {
            return View();
        }
        public ActionResult RecoveryResponsibility()
        {
            return View();
        }
        public ActionResult UnpostInvoice()
        {
            return View();
        }
        public ActionResult Ledger()
        {
            return View();
        }
        public ActionResult Statement()
        {
            return View();
        }
        public ActionResult Recovery()
        {
            return View();
        }
        public ActionResult ClosingBalance()
        {
            return View();
        }
        public ActionResult ManageForeignAccounts()
        {
            return View();
        }
    }
}