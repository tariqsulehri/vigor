using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.Indenting;

namespace VIGOR.Areas.Admin.Controllers
{
    public class DepartmentDealsINCommodityController : Controller
    {
        private DeptDealsInCommodityTypeRepository _dealsInCommodityTypeRepository;
        private DeptDealsInMarkeetRepository _dealsInMarkeetRepository;

        private DeptDealsInCommodityTypeRepository _deptDealsInCommodityTypeRepository;
        // private readonly ErpDbContext _db;
        public DepartmentDealsINCommodityController()
        {
            _dealsInCommodityTypeRepository = new DeptDealsInCommodityTypeRepository();
            _dealsInMarkeetRepository = new DeptDealsInMarkeetRepository();
            _deptDealsInCommodityTypeRepository = new DeptDealsInCommodityTypeRepository();
            // _db=new ErpDbContext();
        }
        // GET: Admin/DepartmentDealsINCommodity
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/DepartmentDealsINCommodity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DepartmentDealsINCommodity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DepartmentDealsINCommodity/Create
        [HttpPost]
        public ActionResult Create(DeptDealsInCommodityType model)
        {
            try
            {
                List<DeptDealsInMarkeet> lstDealsInMarkeets = new List<DeptDealsInMarkeet>();
                List<DeptDealsInCommodityType> lstDeptDealsInCommodityTypes = new List<DeptDealsInCommodityType>();
                GetDealsInDepartment(model, out lstDealsInMarkeets, out lstDeptDealsInCommodityTypes);
                _dealsInCommodityTypeRepository.Delete(model);
                foreach (var item in lstDealsInMarkeets)
                {
                    _dealsInMarkeetRepository.Add(item);
                }
                foreach (var item in lstDeptDealsInCommodityTypes)
                {
                    _dealsInCommodityTypeRepository.Add(item);
                }
                TempData["SucessMessage"] = "Data Saved";
                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.InnerException.Message;
                return View();
            }
        }


        public ActionResult GetDealsinDepartment(int DeptID)
        {
            ViewBag.DealsInMarkeet = _dealsInMarkeetRepository.GetAllMarkeetByDepartment(DeptID);
            ViewBag.DealsInCommodity = _deptDealsInCommodityTypeRepository.GetAllCommodityTypeByDepartment(DeptID);
            return PartialView("~/Areas/Admin/Views/DepartmentDealsINCommodity/_DealsInDepartment.cshtml");
        }
        private void GetDealsInDepartment(DeptDealsInCommodityType model, out List<DeptDealsInMarkeet> lstDealsInMarkeets, out List<DeptDealsInCommodityType> lstDeptDealsInCommodityTypes)
        {
            List<DeptDealsInMarkeet> lstDealsIn = new List<DeptDealsInMarkeet>();
            List<DeptDealsInCommodityType> lstDeptCommodityTypes = new List<DeptDealsInCommodityType>();
            DeptDealsInCommodityType _dealsInCommodityType;
            DeptDealsInMarkeet _dealsInMarkeet;
            var DealsInList = new List<string>();
            var DealsInComodityList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("DealsInId"))
                    DealsInList.Add(k.ToString());
                if (k.ToString().Contains("ComodityType"))
                    DealsInComodityList.Add(k.ToString());
            }
            try
            {
                foreach (var Key in DealsInComodityList )
                {
                    var index = "0";
                    index = Key.Replace("][ComodityType]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][ComodityType]"))
                    {
                        _dealsInCommodityType = new DeptDealsInCommodityType();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][ComodityType]"]))
                        {
                            _dealsInCommodityType.ComodityType = Convert.ToInt32(Request.Form["det[" + index + "][ComodityType]"]);
                            _dealsInCommodityType.DepartmentId = model.DepartmentId;
                            _dealsInCommodityType.CreatedBy = LoggedinUser.LoggedInUser.Id;
                            _dealsInCommodityType.ModifiedBy = LoggedinUser.LoggedInUser.Id;
                            _dealsInCommodityType.CreatedOn = DateTime.Now;
                            _dealsInCommodityType.ModifiedOn = DateTime.Now;
                            _dealsInCommodityType.mkey = _dealsInCommodityType.ComodityType.ToString().PadLeft(2, '0') + _dealsInCommodityType.DepartmentId.ToString().PadLeft(2, '0');
                            lstDeptCommodityTypes.Add(_dealsInCommodityType);
                        }
                    }
                }
                foreach (var Key in DealsInList)
                {
                    var index = "0";
                    index = Key.Replace("][DealsInId]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][DealsInId]"))
                    {
                        _dealsInMarkeet = new DeptDealsInMarkeet();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][DealsInId]"]))
                        {
                            _dealsInMarkeet.DealsInId = Convert.ToInt32(Request.Form["det[" + index + "][DealsInId]"]);
                            _dealsInMarkeet.DepartmentId = model.DepartmentId;
                            _dealsInMarkeet.CreatedBy = LoggedinUser.LoggedInUser.Id;
                            _dealsInMarkeet.ModifiedBy = LoggedinUser.LoggedInUser.Id;
                            _dealsInMarkeet.CreatedOn = DateTime.Now;
                            _dealsInMarkeet.ModifiedOn = DateTime.Now;
                            _dealsInMarkeet.mkey = _dealsInMarkeet.DealsInId.ToString().PadLeft(2, '0') + _dealsInMarkeet.DepartmentId.ToString().PadLeft(2, '0');
                            lstDealsIn.Add(_dealsInMarkeet);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            lstDealsInMarkeets = lstDealsIn;
            lstDeptDealsInCommodityTypes = lstDeptCommodityTypes;
        }


        // GET: Admin/DepartmentDealsINCommodity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DepartmentDealsINCommodity/Edit/5
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

        // GET: Admin/DepartmentDealsINCommodity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DepartmentDealsINCommodity/Delete/5
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
