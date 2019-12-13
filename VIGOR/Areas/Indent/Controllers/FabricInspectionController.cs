using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ERP.Core.IRepositories.Indenting.IndentDomestic;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Indenting.Inspection;

namespace VIGOR.Areas.Indent.Controllers
{
    public class FabricInspectionController : Controller
    {
        private FabricInspReportLocalRepository _fabricInspReportLocalRepository;
        private IIndDomesticRepository _indDomesticRepository;
        private IndDomesticDispatchScheduleRepository _indDomesticDispatchScheduleRepository;
        private IndentInspectionRepository _indentInspectionRepository;

        public FabricInspectionController()
        {
            _fabricInspReportLocalRepository = new FabricInspReportLocalRepository();
            _indDomesticRepository = new IndDomesticRepository();
            _indDomesticDispatchScheduleRepository=new IndDomesticDispatchScheduleRepository();
            _indentInspectionRepository = new IndentInspectionRepository();
        }
        // GET: Indent/FabricInspection
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Int32? sellerId,Int32? buyerId,string reportNo, DateTime? fromDate, DateTime? toDate,
            Int32? inspectionType,Int32? reportStandard, string indenttNo)
        {
            ViewBag.FabricInspection = _fabricInspReportLocalRepository.GetAllFabricInspReportLocal()
                .Where(a => a.FabInspTypeId.Equals(inspectionType) || inspectionType.Equals(0) || inspectionType.Equals(null))
                .Where(a => a.IndentKey.Equals(indenttNo) || indenttNo.Equals(string.Empty))
                .Where(a => a.InspectionDate >= fromDate && a.InspectionDate <= toDate);
            ViewBag.FromDate = fromDate;
            ViewBag.Todate = toDate;
            return View();
        }
        //[HttpGet]
        //public ActionResult Attachment(int Id)
        //{
        //    var inspection = _fabricInspReportLocalRepository.FindById(Id);
        //    var indInsp = _indentInspectionRepository.GetAllIndInspection()
        //        .Where(a => a.IndentId == inspection.IndentId).ToList();
        //    var indDomestics = _indDomesticRepository.GetAllIndDomectic().Where(a => a.CustomerIDasSeller == inspection. && a.CommodityTypeId == inspection.CommodityId).ToList();

        //    foreach (var item in indDomestics)
        //    {
        //        foreach (var indentInspection in indInsp)
        //        {
        //            if (item.Id == indentInspection.IndentId)
        //            {
        //                item.IsAllow = true;
        //            }
        //        }
        //    }

        //    ViewBag.indDomestics = indDomestics;

        //    return View(inspection);
        //}
        //[HttpPost]
        //public ActionResult Attachment(YarnInspection model)
        //{
        //    model = _inspectionRepository.FindById(model.Id);

        //    IndentInspection indentInspection;
        //    var indentInspectionKeysList = new List<string>();
        //    foreach (var k in Request.Form.Keys)
        //    {
        //        if (k.ToString().Contains("isAllow"))
        //            indentInspectionKeysList.Add(k.ToString());
        //    }
        //    foreach (var Key in indentInspectionKeysList)
        //    {
        //        var index = "0";
        //        index = Key.Replace("][isAllow]", "");
        //        index = index.Replace("det[", "");
        //        if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][isAllow]"))
        //        {
        //            indentInspection = new IndentInspection();
        //            if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][isAllow]"]))
        //            {
        //                indentInspection.IndentKey = (Request.Form["det[" + index + "][Contract]"]);
        //                indentInspection.SalesContractDetail = (Request.Form["det[" + index + "][DetailId]"]);
        //                indentInspection.CommodityTypeId = model.CommodityId;
        //                indentInspection.IndentId = model.IndentId;// model.SalesContractDetailID
        //                indentInspection.InspSrno = model.InspectionSerialID;
        //                indentInspection.LocalDispatchKey = model.IndentDomestic.IndentKey;
        //                indentInspection.DispatchId = 27;
        //            }
        //            try
        //            {
        //                _indentInspectionRepository.Add(indentInspection);
        //            }
        //            catch (Exception e)
        //            {
        //            }
        //        }
        //    }
        //    return null;
        //}
        public JsonResult GetDispatches(int id)
        {
            var data = _indDomesticDispatchScheduleRepository.GetAllIndDomesticDispatchSchedule().Where(a=>a.IndentId==id && a.TypeOfTransaction=="D").ToList();
            var collection = data.Select(x => new
            {
                date = x.TransDate,
                quantity = x.Quantity,
                commodity = x.Product.Description
            }).ToList();
            return Json(new { data = collection }, JsonRequestBehavior.AllowGet);
        }
        // GET: Indent/FabricInspection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/FabricInspection/Create
        public ActionResult Create()
        {
            FabricInspReportLocal modeLocal = new FabricInspReportLocal();
            modeLocal.InspRepoSr = _fabricInspReportLocalRepository.GetFabInspSerialID();
            return View(modeLocal);
        }

