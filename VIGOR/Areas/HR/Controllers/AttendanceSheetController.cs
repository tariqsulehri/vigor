using ERP.Core.Models.HR;
using ERP.Core.Models.HR.ViewModels;
using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class AttendanceSheetController : Controller
    {
        HR_MonthlyAttendanceRepository _HR_MonthlyAttendanceRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        HR_AttendanceTimingsRepository _hR_AttendanceTimingsRepository;
        public AttendanceSheetController()
        {
            _HR_MonthlyAttendanceRepository = new HR_MonthlyAttendanceRepository();
            _hrEmployeeRepository = new HrEmployeeRepository();
            _hR_AttendanceTimingsRepository = new HR_AttendanceTimingsRepository();
        }
        // GET: General/AttendanceSheet
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int Forthemonth, int Fortheyear, String Department)
        {
            //ViewBag.FromDate = FromDate;
            //ViewBag.Todate = Todate;
            if (string.IsNullOrEmpty(Forthemonth.ToString())) Forthemonth = 0;
            if (string.IsNullOrEmpty(Fortheyear.ToString())) Fortheyear = 0;
            if (string.IsNullOrEmpty(Department.ToString())) Department = null;
            int days = DateTime.DaysInMonth(Fortheyear, Forthemonth);
            DateTime AttendanceMonth = new DateTime(Fortheyear, Forthemonth, 1);
            DateTime ValidDateStart = new DateTime(Fortheyear, Forthemonth, 1);
            DateTime ValidDateEnd = new DateTime(Fortheyear, Forthemonth, days);
            if (Forthemonth.Equals(0) || Fortheyear.Equals(0) || Department.Equals(null))
            {
                ModelState.AddModelError("", "Invalid Search Criteria");
                return View();
            }
            var departmentEmployee = _hrEmployeeRepository.GetAllEmployees().Where(s => s.DeptId == Int32.Parse(Department)).ToList();
            foreach (var item in departmentEmployee)
            {
                var employeeAttendence = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance()
                      .Where(a => a.Forthemonth.Equals(Forthemonth) || Forthemonth.Equals(0))
                      .Where(a => a.Fortheyear.Equals(Fortheyear) || Fortheyear.Equals(0))
                      .Where(a => a.EmployeeId.Equals(item.Id))
                      .Where(a => a.Department.Equals(Department) || Department.Equals(string.Empty)).FirstOrDefault();

                if (employeeAttendence == null)
                {
                    HR_MonthlyAttendance hR_MonthlyAttendance = new HR_MonthlyAttendance();
                    //hR_MonthlyAttendance.EmployeeAttendanceId =_HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance().OrderByDescending(u => u.EmployeeAttendanceId).FirstOrDefault().ToString();
                    hR_MonthlyAttendance.EmployeeAttendanceId = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance().Max(u => u.EmployeeAttendanceId);
                    hR_MonthlyAttendance.EmployeeAttendanceId = (Convert.ToInt32(hR_MonthlyAttendance.EmployeeAttendanceId) + 1).ToString();
                    hR_MonthlyAttendance.EmployeeNo = "22";
                    hR_MonthlyAttendance.companyID = item.companyID;
                    hR_MonthlyAttendance.AttendanceMonth = AttendanceMonth;
                    hR_MonthlyAttendance.Forthemonth = Forthemonth;
                    hR_MonthlyAttendance.Fortheyear = Fortheyear;
                    hR_MonthlyAttendance.Department = Department;
                    hR_MonthlyAttendance.Designation = item.Designation;
                    hR_MonthlyAttendance.ValidDateStart = ValidDateStart;
                    hR_MonthlyAttendance.ValidDateEnd = ValidDateEnd;
                    hR_MonthlyAttendance.IsSeparated = true;
                    hR_MonthlyAttendance.TotalMonthDays = days;
                    hR_MonthlyAttendance.TotalWorkingDays = days;
                    hR_MonthlyAttendance.WithPay = days;
                    hR_MonthlyAttendance.WithOutPay = 0;
                    hR_MonthlyAttendance.Leaves = 0;
                    hR_MonthlyAttendance.Visits = 1;
                    hR_MonthlyAttendance.EmployeeId = item.Id;
                    hR_MonthlyAttendance.Day01 = "pr";
                    hR_MonthlyAttendance.Day02 = "pr";
                    hR_MonthlyAttendance.Day03 = "pr";
                    hR_MonthlyAttendance.Day04 = "pr";
                    hR_MonthlyAttendance.Day05 = "pr";
                    hR_MonthlyAttendance.Day06 = "pr";
                    hR_MonthlyAttendance.Day07 = "pr";
                    hR_MonthlyAttendance.Day08 = "pr";
                    hR_MonthlyAttendance.Day09 = "pr";
                    hR_MonthlyAttendance.Day10 = "pr";
                    hR_MonthlyAttendance.Day11 = "pr";
                    hR_MonthlyAttendance.Day12 = "pr";
                    hR_MonthlyAttendance.Day13 = "pr";
                    hR_MonthlyAttendance.Day14 = "pr";
                    hR_MonthlyAttendance.Day15 = "pr";
                    hR_MonthlyAttendance.Day16 = "pr";
                    hR_MonthlyAttendance.Day17 = "pr";
                    hR_MonthlyAttendance.Day18 = "pr";
                    hR_MonthlyAttendance.Day19 = "pr";
                    hR_MonthlyAttendance.Day20 = "pr";
                    hR_MonthlyAttendance.Day21 = "pr";
                    hR_MonthlyAttendance.Day22 = "pr";
                    hR_MonthlyAttendance.Day23 = "pr";
                    hR_MonthlyAttendance.Day24 = "pr";
                    hR_MonthlyAttendance.Day25 = "pr";
                    hR_MonthlyAttendance.Day26 = "pr";
                    hR_MonthlyAttendance.Day27 = "pr";
                    hR_MonthlyAttendance.Day28 = "pr";
                    hR_MonthlyAttendance.Day29 = "pr";
                    hR_MonthlyAttendance.Day30 = "pr";
                    hR_MonthlyAttendance.Day31 = "pr";
                    _HR_MonthlyAttendanceRepository.Add(hR_MonthlyAttendance);

                }
            }

            HR_MonthlyAttendanceRepository AllAtt = new HR_MonthlyAttendanceRepository();
            ViewBag.Attendance = AllAtt.GetAllHR_MonthlyAttendance()
                .Where(a => a.Forthemonth.Equals(Forthemonth) || Forthemonth.Equals(0))
                .Where(a => a.Fortheyear.Equals(Fortheyear) || Fortheyear.Equals(0))
                .Where(a => a.Department.Equals(Department) || Department.Equals(string.Empty)).ToList();
            return View();
            //return RedirectToAction("Index",new { Forthemonth,  Fortheyear,  Department });



        }


        // GET: General/AttendanceSheet/ChangeStatus
        public ActionResult ChangeStatus(string EmployeeId, string EmployeeAttendanceId, int days, string statusValue)
        {
            HR_MonthlyAttendance employeeAttendence = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance()
                    .Where(a => a.EmployeeId == Convert.ToInt32(EmployeeId) && a.EmployeeAttendanceId == EmployeeAttendanceId)
                .FirstOrDefault();
            MonthAttendance_VM obj = new MonthAttendance_VM();

            obj.Forthemonth = employeeAttendence.Forthemonth.ToString();
            obj.Fortheyear = employeeAttendence.Fortheyear.ToString();
            DateTime ValidDateStart = new DateTime(employeeAttendence.Fortheyear, employeeAttendence.Forthemonth, days);
            obj.DayNumber = days;
            obj.ValidDateStart = ValidDateStart;
            obj.EmployeeAttendanceId = employeeAttendence.EmployeeAttendanceId.ToString();
            var employee = _hrEmployeeRepository.GetAllEmployees().Where(s => s.Id == Convert.ToInt32(EmployeeId)).FirstOrDefault();
            obj.EmployeeFirstName = employee.FirstName;
            obj.EmployeeDesignation = employee.HrDesignation.Description;
            obj.EmployeeDepartmentName = employee.HrDepartment.Title;

            List<SelectListItem> statuses = new List<SelectListItem>()
{
    new SelectListItem{Text="PR", Value="pr"},
    new SelectListItem{Text="AB", Value="ab"},
    new SelectListItem{Text="CH", Value="ch"},
    new SelectListItem{Text="ZH", Value="zh"},
    new SelectListItem{Text="AH", Value="ah"},
    new SelectListItem{Text="MH", Value="mh"},
    new SelectListItem{Text="OT", Value="ot"}
};
            ViewBag.status = new SelectList(statuses, "Value", "Text", statusValue);
            return View(obj);
        }

        [HttpPost]
        public ActionResult ChangeStatus(MonthAttendance_VM objForMA)
        {
            HR_MonthlyAttendance employeeAttendence = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance()
                    .Where(a => a.EmployeeAttendanceId == objForMA.EmployeeAttendanceId).FirstOrDefault();
            int d = Convert.ToInt32(objForMA.DayNumber);
            string dayFormate = d.ToString("D2");
            string statusDay = "Day" + dayFormate;
            employeeAttendence = setstatus(statusDay, objForMA.status, employeeAttendence);
            _HR_MonthlyAttendanceRepository.Edit(employeeAttendence);
            return null;
            //return RedirectToAction("Index", new { objForMA.Forthemonth, objForMA.Fortheyear, employeeAttendence.Department });
        }
        public HR_MonthlyAttendance setstatus(string statusDay, string status, HR_MonthlyAttendance employeeAttendence)
        {
            if ("Day01" == statusDay)
                employeeAttendence.Day01 = status;
            else if ("Day02" == statusDay)
                employeeAttendence.Day02 = status;
            else if ("Day03" == statusDay)
                employeeAttendence.Day03 = status;
            else if ("Day04" == statusDay)
                employeeAttendence.Day04 = status;
            else if ("Day05" == statusDay)
                employeeAttendence.Day05 = status;
            else if ("Day06" == statusDay)
                employeeAttendence.Day06 = status;
            else if ("Day07" == statusDay)
                employeeAttendence.Day07 = status;
            else if ("Day08" == statusDay)
                employeeAttendence.Day08 = status;
            else if ("Day09" == statusDay)
                employeeAttendence.Day09 = status;
            else if ("Day10" == statusDay)
                employeeAttendence.Day10 = status;
            else if ("Day11" == statusDay)
                employeeAttendence.Day11 = status;
            else if ("Day12" == statusDay)
                employeeAttendence.Day12 = status;
            else if ("Day13" == statusDay)
                employeeAttendence.Day13 = status;
            else if ("Day14" == statusDay)
                employeeAttendence.Day14 = status;
            else if ("Day15" == statusDay)
                employeeAttendence.Day15 = status;
            else if ("Day16" == statusDay)
                employeeAttendence.Day16 = status;
            else if ("Day17" == statusDay)
                employeeAttendence.Day17 = status;
            else if ("Day18" == statusDay)
                employeeAttendence.Day18 = status;
            else if ("Day19" == statusDay)
                employeeAttendence.Day19 = status;
            else if ("Day20" == statusDay)
                employeeAttendence.Day20 = status;
            else if ("Day21" == statusDay)
                employeeAttendence.Day21 = status;
            else if ("Day22" == statusDay)
                employeeAttendence.Day22 = status;
            else if ("Day23" == statusDay)
                employeeAttendence.Day23 = status;
            else if ("Day24" == statusDay)
                employeeAttendence.Day24 = status;
            else if ("Day25" == statusDay)
                employeeAttendence.Day25 = status;
            else if ("Day26" == statusDay)
                employeeAttendence.Day26 = status;
            else if ("Day27" == statusDay)
                employeeAttendence.Day27 = status;
            else if ("Day28" == statusDay)
                employeeAttendence.Day28 = status;
            else if ("Day29" == statusDay)
                employeeAttendence.Day29 = status;
            else if ("Day30" == statusDay)
                employeeAttendence.Day30 = status;
            else if ("Day31" == statusDay)
                employeeAttendence.Day31 = status;
            return employeeAttendence;
        }
        // GET: General/AttendanceSheet/AttendanceTime
        [HttpGet]
        public ActionResult AttendanceTime(string EmployeeId ,string EmployeeAttendanceId , int days)
        {
            HR_AttendanceTimings obj = new HR_AttendanceTimings();
            var employee = _hrEmployeeRepository.GetAllEmployees().Where(s => s.Id == Convert.ToInt32(EmployeeId)).FirstOrDefault();
           
            HR_MonthlyAttendance employeeAttendence = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance()
                     .Where(a => a.EmployeeId == Convert.ToInt32(EmployeeId) && a.EmployeeAttendanceId == EmployeeAttendanceId)
                 .FirstOrDefault();

            obj.AttendanceMonth = employeeAttendence.Forthemonth;
            obj.AttendanceYear = employeeAttendence.Fortheyear;
            DateTime AttendanceDateFo = new DateTime(employeeAttendence.Fortheyear, employeeAttendence.Forthemonth, days);
            obj.AttendanceDate = AttendanceDateFo;
            obj.HrEmployee = employee;
            //obj.HrEmployee.FirstName = employee.FirstName;
            //obj.HrEmployee.HrDesignation.Description = employee.HrDesignation.Description;
            //obj.HrEmployee.HrDepartment.Title = employee.HrDepartment.Title;
            return View(obj);
        }

        [HttpGet]
        public ActionResult AttendanceTimeAddEdit(string EmployeeId,string EmployeeAttendanceID, DateTime TimeIn, DateTime TimeOut, int ForTheMonth, int ForTheYear, int Day)
        {
            HR_AttendanceTimings obj = new HR_AttendanceTimings();
            var employee = _hrEmployeeRepository.GetAllEmployees().Where(s => s.Id == Convert.ToInt32(EmployeeId)).FirstOrDefault();
            
            HR_MonthlyAttendance employeeAttendence = _HR_MonthlyAttendanceRepository.GetAllHR_MonthlyAttendance()
                     .Where(a => a.EmployeeId == Convert.ToInt32(EmployeeId) && a.EmployeeAttendanceId == EmployeeAttendanceID)
                 .FirstOrDefault();
            //obj.HrEmployee = employee;
            obj.EmployeeAttendanceID = EmployeeAttendanceID;
            int hoursFromTimeIn = TimeIn.Hour;
            int minuteFromTimeIn = TimeIn.Minute;
            int hoursFromTimeOut = TimeOut.Hour;
            int minuteFromTimeOut = TimeOut.Hour;
            DateTime TimeInDate = new DateTime(ForTheYear, ForTheMonth, Day, hoursFromTimeIn,minuteFromTimeIn,0);
            obj.Checkin = TimeInDate;

            DateTime TimeOutDate = new DateTime(ForTheYear, ForTheMonth, Day, hoursFromTimeOut,minuteFromTimeOut,0);
            obj.CheckOut = TimeOut;
            obj.AttendanceMonth = ForTheMonth;
            obj.AttendanceYear = ForTheYear;
            obj.companyID = employee.companyID;
            obj.EmployeeNo = EmployeeId;
            obj.CreatedBy =Convert.ToInt32(EmployeeId);
            obj.ModifiedBy =Convert.ToInt32(EmployeeId);
            obj.CreatedOn = DateTime.Now;
            obj.ModifiedOn = DateTime.Now;
            obj.CompanyKey = "aa";
            obj.EmployeeId = employee.Id;
            obj.AttendanceDate = new DateTime(ForTheYear, ForTheMonth, Day);
            obj.TimeCheckin = TimeIn.ToString("hh:mm tt");
            obj.TimeCheckout = TimeOut.ToString("hh:mm tt");
            if(_hR_AttendanceTimingsRepository.timingExists(obj)=="No")
            _hR_AttendanceTimingsRepository.Add(obj);
            else { _hR_AttendanceTimingsRepository.Edit(obj); }
            //obj.HrEmployee.FirstName = employee.FirstName;
            //obj.HrEmployee.HrDesignation.Description = employee.HrDesignation.Description;
            //obj.HrEmployee.HrDepartment.Title = employee.HrDepartment.Title;
            return null;
        }
        // GET: General/AttendanceSheet/ShortLeave
        public ActionResult ShortLeave(int EmplId)
        {
            return View();
        }
        //Attendance Time In & Time Out Data Update
        public ActionResult TimeInOutUpdate()
        {
            return View();
        }
        // GET: General/AttendanceSheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/AttendanceSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/AttendanceSheet/Create
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

        // GET: General/AttendanceSheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/AttendanceSheet/Edit/5
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

        // GET: General/AttendanceSheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: General/AttendanceSheet/Delete/5
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
