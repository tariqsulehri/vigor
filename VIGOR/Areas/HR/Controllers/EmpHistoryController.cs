using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;
using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common;


namespace VIGOR.Areas.HR.Controllers
{
    public class EmpHistoryController : Controller
    {
        HR_MonthlyAttendanceRepository _HR_MonthlyAttendanceRepository;
        HrEmployeeRepository _HrEmployeeRepository;
        public EmpHistoryController()
        {
            _HR_MonthlyAttendanceRepository = new HR_MonthlyAttendanceRepository();
            _HrEmployeeRepository = new HrEmployeeRepository();
        }
        // GET: HR/EmpHistory
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpHistory/Details/5
        public ActionResult Details(int EmplId)
        {
            ViewBag.ID = EmplId;
            HrEmployee obj = _HrEmployeeRepository.FindById(EmplId);
            return View(obj);
        }

        // GET: HR/EmpHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/EmpHistory/Create
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

        // GET: HR/EmpHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpHistory/Edit/5
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

        // GET: HR/EmpHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpHistory/Delete/5
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
        public ActionResult GetAttendance(int empId)
        {

            var AttendanceData = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance().Where(x => x.EmployeeId == empId).ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);
            var collection = AttendanceData.Select(x => new
            {
                formonth=x.Forthemonth,
                Tmonthdays=x.TotalMonthDays,
                Tworkdays=x.TotalWorkingDays,
                wop=x.WithOutPay,
                leave=x.Leaves,
                visit=x.Visits,
                d1=x.Day01,
                d2=x.Day02,
                d3=x.Day03,
                d4=x.Day04,
                d5=x.Day05,
                d6=x.Day06,
                d7=x.Day07,
                d8=x.Day08,
                d9=x.Day09,
                d10=x.Day10,
                d11=x.Day11,
                d12=x.Day12,
                d13=x.Day13,
                d14=x.Day14,
                d15=x.Day15,
                d16=x.Day16,
                d17=x.Day17,
                d18=x.Day18,
                d19=x.Day19,
                d20=x.Day20,
                d21=x.Day21,
                d22=x.Day22,
                d23=x.Day23,
                d24=x.Day24,
                d25=x.Day25,
                d26=x.Day26,
                d27=x.Day27,
                d28=x.Day28,
                d29=x.Day29,
                d30=x.Day30,
                d31=x.Day31
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