        // POST: Indent/FabricInspection/Create
        [HttpPost]
        public ActionResult Create(FabricInspReportLocal modeLocal)
        {
            _indDomesticRepository=new IndDomesticRepository();
            try
            {
                modeLocal.Camdirection = "test";
                modeLocal.InspCalculationBasedOn = "a";
                modeLocal.ForMarket = "L";
                modeLocal.FabInspStandardId = 1;
                modeLocal.CompanyId = LoggedinUser.Company.Id;
                modeLocal.CompanyKey = LoggedinUser.Company.Id.ToString().PadLeft(3,'0');
                modeLocal = GetRollsRessults(modeLocal);
                ModelState.Remove("IndentKey");
                ModelState.Remove("ForMarket");
                ModelState.Remove("InspCalculationBasedOn");
                ModelState.Remove("Camdirection");
                if (!(modeLocal.IndentId > 0))
                {
                    ModelState.AddModelError("", "Please Select Indent");
                    return View(modeLocal);
                }
                if (ModelState.IsValid)
                {
                    modeLocal.IndentKey = _indDomesticRepository.FindById(modeLocal.IndentId).IndentKey;
                    modeLocal.CreatedOn = DateTime.Now;
                    modeLocal.ModifiedOn = DateTime.Now;
                    modeLocal.firstLine = DateTime.Now;
                    modeLocal.secondLine = DateTime.Now;
                    _fabricInspReportLocalRepository.Add(modeLocal);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(modeLocal);
                }
            }
            catch (Exception e)
            {
                return View(modeLocal);
            }
        }

