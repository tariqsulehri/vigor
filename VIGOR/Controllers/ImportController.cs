using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
using ERP.Core.Models.Finance;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.FinRepository;
using VIGOR.Areas.GL.Models;
using VIGOR.ImportUtility;
using ERP.Core.Models.Admin;
using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Controllers
{

    public class ImportController : Controller
    {
        private ErpDbContext Db = new ErpDbContext();
        private ImportDataModel importdb = new ImportDataModel();

        CoaL1Repository col1Rep;
        CoaL2Repository col2Rep;
        CoaL3Repository col3Rep;
        CoaL4Repository col4Rep;
        CoaL5Repository col5Rep;

        public ImportController()
        {
            col1Rep = new CoaL1Repository();
            col2Rep = new CoaL2Repository();
            col3Rep = new CoaL3Repository();
            col4Rep = new CoaL4Repository();
            col5Rep = new CoaL5Repository();
        }
        public ActionResult Index()
        {
            // importcoa();
            Create();
            return View();
        }
        [HttpPost]
        private void importcoa()
        {
            CoaL3 _coaL3 = new CoaL3();
            CoaL4 _coaL4 = new CoaL4();
            CoaL5 _coaL5 = new CoaL5();
            COAModel model = new COAModel();
            var coa2 = Db.CoaL2.ToList();
            SqlConnection conn = new SqlConnection(GetConStr());
            conn.Open();
            foreach (var coa in coa2)
            {
                DataTable dt = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                try
                {
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from GL_COA where CompanyID=01 and LevelOfAccount=1  and AccountTitle like '" + coa.Title.Trim() + "' ", conn);
                    da.Fill(dt);
                    foreach (DataRow r in dt.Rows)
                    {
                        int accountid3 = Convert.ToInt32(r["accountid"].ToString());
                        dt3 = new DataTable();
                        SqlDataAdapter sda3 = new SqlDataAdapter("Select * from GL_COA where CompanyID=01 and LevelOfAccount=2  and ParentID =" + accountid3 + "", conn);
                        sda3.Fill(dt3);
                        foreach (DataRow r3 in dt3.Rows)
                        {
                            model = new COAModel();
                            model.leveltype = '3';
                            model.L2Code = coa.L2Code;
                            model.L3Code = NewCOACode(model);
                            if (!string.IsNullOrEmpty(model.L3Code))
                            {
                                _coaL3 = new CoaL3();
                                _coaL3.Title = (r3["AccountTitle"].ToString());
                                _coaL3.L2Code = coa.L2Code;
                                _coaL3.Active = true;
                                _coaL3.L3Code = model.L3Code;
                                col3Rep.Add(_coaL3);
                            }
                            int accountid4 = Convert.ToInt32(r3["accountid"].ToString());
                            dt4 = new DataTable();
                            SqlDataAdapter sda4 = new SqlDataAdapter("Select * from GL_COA where CompanyID=01 and LevelOfAccount=3  and ParentID =" + accountid4 + "", conn);
                            sda4.Fill(dt4);
                            foreach (DataRow r4 in dt4.Rows)
                            {
                                model = new COAModel();
                                model.leveltype = '4';
                                model.L3Code = _coaL3.L3Code;
                                model.L4Code = NewCOACode(model);
                                if (!string.IsNullOrEmpty(model.L4Code))
                                {
                                    _coaL4 = new CoaL4();
                                    _coaL4.Title = (r4["AccountTitle"].ToString());
                                    _coaL4.L3Code = model.L3Code;
                                    _coaL4.Active = true;
                                    _coaL4.L4Code = model.L4Code;
                                    col4Rep.Add(_coaL4);
                                }
                                if (Convert.ToBoolean(r4["IsTransectionLevel"]))
                                {
                                    model = new COAModel();
                                    model.leveltype = '5';
                                    model.L4Code = _coaL4.L4Code;
                                    model.L5Code = NewCOACode(model);
                                    if (!string.IsNullOrEmpty(model.L5Code))
                                    {
                                        _coaL5 = new CoaL5();
                                        _coaL5.Title = _coaL4.Title;
                                        _coaL5.L4Code = model.L4Code;
                                        _coaL5.Active = true;
                                        _coaL5.IsDept = Convert.ToBoolean(r4["MustAttachDepartment"]);
                                        _coaL5.IsLoc = Convert.ToBoolean(r4["MustAttachLocation"]);
                                        _coaL5.IsEmp = Convert.ToBoolean(r4["MustAttachEmployee"]);
                                        _coaL5.IsCust = Convert.ToBoolean(r4["MustAttachCustomer"]);
                                        _coaL5.BookType = "G";
                                        _coaL5.CreatedOn = DateTime.Now;
                                        _coaL5.ModifiedOn = DateTime.Now;
                                        _coaL5.L5Code = model.L5Code;
                                        col5Rep.Add(_coaL5);
                                    }
                                }
                                else
                                {


                                    int accountid5 = Convert.ToInt32(r4["accountid"].ToString());
                                    dt5 = new DataTable();
                                    SqlDataAdapter sda5 = new SqlDataAdapter(
                                        "Select * from GL_COA where CompanyID=01 and LevelOfAccount=4  and ParentID =" +
                                        accountid5 + "", conn);
                                    sda5.Fill(dt5);
                                    foreach (DataRow r5 in dt5.Rows)
                                    {
                                        model = new COAModel();
                                        model.leveltype = '5';
                                        model.L4Code = _coaL4.L4Code;
                                        model.L5Code = NewCOACode(model);
                                        if (!string.IsNullOrEmpty(model.L5Code))
                                        {
                                            _coaL5 = new CoaL5();
                                            _coaL5.Title = (r5["AccountTitle"].ToString());
                                            _coaL5.L4Code = model.L4Code;
                                            _coaL5.Active = true;

                                            _coaL5.IsDept = Convert.ToBoolean(r4["MustAttachDepartment"]);
                                            _coaL5.IsLoc = Convert.ToBoolean(r4["MustAttachLocation"]);
                                            _coaL5.IsEmp = Convert.ToBoolean(r4["MustAttachEmployee"]);
                                            _coaL5.IsCust = Convert.ToBoolean(r4["MustAttachCustomer"]);
                                            _coaL5.BookType = "G";
                                            _coaL5.CreatedOn = DateTime.Now;
                                            _coaL5.ModifiedOn = DateTime.Now;
                                            _coaL5.L5Code = model.L5Code;
                                            col5Rep.Add(_coaL5);
                                        }

                                    }
                                }
                            }
                        }


                    }



                }
                catch (Exception ex)
                { throw ex; }


            }

        }

        private static string GetConStr()
        {
            string ConStr;
            ConStr = "Data Source=.;Initial Catalog=BusinessInfoSystem;Integrated Security=True";
            return ConStr;
        }
        private string NewCOACode(COAModel model)
        {
            //  01-01-001-001-0001 sample Code
            if (model.leveltype == '2')
            {

                model.L2Code = Db.CoaL2.Where(a => a.L1Code.Equals(model.L1Code)).Max(a => a.L2Code) ?? "0";
                if (!string.IsNullOrEmpty(model.L2Code))
                {
                    int newcode = 0;
                    if (model.L2Code != "0")
                    {
                        newcode = Convert.ToInt32(model.L2Code.Substring(3));
                    }
                    newcode = newcode + 1;
                    model.L2Code = model.L1Code + "-" + newcode.ToString().PadLeft(2, '0');
                }

                return model.L2Code;
            }
            else if (model.leveltype == '3')
            {
                model.L3Code = Db.CoaL3.Where(a => a.L2Code.Equals(model.L2Code)).Max(a => a.L3Code) ?? "0";
                if (!string.IsNullOrEmpty(model.L3Code))
                {
                    int newcode = 0;
                    if (model.L3Code != "0")
                    {
                        newcode = Convert.ToInt32(model.L3Code.Substring(6));
                    }
                    newcode = newcode + 1;
                    model.L3Code = model.L2Code + "-" + newcode.ToString().PadLeft(3, '0');
                }

                return model.L3Code;
            }
            else if (model.leveltype == '4')
            {

                model.L4Code = Db.CoaL4.Where(a => a.L3Code.Equals(model.L3Code)).Max(a => a.L4Code) ?? "0";
                if (!string.IsNullOrEmpty(model.L4Code))
                {
                    int newcode = 0;
                    if (model.L4Code != "0")
                    {
                        newcode = Convert.ToInt32(model.L4Code.Substring(10));
                    }
                    newcode = newcode + 1;
                    model.L4Code = model.L3Code + "-" + newcode.ToString().PadLeft(3, '0');
                }

                return model.L4Code;
            }
            else if (model.leveltype == '5')
            {

                model.L5Code = Db.CoaL5.Where(a => a.L4Code.Equals(model.L4Code)).Max(a => a.L5Code) ?? "0";
                if (!string.IsNullOrEmpty(model.L5Code))
                {
                    int newcode = 0;
                    if (model.L5Code != "0")
                    {
                        newcode = Convert.ToInt32(model.L5Code.Substring(14));
                    }
                    newcode = newcode + 1;
                    model.L5Code = model.L4Code + "-" + newcode.ToString().PadLeft(4, '0');
                }
                return model.L5Code;
            }


            return "";
        }
        public JsonResult Users()
        {
            var userslist = importdb.UMUsers;
            User newUmUser;
            foreach (var user in userslist)
            {
                newUmUser = new User();
                newUmUser.UserName = user.LoginID;
                newUmUser.Email = user.UserID;
                newUmUser.Password = user.LoginID;
                newUmUser.FirstName = user.UserDescription;
                newUmUser.LastName = string.Empty;
                newUmUser.DateOfBirth = Convert.ToDateTime(user.PasswordExipreDate);
                newUmUser.EmployeeId = 0;
                newUmUser.Gender = 0;
                newUmUser.ContactNumber = "0";
                newUmUser.ChangePasswordWhenLogon = user.UserMustChangePassword == "Y" ? true : false;
                newUmUser.PasswordNeverExpire = user.PasswordNeverExpire == "Y" ? true : false;
                newUmUser.IncludedCEOInEmail = user.IncludeCEO == "Y" ? true : false;
                newUmUser.ExpiresOn = Convert.ToDateTime(user.PasswordExipreDate);
                newUmUser.IsAdmin = (bool)user.IsAdmin;
                newUmUser.IsManagmentRepresentative = (bool)user.isMR;
                newUmUser.IsActive = Convert.ToBoolean(user.Status == "A" ? 1 : 0);
                newUmUser.CreatedOn = user.CreatedOn;
                newUmUser.ModifiedOn = Convert.ToDateTime(user.Modifiedon != null ? user.Modifiedon : DateTime.Now);

                newUmUser.CreatedBy = LoggedinUser.LoggedInUser.CreatedBy;
                newUmUser.ModifiedBy = LoggedinUser.LoggedInUser.ModifiedBy;



                Db.Users.Add(newUmUser);
                Db.SaveChanges();
            }

            return null;
        }

        public JsonResult Department()
        {
            HrDepartmentRepository hrDepartmentRepository = new HrDepartmentRepository();
            var departemtlist = importdb.CompanyDepartments.Where(a => a.CompanyID.Equals("001"));
            HrDepartment newDepartment;
            foreach (var dept in departemtlist)
            {
                newDepartment = new HrDepartment();
                newDepartment.Title = dept.DeptDescription;
                newDepartment.CreatedOn = (DateTime)dept.DeptCreatedOn;
                newDepartment.ModifiedOn = (DateTime)dept.DeptCreatedOn;
                newDepartment.CreatedBy = LoggedinUser.LoggedInUser.CreatedBy;
                newDepartment.ModifiedBy = LoggedinUser.LoggedInUser.ModifiedBy;
                hrDepartmentRepository.Add(newDepartment);
            }
            return null;
        }
        public JsonResult Employee()
        {
            HrEmployeeRepository hrEmployeeRepository = new HrEmployeeRepository();
            var employeelist = importdb.HR_Employee;
            HrEmployee newEmployee;
            foreach (var emp in employeelist)
            {
                newEmployee = new HrEmployee();
                newEmployee.Title = emp.FirstName;
                newEmployee.CreatedOn = (DateTime)emp.CreatedOn;
                newEmployee.ModifiedOn = Convert.ToDateTime(emp.ModifiedOn != null ? emp.ModifiedOn : DateTime.Now);
                newEmployee.CreatedBy = LoggedinUser.LoggedInUser.CreatedBy;
                newEmployee.ModifiedBy = LoggedinUser.LoggedInUser.ModifiedBy;
                hrEmployeeRepository.Add(newEmployee);
            }

            return null;
        }
        public void Create()
        {
            string voucherExeption= string.Empty;
           
            try
            {
                var oldvoucher = importdb.GL_VoucherMaster.Where(a => a.CompanyID.Equals("001") && a.FiscalYearID.Equals("0029") && a.VoucherTypeID.Equals(4)/*&& a.FiscalPeriodID.Equals("0241")&& a.VoucherNo==50*/).OrderBy(a => a.FiscalPeriodID).ThenBy(a => a.VoucherNo).ToList();
                FinVoucherRepository voucherRepo = new FinVoucherRepository();
                List<FinVoucherDetail> lst = new List<FinVoucherDetail>();
                FinVoucher model = new FinVoucher();
                FinVoucherDetail voucherDetail = new FinVoucherDetail();
                foreach (var item in oldvoucher)
                {
                    model = new FinVoucher();
                    model.VoucherNo = Convert.ToInt32(item.VoucherNo);
                    if (item.VoucherNo == 1)
                    {
                        string a = string.Empty;
                    }
                    voucherExeption = string.Empty;
                    voucherExeption = item.VoucherNo + "--" + item.FiscalPeriodID + "-" + item.VoucherID;
                    var month = importdb.GL_FiscalPeriod.Where(b => b.FiscalPeriodID.Equals(item.FiscalPeriodID)).FirstOrDefault().FiscalPeriodDescription.Trim();
                    var newmonth = Db.FinFescalYearDetail.ToList().Where(a => a.Title.Trim() == month).FirstOrDefault();
                    model.FescalMonth = Convert.ToString(newmonth.Id);
                    model.Vtype = "005";
                    model.VoucherDate = item.Voucherdate;
                    model.CheqNo = item.ChqNo;
                    model.PostedDate = Convert.ToDateTime(item.ApprovedOn != null ? item.ApprovedOn : DateTime.Now); 
                    model.CreateUserId = 1;
                    model.CreateDate = item.Createdon;
                    model.ModifiedOn = Convert.ToDateTime(item.ModifiedOn != null ? item.ModifiedOn : DateTime.Now);
                    model.TotalDebit = item.TotalDebit;
                    model.TotalCredit = item.TotalCredit;
                    model.Detail = item.Reference;
                    model.IsEdited = false;
                    model.IsPosted = true;
                    model.IsVerified = true;
                    model.dtDetail = "-";
                    model.AccountCode = "-";
                    lst = new List<FinVoucherDetail>();

                    var voucherdetail = importdb.GL_VoucherDetails.Where(a => a.VoucherID.Equals(item.VoucherID)).ToList();
                    if (voucherdetail.Count > 0)
                    {
                        foreach (var detail in voucherdetail)
                        {
                            voucherDetail = new FinVoucherDetail();
                            var oldegl = importdb.GL_COA.Where(b => b.AccountID.Equals(detail.AccountID)).FirstOrDefault().AccountTitle.Trim();
                            voucherDetail.GlCode = Db.CoaL5.ToList().Where(a => a.Title.Trim().Equals(oldegl)).FirstOrDefault().L5Code;
                        
                            if (!string.IsNullOrEmpty(detail.Narration))
                                voucherDetail.Detail = detail.Narration;
                            else
                            {
                                voucherDetail.Detail = "-";
                            }
                            if (!string.IsNullOrEmpty(item.ChqDate.ToString()))
                            {
                                voucherDetail.ChequeDate = Convert.ToDateTime(item.ChqDate);
                            }
                            else
                            {
                                voucherDetail.ChequeDate = DateTime.Now;
                            }
                            voucherDetail.ClearingDate = voucherDetail.ChequeDate;
                            voucherDetail.Debit = detail.Debit;
                            voucherDetail.Credit = detail.Credit;
                            voucherDetail.ChequeNo = item.ChqNo;
                            if (!string.IsNullOrEmpty(detail.Department))
                            {
                                var oldDepartemnt = importdb.CompanyDepartments.Where(b => b.DepartmentID.Equals(detail.Department)).FirstOrDefault().DeptDescription.Trim();
                                voucherDetail.DeptId =Convert.ToInt32(Db.HrDepartments.Where(a => a.Title.Trim().Equals(oldDepartemnt)).FirstOrDefault().id);
                            }
                            if (!string.IsNullOrEmpty(detail.Employee))
                            {
                                var oldemp = importdb.HR_Employee.Where(b => b.EmployeeID.Equals(detail.Employee)).FirstOrDefault().FirstName.Trim();
                                voucherDetail.EmpId = Convert.ToInt32(Db.HrEmployee.Where(a =>a.Title.Trim().Equals(oldemp)).FirstOrDefault().Id);
                            } // voucherDetail.CustomerId = Convert.ToInt32(Db.HrDepartments.Where(a => a.Title.Equals(importdb.CompanyDepartments.Where(b => b.DepartmentID.Equals(detail.Department)).FirstOrDefault())).FirstOrDefault().id);
                            if (!string.IsNullOrEmpty(detail.Location))
                            {
                                var oldloc = importdb.CC_City.Where(b => b.CityID.Trim().Contains(detail.Location.Trim())).FirstOrDefault().CityName.Trim();
                                voucherDetail.LocId = Convert.ToInt32(Db.City.Where(a => a.Name.Trim().Equals(oldloc)).FirstOrDefault().Id);

                            }

                            lst.Add(voucherDetail);
                        }

                    }
                    if(lst.Count>0)
                    voucherRepo.Add(model, lst);
                }
            }
            catch (Exception e)
            {
                string error = voucherExeption;
            }
        }


    }


}
