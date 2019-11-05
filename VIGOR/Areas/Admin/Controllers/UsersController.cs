using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using AutoMapper;
using ERP.Core.Models.Admin;
using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.Admin;
using Microsoft.AspNet.Identity.Owin;
using VIGOR.App_Start;
using VIGOR.Models;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.Admin.Controllers
{
    [Security]
    public class UsersController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private HrDepartmentRepository _department;

        private ErpDbContext db = new ErpDbContext();
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }
        private readonly UserRepository _userRepository;
        private readonly UserModulesRepository _userModulesRepository;
        private readonly AdminModulesRepository _adminModulesRepository;
        private readonly AdminModuleDetailsRepository _adminModuleDetailsRepository;
        private readonly UserModuleDetailsRepository _userModuleDetailsRepository;
        public UsersController()
        {
            _userRepository = new UserRepository();
            _userModulesRepository = new UserModulesRepository();
            _adminModulesRepository = new AdminModulesRepository();
            _adminModuleDetailsRepository = new AdminModuleDetailsRepository();
            _userModuleDetailsRepository = new UserModuleDetailsRepository();
            _department = new HrDepartmentRepository();
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(_userRepository.GetAllUsers());
        }

        // GET: Admin/Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            user.CreatedBy = 0;
            user.ModifiedBy = 0;
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            user.IsActive = true;

            try
            {
                if (ModelState.IsValid && _userRepository.GetAllUsers().Any(x => x.UserName != user.UserName))
                {
                    //SignInManager.PasswordSignInAsync(user.UserName, user.Password, true, shouldLockout: false);
                    _userRepository.Add(user);
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.FindById(id ?? 0);
            if (user == null)
            {
                return HttpNotFound();
            }
            AdminUserDealsInDepartmentRepository adminUserDealsInDepartmentRepository = new AdminUserDealsInDepartmentRepository();
            var allowdepartment = adminUserDealsInDepartmentRepository.GetAllDepartmentsByUser(user.Id);

            ViewBag.SystemOptionList = db.SystemOptions.Where(x => !x.ParentID.HasValue).ToList();
            List<HrDepartment> lstDepartments = new List<HrDepartment>();
            ViewBag.Department = _department.GetAllDepartment();
            foreach (var dept in ViewBag.Department)
            {
                if (allowdepartment.Where(a => a.DeptId == dept.id).ToList().Count > 0)
                    dept.IsAllow = true;
                lstDepartments.Add(dept);
            }
            ViewBag.Department = null;
            ViewBag.Department = lstDepartments;
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user, FormCollection formCollection)
        {
            JavaScriptSerializer j = new JavaScriptSerializer();
            //int UserId = Convert.ToInt32(Session["UserId"] != null ? Session["UserId"]:0);
            List<string> jsonObject = j.Deserialize<List<string>>((formCollection.Get("tableData")));
            db.UserPrevilages.RemoveRange(db.UserPrevilages.Where(x => x.UserId == user.Id));
            db.SaveChanges();
            foreach (var item in jsonObject)
            {
                UserPrevilage userPrevilage = new UserPrevilage();
                userPrevilage.OptionId = Convert.ToInt32(item ?? "0");
                userPrevilage.UserId = user.Id;
                userPrevilage.Allowed = true;
                db.UserPrevilages.Add(userPrevilage);
            }
            db.SaveChanges();
            user.CreatedBy = 0;
            user.ModifiedBy = 0;
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            user.IsActive = true;
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Edit(user);
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                SetViewBagData(user.Id);
                return View(user);
            }
        }

        // GET: Admin/Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: Admin/Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        #region User
        [HttpGet]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddAdminModuleReturnPartialView(int id, int userId)
        {
            bool tryAgain = true;
            User user = _userRepository.FindById(userId);
            while (tryAgain)
            {
                try
                {
                    AdminModules adminModule = _adminModulesRepository.FindById(id);
                    if (!_userModulesRepository.GetAllUserModules().Where(x => x.UserId == userId && x.ModuleId == id).Any())
                    {
                        UserModules userModule = new UserModules();
                        userModule.UserId = userId;
                        userModule.ModuleId = id;
                        userModule.CreatedOn = DateTime.Now;
                        userModule.ModifiedOn = DateTime.Now;
                        userModule.CreatedBy = 0;
                        userModule.ModifiedBy = 0;
                        _userModulesRepository.Add(userModule);
                        var adminModuleDetails = _adminModuleDetailsRepository.GetAllAdminModuleDetails().Where(x => x.AModuleId == adminModule.Id).ToList();
                        foreach (var item in adminModuleDetails)
                        {
                            UserModuleDetails userModuleDetail = new UserModuleDetails();
                            userModuleDetail.UserId = userId;
                            userModuleDetail.ModuleDtlId = item.Id;
                            userModuleDetail.CreatedOn = DateTime.Now;
                            userModuleDetail.ModifiedOn = DateTime.Now;
                            userModuleDetail.CreatedBy = 0;
                            userModuleDetail.ModifiedBy = 0;
                            _userModuleDetailsRepository.Add(userModuleDetail);
                        }
                    }
                    SetViewBagData(userId);
                    tryAgain = false;
                }
                catch (Exception)
                {
                }

            }
            return PartialView("_RefereshMainPage", user);
        }
        [HttpGet]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserModuleReturnPartialView(int id, int userId)
        {
            bool tryAgain = true;
            User user = _userRepository.FindById(userId);
            while (tryAgain)
            {
                try
                {
                    UserModules userModule = _userModulesRepository.FindById(id);
                    if (userModule != null)
                    {
                        var adminModuleDetails = userModule.AdminModules.AdminModuleDetails.Where(x => x.AModuleId == userModule.AdminModules.Id && x.UserModuleDetails.Count(y => y.UserId == userId && y.ModuleDtlId == x.Id) > 0).ToList();
                        List<int> UserDetailIds = new List<int>();
                        foreach (var adminModuleDetail in adminModuleDetails)
                        {
                            UserDetailIds.Add(adminModuleDetail.Id);
                        }
                        foreach (var UserDetailId in UserDetailIds)
                        {
                            _userModuleDetailsRepository.RemoveAll(UserDetailId);
                        }
                        _userModulesRepository.Remove(userModule.Id);
                    }
                    SetViewBagData(userId);
                    tryAgain = false;
                }
                catch (Exception)
                {
                }
            }
            return PartialView("_RefereshMainPage", user);
        }
        [HttpGet]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddAdminModuleDetailReturnPartialView(int id, int userId)
        {
            bool tryAgain = true;
            User user = _userRepository.FindById(userId);
            while (tryAgain)
            {
                try
                {
                    AdminModuleDetails adminModuleDetail = _adminModuleDetailsRepository.FindById(id);
                    if (!_userModuleDetailsRepository.GetAllUserModuleDetails().Where(x => x.UserId == userId && x.ModuleDtlId == id).Any())
                    {
                        if (!_userModulesRepository.GetAllUserModules().Any(x => x.ModuleId == adminModuleDetail.AModuleId & x.UserId == userId))
                        {
                            UserModules userModule = new UserModules();
                            userModule.UserId = userId;
                            userModule.ModuleId = adminModuleDetail.AModuleId;
                            userModule.CreatedOn = DateTime.Now;
                            userModule.ModifiedOn = DateTime.Now;
                            userModule.CreatedBy = 0;
                            userModule.ModifiedBy = 0;
                            _userModulesRepository.Add(userModule);
                        }
                        UserModuleDetails userModuleDetail = new UserModuleDetails();
                        userModuleDetail.UserId = userId;
                        userModuleDetail.ModuleDtlId = id;
                        userModuleDetail.CreatedOn = DateTime.Now;
                        userModuleDetail.ModifiedOn = DateTime.Now;
                        userModuleDetail.CreatedBy = 0;
                        userModuleDetail.ModifiedBy = 0;
                        _userModuleDetailsRepository.Add(userModuleDetail);
                    }
                    SetViewBagData(userId);
                    tryAgain = false;
                }
                catch (Exception)
                {
                }
            }
            return PartialView("_RefereshMainPage", user);
        }
        [HttpGet]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserModuleDetailReturnPartialView(int id, int userId)
        {
            bool tryAgain = true;
            User user = _userRepository.FindById(userId);
            while (tryAgain)
            {
                try
                {
                    UserModuleDetails userModuleDetail = _userModuleDetailsRepository.FindById(id);
                    if (userModuleDetail != null)
                    {
                        _userModuleDetailsRepository.Remove(userModuleDetail.Id);
                    }
                    SetViewBagData(userId);
                    tryAgain = false;
                }
                catch (Exception)
                {
                }
            }
            return PartialView("_RefereshMainPage", user);
        }
        private void SetViewBagData(int _userId)
        {
            ViewBag.UserId = _userId;
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            ViewBag.AdminModuleId = new SelectList(_adminModulesRepository.GetAllAdminModules().Where(x => x.UserModules.Count(y => y.UserId == _userId) == 0 && x.IsActive).OrderBy(p => p.DisplayName), "Id", "DisplayName");
            ViewBag.AdminModuleDetailId = new SelectList(_adminModuleDetailsRepository.GetAllAdminModuleDetails().Where(x => x.UserModuleDetails.Count(y => y.UserId == _userId) == 0 && x.IsActive).OrderBy(p => p.DisplayName), "Id", "DisplayName");
        }

        public List<SelectListItem> List_boolNullYesNo()
        {
            var _retVal = new List<SelectListItem>();
            try
            {
                _retVal.Add(new SelectListItem { Text = "Not Set", Value = null });
                _retVal.Add(new SelectListItem { Text = "Yes", Value = bool.TrueString });
                _retVal.Add(new SelectListItem { Text = "No", Value = bool.FalseString });
            }
            catch { }
            return _retVal;
        }

        [HttpPost]
        public ActionResult AllowDepartmentToUser(List<int> favorite, int UserId)
        {
            AdminUserDealsInDepartmentRepository adminUserDealsInDepartmentRepository = new AdminUserDealsInDepartmentRepository();
            AdminUserDealsInDepartment objAdminUserDealsInDepartment = new AdminUserDealsInDepartment();
            objAdminUserDealsInDepartment.UserId = UserId;
            adminUserDealsInDepartmentRepository.Remove(objAdminUserDealsInDepartment);
            foreach (var obj in favorite)
            {
                objAdminUserDealsInDepartment = new AdminUserDealsInDepartment();
                objAdminUserDealsInDepartment.DeptId = obj;
                objAdminUserDealsInDepartment.UserId = UserId;
                objAdminUserDealsInDepartment.mKey = UserId.ToString();
                adminUserDealsInDepartmentRepository.Add(objAdminUserDealsInDepartment);
            }


            return null;
        }



        #endregion
    }
}
