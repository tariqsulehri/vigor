using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.FinRepository;
namespace VIGOR.Areas.GL.Controllers
{

    public class CommonGLController : Controller
    {
        FinFescalYearDetailRepository _yearDetail;
        CoaL5Repository _repCoa5;
        public CommonGLController()
        {
            _repCoa5 = new CoaL5Repository();
            _yearDetail = new FinFescalYearDetailRepository();
        }
        // GET: GL/CommonGL
        public ActionResult TrCOA(string type)
        {
            ViewBag.Type = type;
            if (Session["ChartOfAccountFive"] == null)
            {
                Session["ChartOfAccountFive"] = _repCoa5.GetL5Accounts().ToList().AsReadOnly().Where(a => a.BookType == type);
                return PartialView("~/Areas/GL/Views/CommonGL/_TrCOA.cshtml", Session["ChartOfAccountFive"]);
            }
            return PartialView("~/Areas/GL/Views/CommonGL/_TrCOA.cshtml", Session["ChartOfAccountFive"]);
        }

        public ActionResult GetList(string GlCode, string Detail, string type)
        {

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var a = new List<ERP.Core.Models.Finance.CoaL5>();

            if (!string.IsNullOrEmpty(GlCode) && string.IsNullOrEmpty(Detail))
                a = _repCoa5.GetL5Accounts().Where(x => x.BookType == type&& x.L5Code.Equals(GlCode)&& x.Title.ToLower().Contains(Detail.ToLower())).ToList();
            if (string.IsNullOrEmpty(GlCode) && !string.IsNullOrEmpty(Detail))
                a = _repCoa5.GetL5Accounts().Where(x => x.BookType == type && x.Title.ToLower().Contains(Detail.ToLower())).ToList();

            int totalrows = a.Count();
            int totalrowsafterfiltering = a.Count();
            a = a.Skip(start).Take(length).ToList();
            var Collection = a.Select(x => new
            {
                L5Code = x.L5Code,
                Title = x.Title,
                IsDept = x.IsDept,
                IsLoc = x.IsLoc,
                IsEmp = x.IsEmp,
                IsCust = x.IsCust
            });
            return Json(new
            {
                data = Collection,
                draw = Request["draw"],
                recordsTotal = totalrows,
                recordsFiltered = totalrowsafterfiltering
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFiscalPeriod(int monthId)
        {
            var month = _yearDetail.FindById(monthId);
            return Json(new { Title = month.Title, StartDate = month.StartDate.ToString("dd-MM-yyyy"), EndDate = month.EndDate.ToString("MM-dd-yyyy") }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetGlAccount(string glcode)
        {
            var glcoa5 = _repCoa5.FindById(glcode);
            return Json(new { IsDept = glcoa5.IsDept, IsLoc = glcoa5.IsLoc, IsEmp = glcoa5.IsEmp, IsCust = glcoa5.IsCust }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult COAList()
        {
            List<string> titlelist = new List<string>();
            var COA = new CoaL5Repository().GetL5Accounts();
            foreach (var item in COA)
            {
                titlelist.Add(item.L5Code + " - " + item.Title);
            }
            return Json(titlelist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AuthenticationKey()
        {
            return PartialView("_AuthenticationKey");
        }

    }
}