using ERP.Infrastructure;
using System;
using System.Linq;
using System.Web.Mvc;
using ERP.Core.Models.Finance;
using VIGOR.Areas.GL.Models;
using ERP.Infrastructure.Repositories.FinRepository;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnCOAController : Controller
    {
        // GET: GL/fnCOA
        private ErpDbContext Db = new ErpDbContext();
        CoaL1Repository col1Rep;
        CoaL2Repository col2Rep;
        CoaL3Repository col3Rep;
        CoaL4Repository col4Rep;
        CoaL5Repository col5Rep;


        public fnCOAController()
        {
            col1Rep = new CoaL1Repository();
            col2Rep = new CoaL2Repository();
            col3Rep = new CoaL3Repository();
            col4Rep = new CoaL4Repository();
            col5Rep = new CoaL5Repository();

        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Tree()
        {

            return PartialView("~/Areas/GL/Views/fnCOA/_COATree.cshtml", col1Rep.GetL1Accounts().ToList());
        }
        // GET: GL/fnCOA/Details/5
        public ActionResult Print()
        {
            return View(col1Rep.GetL1Accounts().ToList());
        }

        // GET: GL/fnCOA/Create
        public ActionResult Create(string AccountCode, string Level)
        {
            COAModel model = new COAModel();
            if (!string.IsNullOrEmpty(Level) && Level == "L1")
            {
                CoaL1 coa1 = new CoaL1();
                coa1 = col1Rep.FindById(AccountCode);
                model.L1Code = coa1.L1Code;
                model.L1Title = coa1.Title;
                model.Active = true;
                model.leveltype = '2';
                return PartialView("~/Areas/GL/Views/fnCOA/_COAL2.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L2")
            {
                CoaL2 coa1 = new CoaL2();

                coa1 = col2Rep.FindById(AccountCode);
                model.L1Code = coa1.CoaL1.L1Code;
                model.L1Title = coa1.CoaL1.Title;
                model.L2Code = coa1.L2Code;
                model.L2Title = coa1.Title;
                model.Active = true;
                model.leveltype = '3';

                return PartialView("~/Areas/GL/Views/fnCOA/_COAL3.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L3")
            {
                CoaL3 coa3 = new CoaL3();
                coa3 = col3Rep.FindById(AccountCode);
                model.L1Code = coa3.CoaL2.CoaL1.L1Code;
                model.L1Title = coa3.CoaL2.CoaL1.Title;
                model.L2Code = coa3.CoaL2.L2Code;
                model.L2Title = coa3.CoaL2.Title;
                model.L3Code = coa3.L3Code;
                model.L3Title = coa3.Title;
                model.Active = true;
                model.leveltype = '4';

                return PartialView("~/Areas/GL/Views/fnCOA/_COAL4.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L4")
            {
                CoaL4 coa4 = new CoaL4();
                coa4 = col4Rep.FindById(AccountCode);
                model.L1Code = coa4.CoaL3.CoaL2.CoaL1.L1Code;
                model.L1Title = coa4.CoaL3.CoaL2.CoaL1.Title;
                model.L2Code = coa4.CoaL3.CoaL2.L2Code;
                model.L2Title = coa4.CoaL3.CoaL2.Title;
                model.L3Code = coa4.CoaL3.L3Code;
                model.L3Title = coa4.CoaL3.Title;
                model.L4Code = coa4.L4Code;
                model.L4Title = coa4.Title;
                model.Active = true;
                model.leveltype = '5';
                return PartialView("~/Areas/GL/Views/fnCOA/_COAL5.cshtml", model);
            }
            return View("Index");
        }
        [HttpPost]

        public ActionResult Create(COAModel model)
        {
            try
            {
                if (model.leveltype == '2')
                {
                    model.L2Code = NewCOACode(model);
                    if (!string.IsNullOrEmpty(model.L2Code))
                    {
                        CoaL2 _coaL2 = new CoaL2();
                        _coaL2.Title = model.L2Title;
                        _coaL2.L1Code = model.L1Code;
                        _coaL2.Active = model.Active;
                        if (col2Rep.IsDuplicate(_coaL2))
                        {
                            ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                            return null;
                        }
                        _coaL2.L2Code = model.L2Code;
                        col2Rep.Add(_coaL2);
                    }

                }
                else if (model.leveltype == '3')
                {
                    model.L3Code = NewCOACode(model);
                    if (!string.IsNullOrEmpty(model.L3Code))
                    {
                        CoaL3 _coaL3 = new CoaL3();

                        _coaL3.Title = model.L3Title;
                        _coaL3.L2Code = model.L2Code;
                        _coaL3.Active = model.Active;
                        if (col3Rep.IsDuplicate(_coaL3))
                        {
                            ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                            return null;
                        }
                        _coaL3.L3Code = model.L3Code;
                        col3Rep.Add(_coaL3);
                    }
                }
                else if (model.leveltype == '4')
                {
                    model.L4Code = NewCOACode(model);
                    if (!string.IsNullOrEmpty(model.L4Code))
                    {
                        CoaL4 _coaL4 = new CoaL4();
                        _coaL4.Title = model.L4Title;
                        _coaL4.L3Code = model.L3Code;
                        _coaL4.Active = model.Active;
                        if (col4Rep.IsDuplicate(_coaL4))
                        {
                            ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                            return null;
                        }
                        _coaL4.L4Code = model.L4Code;
                        col4Rep.Add(_coaL4);
                    }
                }
                else if (model.leveltype == '5')
                {
                    model.L5Code = NewCOACode(model);
                    if (!string.IsNullOrEmpty(model.L5Code))
                    {
                        CoaL5 _coaL5 = new CoaL5();
                        _coaL5.Title = model.L5Title;
                        _coaL5.L4Code = model.L4Code;
                        _coaL5.Active = model.Active;
                        _coaL5.BookType = model.BookType;
                        _coaL5.CreatedOn = DateTime.Now;
                        _coaL5.ModifiedOn = DateTime.Now;
                        if (col5Rep.IsDuplicate(_coaL5))
                        {
                            ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                            return null;
                        }
                        _coaL5.L5Code = model.L5Code;
                        col5Rep.Add(_coaL5);
                    }
                }

                return RedirectToAction("Index", "fnCOA", new { Area = "GL" });
            }
            catch (Exception e)
            {
                throw e;
                // return null;
            }
        }


        // GET: GL/fnCOA/Edit/5
        public ActionResult Edit(string AccountCode, string Level)
        {

            COAModel model = new COAModel();
            if (!string.IsNullOrEmpty(Level) && Level == "L1")
            {
                CoaL1 coa1 = new CoaL1();
                coa1 = col1Rep.FindById(AccountCode);
                model.L1Code = coa1.L1Code;
                model.L1Title = coa1.Title;
                model.Active = coa1.Active;
                model.Type = coa1.Type;
                model.CO = coa1.Co;
                model.leveltype = '1';
                return PartialView("~/Areas/GL/Views/fnCOA/_EditCOAL1.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L2")
            {
                CoaL2 coa2 = new CoaL2();
                coa2 = col2Rep.FindById(AccountCode);
                model.L1Code = coa2.CoaL1.L1Code;
                model.L1Title = coa2.CoaL1.Title;
                model.L2Code = coa2.L2Code;
                model.L2Title = coa2.Title;
                model.Active = coa2.Active;
                model.leveltype = '2';

                return PartialView("~/Areas/GL/Views/fnCOA/_EditCOAL2.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L3")
            {
                CoaL3 coa3 = new CoaL3();
                coa3 = col3Rep.FindById(AccountCode);
                model.L1Code = coa3.CoaL2.CoaL1.L1Code;
                model.L1Title = coa3.CoaL2.CoaL1.Title;
                model.L2Code = coa3.CoaL2.L2Code;
                model.L2Title = coa3.CoaL2.Title;
                model.L3Code = coa3.L3Code;
                model.L3Title = coa3.Title;
                model.Active = coa3.Active;
                model.leveltype = '3';
                return PartialView("~/Areas/GL/Views/fnCOA/_EditCOAL3.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L4")
            {
                CoaL4 coa4 = new CoaL4();
                coa4 = col4Rep.FindById(AccountCode);
                model.L1Code = coa4.CoaL3.CoaL2.CoaL1.L1Code;
                model.L1Title = coa4.CoaL3.CoaL2.CoaL1.Title;
                model.L2Code = coa4.CoaL3.CoaL2.L2Code;
                model.L2Title = coa4.CoaL3.CoaL2.Title;
                model.L3Code = coa4.CoaL3.L3Code;
                model.L3Title = coa4.CoaL3.Title;
                model.L4Code = coa4.L4Code;
                model.L4Title = coa4.Title;
                model.Active = coa4.Active;
                model.leveltype = '4';

                return PartialView("~/Areas/GL/Views/fnCOA/_EditCOAL4.cshtml", model);
            }
            if (!string.IsNullOrEmpty(Level) && Level == "L5")
            {
                CoaL5 coa5 = new CoaL5();
                coa5 = col5Rep.FindById(AccountCode);
                model.L1Code = coa5.CoaL4.CoaL3.CoaL2.CoaL1.L1Code;
                model.L1Title = coa5.CoaL4.CoaL3.CoaL2.CoaL1.Title;
                model.L2Code = coa5.CoaL4.CoaL3.CoaL2.L2Code;
                model.L2Title = coa5.CoaL4.CoaL3.CoaL2.Title;
                model.L3Code = coa5.CoaL4.CoaL3.L3Code;
                model.L3Title = coa5.CoaL4.CoaL3.Title;
                model.L4Code = coa5.CoaL4.L4Code;
                model.L4Title = coa5.CoaL4.Title;
                model.L5Code = coa5.L5Code;
                model.L5Title = coa5.Title;
                model.Active = coa5.Active;
                model.BookType = coa5.BookType;
                model.IsDept = coa5.IsDept;
                model.IsLoc = coa5.IsLoc;
                model.IsEmp = coa5.IsEmp;
                model.IsCust = coa5.IsCust;
                model.leveltype = '5';

                return PartialView("~/Areas/GL/Views/fnCOA/_EditCOAL5.cshtml", model);
            }
            return null;

        }

        // POST: GL/fnCOA/Edit/5
        [HttpPost]
        public ActionResult Edit(COAModel model)
        {
            try
            {
                if (model.leveltype == '1' && !string.IsNullOrEmpty(model.L1Code))
                {
                    CoaL1 _coaL1 = new CoaL1();
                    _coaL1.Title = model.L1Title;
                    _coaL1.L1Code = model.L1Code;
                    _coaL1.Active = model.Active;
                    _coaL1.Type = model.Type;
                    _coaL1.Co = model.CO;
                    if (col1Rep.IsDuplicate(_coaL1))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                        return null;
                    }
                    col1Rep.Edit(_coaL1);
                }
                else if (model.leveltype == '2' && !string.IsNullOrEmpty(model.L2Code))
                {
                    CoaL2 _coaL2 = new CoaL2();
                    _coaL2.Title = model.L2Title;
                    _coaL2.L2Code = model.L2Code;
                    _coaL2.L1Code = model.L1Code;
                    _coaL2.Active = model.Active;
                    if (col2Rep.IsDuplicate(_coaL2))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                        return null;
                    }
                    col2Rep.Edit(_coaL2);
                }
                else if (model.leveltype == '3' && !string.IsNullOrEmpty(model.L3Code))
                {
                    CoaL3 _coaL3 = new CoaL3();
                    _coaL3.L3Code = model.L3Code;
                    _coaL3.Title = model.L3Title;
                    _coaL3.L2Code = model.L2Code;
                    _coaL3.Active = model.Active;
                    if (col3Rep.IsDuplicate(_coaL3))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                        return null;
                    }
                    col3Rep.Edit(_coaL3);
                }
                else if (model.leveltype == '4' && !string.IsNullOrEmpty(model.L4Code))
                {
                    CoaL4 _coaL4 = new CoaL4();
                    _coaL4.L4Code = model.L4Code;
                    _coaL4.Title = model.L4Title;
                    _coaL4.L3Code = model.L3Code;
                    _coaL4.Active = model.Active;
                    if (col4Rep.IsDuplicate(_coaL4))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                        return null;
                    }
                    col4Rep.Edit(_coaL4);
                }
                else if (model.leveltype == '5' && !string.IsNullOrEmpty(model.L5Code))
                {
                    CoaL5 _coaL5 = new CoaL5();
                    _coaL5.L5Code = model.L5Code;
                    _coaL5.Title = model.L5Title;
                    _coaL5.L4Code = model.L4Code;
                    _coaL5.Active = model.Active;
                    _coaL5.BookType = model.BookType;

                    _coaL5.IsDept = model.IsDept;
                    _coaL5.IsLoc = model.IsLoc;
                    _coaL5.IsEmp = model.IsEmp;
                    _coaL5.IsCust = model.IsCust;
                    _coaL5.CreatedOn = DateTime.Now;
                    _coaL5.ModifiedOn = DateTime.Now;
                    if (col5Rep.IsDuplicate(_coaL5))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                        return null;
                    }
                    col5Rep.Edit(_coaL5);

                }

                return null;
            }
            catch (Exception ex)
            {
                ex.ToString();

                return null;
            }

        }

        // GET: GL/fnCOA/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/fnCOA/Delete/5
        [HttpPost]
        public ActionResult Delete(COAModel model)
        {
            try
            {
                if (model.leveltype == '1' && !string.IsNullOrEmpty(model.L1Code)) { }
                else if (model.leveltype == '2' && !string.IsNullOrEmpty(model.L2Code))
                { col2Rep.Remove(model.L2Code); }
                else if (model.leveltype == '3' && !string.IsNullOrEmpty(model.L3Code))
                { col3Rep.Remove(model.L3Code); }
                else if (model.leveltype == '4' && !string.IsNullOrEmpty(model.L4Code))
                { col4Rep.Remove(model.L4Code); }
                else if (model.leveltype == '5' && !string.IsNullOrEmpty(model.L5Code))
                { col5Rep.Remove(model.L5Code); }

                return null;
            }
            catch (Exception ex)
            {
                ex.ToString();

                return null;
            }
        }


        private string NewCOACode(COAModel model)
        {
            //  01-01-001-001-0001 sample Code
            if (model.leveltype == '2')
            {

                model.L2Code = Db.CoaL2.Where(a => a.L1Code.Equals(model.L1Code)).Max(a => a.L2Code) ?? "0";
                if (!string.IsNullOrEmpty(model.L2Code) && model.L2Code != "0")
                {
                    int newcode = Convert.ToInt32(model.L2Code.Substring(3));
                    newcode = newcode + 1;
                    model.L2Code = model.L2Code.Substring(0, 3) + newcode.ToString().PadLeft(2, '0');
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



        public JsonResult ChartOfAccount()
        {
            var coa = col1Rep.GetL1Accounts().ToList();
            var collection = coa.Select(a => new
            {
                id = a.L1Code,
                icon = "fa fa-folder icon-lg kt-font-info",
                text = a.Title,
                children = a.Active
            }).ToList();
            return Json(collection, JsonRequestBehavior.AllowGet);
        }
    }
}
