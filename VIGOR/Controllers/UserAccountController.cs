using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Common;
using ERP.Core.Models.Admin;
using ERP.Infrastructure.Repositories.Admin;
using VIGOR.Models;

namespace VIGOR.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        private CompanyRepository companyRepository;
        private User user;
        private readonly UserModuleDetailsRepository _userModuleDetailsRepository;
        private readonly UserModulesRepository _userModulesRepository;
        private readonly AdminModulesRepository _adminModulesRepository;

        public UserAccountController()
        {
            companyRepository = new CompanyRepository();
            user = new User();
            _userModuleDetailsRepository = new UserModuleDetailsRepository();
            _userModulesRepository = new UserModulesRepository();
            _adminModulesRepository = new AdminModulesRepository();

            user.Id = 1;
            user.UserName = "Shehzad Yaseen";

        }
        public ActionResult Index()
        {
            Session["UserModel"] = user;
            Session["CompanyModel"] = companyRepository.FindById(4);
            //if (true)
            //{
            //    List<DynamicMenuBind> _mainMenu = _adminModulesRepository.GetAllAdminModules().Select(x => new DynamicMenuBind
            //    {
            //        AdminMenuId = x.Id,
            //        AdminMenuPermission = x.ModuleName,
            //    }).ToList();
            //    List<DynamicMenuItemBind> _menusItem = _userModuleDetailsRepository.GetAllUserModuleDetails().Where(x => x.UserId == 1 && x.AdminModuleDetails.Url.Contains("Index")).Select(x => new DynamicMenuItemBind
            //    {
            //        UserId = x.UserId,
            //        AdminMenuId = x.AdminModuleDetails.AdminModules.Id,
            //        AdminMenuPermission = x.AdminModuleDetails.AdminModules.DisplayName,
            //        AdminMenuDetailId = x.AdminModuleDetails.Id,
            //        AdminMenuDetailPermission = x.AdminModuleDetails.DisplayName,
            //        ControllerName = x.AdminModuleDetails.Url,
            //        ActionName = x.AdminModuleDetails.Url
            //    }).ToList(); //Get the Menu details from entity and bind it in MenuModels list.
            //    Session["MenuMaster"] = _mainMenu; //Bind the _menus list to MenuMaster session
            //    Session["MenuItem"] = _menusItem;
            //}
            return View();
        }

        // GET: UserAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccount/Create
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

        // GET: UserAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAccount/Edit/5
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

        // GET: UserAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAccount/Delete/5
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
