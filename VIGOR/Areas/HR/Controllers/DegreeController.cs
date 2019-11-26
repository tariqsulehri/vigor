using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class DegreeController : Controller
    {
        // GET: General/Degree
        private HR_DegreeRepository _hrDegreeRepository;
        private ErpDbContext _dbContext;

        public DegreeController()
        {
            _dbContext=new ErpDbContext();
            _hrDegreeRepository =new HR_DegreeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Degree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Degree/CreateOrUpdate
        public ActionResult CreateOrUpdate()
        {
            return View();
        }
        // GET: General/Degree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Degree/Create
        [HttpPost]
        public ActionResult Create(HR_Degree model)
        {
            try
            {
                model.DegreeID = GetDegreeID();
                ModelState.Remove("DegreeID");
                if (_hrDegreeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is Not Allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrDegreeRepository.Add(model);
                        RedirectToAction("Create", "Employee");
                    }
                    else
                    {
                        return View(model);
                    }

                }

                return RedirectToAction("Create","Employee");
            }
            catch
            {
                return View();
            }
        }

        // GET: General/Degree/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/Degree/Edit/5
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

        // GET: General/Degree/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: General/Degree/Delete/5
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
        public string GetDegreeID()
        {
            int maxno = _dbContext.HR_Degree.Count();
            maxno = maxno + 1;
            string SerialID = maxno.ToString();
            return SerialID;
        }
    }
}
