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
    public class fnProfitAndLossController : Controller
    {
        // GET: GL/fnProfitAndLoss
        private FinVoucherRepository voucher;
        private CoaL5Repository coaL5Repository;
        private FinVTypeRepository vTypeRepository;
        private HrEmployeeRepository hrEmployeeRepository;
        private FinPartyRepository finPartyRepository;
        private CityRepository cityRepository;
        private HrDepartmentRepository hrDepartmentRepository;
        public fnProfitAndLossController()
        {
            voucher = new FinVoucherRepository();
            vTypeRepository = new FinVTypeRepository();
            coaL5Repository = new CoaL5Repository();
            hrEmployeeRepository = new HrEmployeeRepository();
            finPartyRepository = new FinPartyRepository();
            cityRepository = new CityRepository();
            hrDepartmentRepository = new HrDepartmentRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProfitandLossCriteria(DateTime? frDateTime, DateTime? toDateTime, string glCode, Int32? deptId, Int32? locId,
           Int32? empId, Int32? custId)
        {
            string criteria = string.Empty;
            criteria = " For the Period : " + frDateTime.Value.ToString("dd/MM/yyyy") + "  To : " +toDateTime.Value.ToString("dd/MM/yyyy")+ " <br />"+
                (deptId > 0 ? (" Department : ") + hrDepartmentRepository.FindById((int)deptId).Title : "") +
                  (locId > 0 ? (" Location : ") + cityRepository.FindById((int)locId).Name : "") +
                  (empId > 0 ? (" Employee : ") + hrEmployeeRepository.FindById((int)empId).Title : "") +
                  (custId > 0 ? (" Customer : ") + finPartyRepository.FindById((int)custId).Title : "");
            ViewBag.Criteria = criteria;
            return PartialView("~/Areas/GL/Views/fnProfitAndLoss/_ProfitAndLoss.cshtml");
        }



    }
}