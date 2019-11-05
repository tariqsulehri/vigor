using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class CustomerController : Controller
    {
        private FinPartyRepository _finPartyRepository;
        public CustomerController()
        {
            _finPartyRepository = new FinPartyRepository();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            FinParty model= new FinParty();
            model.Active = true;
            return View(model);
        }

        // POST: Customer/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(FinParty model)
        {
            model.CreatedBy = 0;
            model.ModifiedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;

            try
            {
                if (_finPartyRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                model = GetCustomerDetails(model);
                ModelState.Remove("GlCode");
                if (ModelState.IsValid)
                {
                    if (!model.IsGlCustomer)
                    {
                        model.GlCode = "20-02-002-002-0000";}
                    _finPartyRepository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception s)
            {
                return View(model);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var a = _finPartyRepository.FindById(id);
            if (a.GlCode != "20-02-002-002-0000")
                a.IsGlCustomer = true;
            return View(a);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(FinParty model)
        {
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_finPartyRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                model = GetCustomerDetails(model);
                ModelState.Remove("GlCode");
                if (ModelState.IsValid)
                {
                    if (!model.IsGlCustomer)
                    {
                        model.GlCode = "20-02-002-002-0000";
                    }
                    _finPartyRepository.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            _finPartyRepository.Remove(id);
            return null;
        }

        // POST: Customer/Delete/5
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
        [HttpGet]
        public ActionResult GetCustomer(bool active)
        {
            var Year = _finPartyRepository.GetAllParties().ToList().Where(a => a.Active == active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                company = x.CompanyName,
                active = x.Active ? "Active" : "InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CustomerDispatch(int SalerID)
        {
            var cust = _finPartyRepository.FindById(SalerID);
            return Json("Dispatch To: " + cust.DispatchAddress, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintCustomer(bool active)
        {
            var data = _finPartyRepository.GetAllParties().ToList().Where(a => a.Active == active);
            if (data.Count() > 0)
                return View(data);
            else
                return RedirectToAction("Index");
            //return null;
        }

        private FinParty GetCustomerDetails(FinParty finParty)
        {
            CustomerContact _customercontact;
            CustomerBrand _customerBrand;
            CustomerUnit _customerUnit;
            CustomerContactPerson _customerContactPerson;
            CustomerMachine _customerMachine;
            CustomerCertification _customerCertification;
            CustomerSocial _customerSocial;
            CustomerInstruction _customerInstruction;

            var contTypeList = new List<string>();
            var gridBrandList = new List<string>();
            var gridUnitList = new List<string>();
            var gridCustomerContactPersonList = new List<string>();
            var gridCustomerMachineList = new List<string>();
            var gridCustomerCertificationList = new List<string>();
            var gridCustomerSocialList = new List<string>();
            var gridCustomerInstructionList = new List<string>();

            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("ContTypeId"))
                    contTypeList.Add(k.ToString());
                if (k.ToString().Contains("brand"))
                    gridBrandList.Add(k.ToString());
                if (k.ToString().Contains("unit"))
                    gridUnitList.Add(k.ToString());
                if (k.ToString().Contains("contact"))
                    gridCustomerContactPersonList.Add(k.ToString());
                if (k.ToString().Contains("machinery"))
                    gridCustomerMachineList.Add(k.ToString());
                if (k.ToString().Contains("certificate"))
                    gridCustomerCertificationList.Add(k.ToString());
                if (k.ToString().Contains("social"))
                    gridCustomerSocialList.Add(k.ToString());
                if (k.ToString().Contains("instruction"))
                    gridCustomerInstructionList.Add(k.ToString());
            }
            try
            {
                foreach (var Key in contTypeList)
                {
                    var index = "0";
                    index = Key.Replace("][ContTypeId]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][ContTypeId]"))
                    {
                        _customercontact = new CustomerContact();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][ContTypeId]"]))
                        {

                            _customercontact.ContTypeId = Convert.ToInt32(Request.Form["det[" + index + "][ContTypeId]"]);
                            _customercontact.ContactNumber = (Request.Form["det[" + index + "][Number]"]);
                            _customercontact.PartyId = finParty.Id;
                            try
                            {
                                finParty.CustomerContactType.Add(_customercontact);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in gridBrandList)
                {
                    var index = "0";
                    index = Key.Replace("][brand]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][brand]"))
                    {
                        _customerBrand = new CustomerBrand();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][brand]"]))
                        {

                            _customerBrand.BrandName = Request.Form["det[" + index + "][brand]"];
                            _customerBrand.IsActive = ((Request.Form["det[" + index + "][bIsActive]"]) == "1");
                            _customerBrand.CreatedOn = DateTime.Now;
                            _customerBrand.ModifiedOn = DateTime.Now;
                            _customerBrand.ModifiedBy = 0;
                            _customerBrand.PartyId = finParty.Id;
                            _customerBrand.mKey = "-";
                            try
                            {
                                finParty.CustomerBrands.Add(_customerBrand);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in gridUnitList)
                {
                    var index = "0";
                    index = Key.Replace("][unit]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][unit]"))
                    {
                        _customerUnit = new CustomerUnit();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][unit]"]))
                        {

                            _customerUnit.UnitTitle = Request.Form["det[" + index + "][unit]"];
                            _customerUnit.IsActive = ((Request.Form["det[" + index + "][uIsActive]"]) == "1");
                            _customerUnit.CreatedOn = DateTime.Now;
                            _customerUnit.ModifiedOn = DateTime.Now;
                            _customerUnit.ModifiedBy = 0;
                            _customerUnit.PartyId = finParty.Id;
                            _customerUnit.mKey = "-";
                            _customerUnit.Details = "-";
                            _customerUnit.Address = "-";
                            _customerUnit.Phone = "-";
                            _customerUnit.PersonEmail = "-";
                            _customerUnit.ContactPersonPhone = "-";

                            try
                            {
                                finParty.CustomerUnits.Add(_customerUnit);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in gridCustomerContactPersonList)
                {
                    var index = "0";
                    index = Key.Replace("][contact]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][contact]"))
                    {
                        _customerContactPerson = new CustomerContactPerson();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][contact]"]))
                        {
                            _customerContactPerson.ContTypeId = Convert.ToInt32(Request.Form["det[" + index + "][contact]"]);
                            _customerContactPerson.Name = Request.Form["det[" + index + "][Person]"];
                            _customerContactPerson.Jobtitle = Request.Form["det[" + index + "][Jobtitle]"];
                            _customerContactPerson.ContactNumber = Request.Form["det[" + index + "][ContactNumber]"];
                            _customerContactPerson.Email = Request.Form["det[" + index + "][Email]"];
                            _customerContactPerson.CreatedOn = DateTime.Now;
                            _customerContactPerson.ModifiedOn = DateTime.Now;
                            _customerContactPerson.ModifiedBy = 0;
                            _customerContactPerson.PartyId = finParty.Id;

                            finParty.CustomerContactPerson.Add(_customerContactPerson);
                        }

                    }
                }
            }
            catch (Exception e)
            {
            }

            try
            {
                foreach (var Key in gridCustomerMachineList)
                {
                    var index = "0";
                    index = Key.Replace("][machinery]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][machinery]"))
                    {
                        _customerMachine = new CustomerMachine();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][machinery]"]))
                        {
                            //_customerMachine.MId = Convert.ToInt32(Request.Form["det[" + index + "][machinery]"]);
                            _customerMachine.Details = Convert.ToString(Request.Form["det[" + index + "][machinery]"]);
                            _customerMachine.NumOfMachines = Convert.ToInt32(Request.Form["det[" + index + "][NumOfMachines]"]);
                            _customerMachine.IsActive = ((Request.Form["det[" + index + "][IsMachineActive]"]) == "1");
                            //_customerMachine.IsActive = Convert.ToBoolean(Request.Form["det[" + index + "][IsActive]"]);
                            _customerMachine.CreatedOn = DateTime.Now;
                            _customerMachine.ModifiedOn = DateTime.Now;
                            _customerMachine.ModifiedBy = 0;
                            _customerMachine.PartyId = finParty.Id;
                            _customerMachine.mKey = "mKey";
                            _customerMachine.MachineName = "mName";

                            finParty.CustomerMachineses.Add(_customerMachine);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in gridCustomerCertificationList)
                {
                    var index = "0";
                    index = Key.Replace("][certificate]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][certificate]"))
                    {
                        _customerCertification = new CustomerCertification();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][certificate]"]))
                        {
                            _customerCertification.CertifyId = Convert.ToInt32(Request.Form["det[" + index + "][certificate]"]);
                            _customerCertification.IsActive = ((Request.Form["det[" + index + "][IsCertificateActive]"]) == "1");
                            //_customerCertification.IsActive = Convert.ToBoolean(Request.Form["det[" + index + "][IsActive]"]);
                            _customerCertification.IssuedOn = Convert.ToDateTime(Request.Form["det[" + index + "][IssuedOn]"]);
                            _customerCertification.ValidTill = Convert.ToDateTime(Request.Form["det[" + index + "][ValidTill]"]);
                            _customerCertification.PartyId = finParty.Id;

                            finParty.CustomerCertifications.Add(_customerCertification);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in gridCustomerSocialList)
                {
                    var index = "0";
                    index = Key.Replace("][social]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][social]"))
                    {
                        _customerSocial = new CustomerSocial();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][social]"]))
                        {
                            _customerSocial.Sid = Convert.ToInt32(Request.Form["det[" + index + "][social]"]);
                            _customerSocial.Details = Request.Form["det[" + index + "][Details]"];
                            _customerSocial.IsActive = ((Request.Form["det[" + index + "][IsSocialActive]"]) == "1");
                            _customerSocial.CreatedOn = DateTime.Now;
                            _customerSocial.ModifiedBy = 0;
                            _customerSocial.ModifiedOn = DateTime.Now;
                            _customerSocial.PartyId = finParty.Id;
                            finParty.CustomerSocials.Add(_customerSocial);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in gridCustomerInstructionList)
                {
                    var index = "0";
                    index = Key.Replace("][instruction]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][instruction]"))
                    {
                        _customerInstruction = new CustomerInstruction();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][instruction]"]))
                        {
                            _customerInstruction.CiId = Convert.ToInt32(Request.Form["det[" + index + "][instruction]"]);
                            _customerInstruction.Name = Request.Form["det[" + index + "][Name]"];
                            _customerInstruction.IsActive = ((Request.Form["det[" + index + "][IsInstructionActive]"]) == "1");
                            _customerInstruction.CreatedOn = DateTime.Now;
                            _customerInstruction.ModifiedBy = 0;
                            _customerInstruction.ModifiedOn = DateTime.Now;
                            //_customerInstruction.IsActive = Convert.ToBoolean(Request.Form["det[" + index + "][IsActive]"]);
                            _customerInstruction.PartyId = finParty.Id;

                            finParty.CustomerSpecialInstructions.Add(_customerInstruction);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return finParty;
        }
    }
}