        private FabricInspReportLocal GetRollsRessults(FabricInspReportLocal modeLocal)
        {
            FabricInspReportLocalDetail fabricInspReportLocalDetail;
            var gridKeysList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("SrNo"))
                    gridKeysList.Add(k.ToString());
                
            }
            foreach (var Key in gridKeysList)
            {
                var index = "0";
                index = Key.Replace("][SrNo]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][SrNo]"))
                {
                    fabricInspReportLocalDetail = new FabricInspReportLocalDetail();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][SrNo]"]))
                    {

                        fabricInspReportLocalDetail.InspRepoSr = Request.Form["det[" + index + "][SrNo]"];
                        fabricInspReportLocalDetail.RollOn = Convert.ToInt32(Request.Form["det[" + index + "][RollNo]"]);
                        fabricInspReportLocalDetail.NoteMeters = Convert.ToInt32(Request.Form["det[" + index + "][NotedMeters]"]);
                        fabricInspReportLocalDetail.ActualMeters = Convert.ToInt32(Request.Form["det[" + index + "][ActualMeters]"]);
                        fabricInspReportLocalDetail.SlubsKnotes = Convert.ToInt32(Request.Form["det[" + index + "][Slubknots]"]);
                        fabricInspReportLocalDetail.PolyYarnBlue = Convert.ToInt32(Request.Form["det[" + index + "][Warp1]"]);
                        fabricInspReportLocalDetail.PolyYarnRed = Convert.ToInt32(Request.Form["det[" + index + "][Weft1]"]);
                        fabricInspReportLocalDetail.Holes = Convert.ToInt32(Request.Form["det[" + index + "][Holes]"]);
                        fabricInspReportLocalDetail.MissPack1 = Convert.ToInt32(Request.Form["det[" + index + "][One5]"]);
                        fabricInspReportLocalDetail.MissPack2 = Convert.ToInt32(Request.Form["det[" + index + "][Two6]"]);
                        fabricInspReportLocalDetail.MissPack3 = Convert.ToInt32(Request.Form["det[" + index + "][Three7]"]);
                        fabricInspReportLocalDetail.MissPack4 = Convert.ToInt32(Request.Form["det[" + index + "][Four8]"]);
                        fabricInspReportLocalDetail.ThickDoublePick = Convert.ToInt32(Request.Form["det[" + index + "][Three1]"]);
                        fabricInspReportLocalDetail.ThickDoublePick2 = Convert.ToInt32(Request.Form["det[" + index + "][Ten2]"]);
                        fabricInspReportLocalDetail.ThickDoublePick3 = Convert.ToInt32(Request.Form["det[" + index + "][Eleven3]"]);
                        fabricInspReportLocalDetail.ThickDoublePick4 = Convert.ToInt32(Request.Form["det[" + index + "][Twelve4]"]);
                        fabricInspReportLocalDetail.WeftBar = Convert.ToInt32(Request.Form["det[" + index + "][WeftBar]"]);
                        fabricInspReportLocalDetail.LooseEndsThickEnds1 = Convert.ToInt32(Request.Form["det[" + index + "][Fourteen1]"]);
                        fabricInspReportLocalDetail.LooseEndsThickEnds2 = Convert.ToInt32(Request.Form["det[" + index + "][Fifteen2]"]);
                        fabricInspReportLocalDetail.LooseEndsThickEnds3 = Convert.ToInt32(Request.Form["det[" + index + "][Sixteen3]"]);
                        fabricInspReportLocalDetail.LooseEndsThickEnds4 = Convert.ToInt32(Request.Form["det[" + index + "][Seventeen4]"]);
                        fabricInspReportLocalDetail.ReedMarkBrokenEndsWrap1 = Convert.ToInt32(Request.Form["det[" + index + "][EightOne]"]);
                        fabricInspReportLocalDetail.ReedMarkBrokenEndsWrap2 = Convert.ToInt32(Request.Form["det[" + index + "][Ninteen2]"]);
                        fabricInspReportLocalDetail.ReedMarkBrokenEndsWrap3 = Convert.ToInt32(Request.Form["det[" + index + "][Twenty3]"]);
                        fabricInspReportLocalDetail.ReedMarkBrokenEndsWrap4 = Convert.ToInt32(Request.Form["det[" + index + "][TwOn4]"]);
                        fabricInspReportLocalDetail.TotalPointsPerRoll = Convert.ToInt32(Request.Form["det[" + index + "][TPointRoll]"]);
                        fabricInspReportLocalDetail.Points100SqYards = Convert.ToInt32(Request.Form["det[" + index + "][PointsSqy]"]);
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][FabricGrade]"]))
                        {
                            fabricInspReportLocalDetail.FabricGrade = Convert.ToChar(Request.Form["det[" + index + "][FabricGrade]"]);
                        }
                        else
                        {
                            fabricInspReportLocalDetail.FabricGrade = '-';
                        }

                        fabricInspReportLocalDetail.ActualWidth = Convert.ToInt32(Request.Form["det[" + index + "][ActualWidth]"]);
                        fabricInspReportLocalDetail.Ends = Convert.ToInt32(Request.Form["det[" + index + "][Ends]"]);
                        fabricInspReportLocalDetail.Pick = Convert.ToInt32(Request.Form["det[" + index + "][Pick]"]);
                        fabricInspReportLocalDetail.NoOfCutFault = Convert.ToInt32(Request.Form["det[" + index + "][CutFaults]"]);
                        fabricInspReportLocalDetail.MildWetBar = Convert.ToInt32(Request.Form["det[" + index + "][MildWeft]"]);
                        fabricInspReportLocalDetail.SmallslubKnotes = Convert.ToInt32(Request.Form["det[" + index + "][SmallSlubKnits]"]);
                        fabricInspReportLocalDetail.ActualGramSqr = Convert.ToInt32(Request.Form["det[" + index + "][TotalPoints]"]);

                        modeLocal.FabricInspReportLocalDetails.Add(fabricInspReportLocalDetail);
                    }
                }
            }
            return modeLocal;
        }

        // GET: Indent/FabricInspection/Edit/5
        public ActionResult Edit(int id)
        {
            var zed = _fabricInspReportLocalRepository.FindById(id);
            return View(_fabricInspReportLocalRepository.FindById(id));
        }

        // POST: Indent/FabricInspection/Edit/5
        [HttpPost]
        public ActionResult Edit(FabricInspReportLocal modeLocal)
        {
            _indDomesticRepository = new IndDomesticRepository();
            try
            {
                modeLocal = GetRollsRessults(modeLocal);
                ModelState.Remove("IndentKey");
                ModelState.Remove("ForMarket");
                ModelState.Remove("InspCalculationBasedOn");
                ModelState.Remove("Camdirection");
                if (!(modeLocal.IndentId > 0))
                {
                    ModelState.AddModelError("","Please Select Indent");
                    return View(modeLocal);
                }
                if (ModelState.IsValid)
                {
                    modeLocal.ModifiedOn = DateTime.Now;
                    _fabricInspReportLocalRepository.Add(modeLocal);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(modeLocal);
                }
            }
            catch (Exception e)
            {
                return View(modeLocal);
            }
        }

        // GET: Indent/FabricInspection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/FabricInspection/Delete/5
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