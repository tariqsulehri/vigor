using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.viewModels;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using VIGOR.Areas.GL.Models;

namespace VIGOR.Areas.Indent.Controllers
{
    public class CommonIndentController : Controller
    {
        private UnitOfSaleRepository _unitOfSaleRepository;

        public CommonIndentController()
        {
            _unitOfSaleRepository = new UnitOfSaleRepository();
        }
        public JsonResult GetFactorUnitOfSale(int unitID)
        {
            var UOS = _unitOfSaleRepository.FindById(unitID);
            return Json(new { Factor = UOS.Factor, }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDealsinDepartment(int comodityID, int DealsInId)
        {
            try
            {
                DeptDealsInCommodityTypeRepository deptDealsInCommodityTypeRepository = new DeptDealsInCommodityTypeRepository();
                var lst = deptDealsInCommodityTypeRepository.SP_GetDepartmentByCommodityTypeAndUserId(LoggedinUser.LoggedInUser.Id, comodityID, DealsInId);
                var query = from s in lst
                            select new
                            {
                                Id = s.DeptId,
                                Title = s.DepartmentName
                            };
                return Json(query, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { throw ex; }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductByCommodity(int comodityID)
        {
            try
            {
                ProductRepository _product = new ProductRepository();

                var lstProduct = _product.GetAllProduct().Where(a=>a.CommodityId.Equals(comodityID));
                var query = from s in lstProduct
                            select new
                            {
                                Id = s.Id,
                                Title = s.Description
                            };
                return Json(query, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { throw ex; }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}