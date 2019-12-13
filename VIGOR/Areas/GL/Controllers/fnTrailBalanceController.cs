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
using VIGOR.Areas.GL.Models;
using ERP.Infrastructure;
using System.Data.SqlClient;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnTrailBalanceController : Controller
    {
        private ErpDbContext db=new ErpDbContext();
        private FinVoucherRepository voucher;
        private CoaL5Repository coaL5Repository;
        private CoaL1Repository col1Rep;

        public fnTrailBalanceController()
        {
            voucher = new FinVoucherRepository();
            coaL5Repository = new CoaL5Repository();
            col1Rep= new CoaL1Repository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TrailBalanceCriteria(DateTime? frDateTime, DateTime? toDateTime,int? level,Boolean includezero)
        {
            string criteria = string.Empty;
            criteria = " For the Period : " + frDateTime.Value.ToString("dd/MM/yyyy") + "  To : " + toDateTime.Value.ToString("dd/MM/yyyy");
            ViewBag.Criteria = criteria;
            using (var context = new ErpDbContext())
            {
                try
                {
                   
                    var from = new SqlParameter("@From", frDateTime);
                    var to = new SqlParameter("@To", toDateTime);
                    List<TrailBalanceModel> lst = new List<TrailBalanceModel>();
                    lst = context.Database.SqlQuery<TrailBalanceModel>("SP_DEBIT_CRIDET @From,@To", from, to).ToList();
                    if (level != null)
                    {
                        lst = lst.Where(a =>Convert.ToInt32( a.LevelOfAccount) <= level).ToList(); }
                    if (!includezero) { lst = lst.Where(a => a.Debit !=0 || a.Credit!=0).ToList(); }
                
                    ViewBag.Opebal = lst.Sum(a => a.OPBAL);
                    ViewBag.debit = lst.Sum(a => a.Debit );
                    ViewBag.credit = lst.Sum(a =>a.Credit);
                    ViewBag.balance = lst.Sum(a => a.Balancee);
                    return PartialView("~/Areas/GL/Views/fnTrailBalance/_TrailBalance.cshtml", lst);
                }
                catch (Exception ex) { throw ex; }
            }




        }



    }
}