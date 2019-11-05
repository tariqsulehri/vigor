using ERP.Core.IRepositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;
using ERP.Core.Models.Indenting.viewModels;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class DeptDealsInCommodityTypeRepository : IDeptDealsInCommodityTypeRepository
    {

        private ErpDbContext db;

        public DeptDealsInCommodityTypeRepository()
        {
            db = new ErpDbContext();    
        }
        public void Add(DeptDealsInCommodityType deptDealsInCommodityType)
        {
            db.DeptDealsInCommodityType.Add(deptDealsInCommodityType);
            db.SaveChanges();
        }

       public void Edit(DeptDealsInCommodityType deptDealsInCommodityType)
       {
            try
            {
                var existingRecord = db.DeptDealsInCommodityType.Find(deptDealsInCommodityType.id);
                db.Entry(existingRecord).CurrentValues.SetValues(deptDealsInCommodityType);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public DeptDealsInCommodityType FindByKey(string key)
        {
            DeptDealsInCommodityType c = db.DeptDealsInCommodityType.Find(key);
            return c;
        }

        public IEnumerable<DeptDealsInCommodityType> GetAllCommodityTypeByDepartment(int deptID)
        {
            var result = db.DeptDealsInCommodityType.Where(x=> x.DepartmentId == deptID).ToList();
            return result;
        }

        public IEnumerable<DeptDealsInCommodityType> GetAllDepartmentsByCommodityTypes(int commodityTypeID)
        {
            var result = db.DeptDealsInCommodityType.Where(x => x.CommodityType == x.CommodityType).ToList();
            return result;
        }

        public IEnumerable<DeptDealsInCommodityType> GetAllDeptDealsInCommodityTypes()
        {
            return db.DeptDealsInCommodityType.ToList();
        }

        public DeptDealsInCommodityType GetAllDeptDealsInCommodityTypesByKey(string mKey)
        {
            var result = db.DeptDealsInCommodityType.SingleOrDefault(x => x.mkey == mKey);
            return result;
        }
        
        public bool IsDuplicate(DeptDealsInCommodityType deptDealsInCommodityType)
        {
            int cnt = 0;
            if (deptDealsInCommodityType.mkey != string.Empty)
            {
                cnt = db.DeptDealsInCommodityType.Count(x => x.mkey == deptDealsInCommodityType.mkey);
                
            }

            if (cnt >= 1)
            {
                return true;
            }

            return false;
        }

        public IList<CommodityBaseDepartments_VM> GetCommodityTypeByUserId(int UserId)
        {
            var userId = new SqlParameter("@UserId", UserId);

            IList<CommodityBaseDepartments_VM> commodityBaseDepartments_VM = db.Database.SqlQuery<CommodityBaseDepartments_VM>("SP_GetCommodityTypeByUserId @UserId", userId).ToList();
            return commodityBaseDepartments_VM;

        }

        public IList<CommodityBaseDepartments_VM> SP_GetDepartmentByCommodityTypeAndUserId(int UserId, int CommodityTypeId, int MarkeetId)
        {
            var userId = new SqlParameter("@UserId", UserId);
            var commodityTypeId = new SqlParameter("@CommodityTypeId", CommodityTypeId);
            var markeetId = new SqlParameter("@DealsInId", MarkeetId);

            IList<CommodityBaseDepartments_VM> commodityBaseDepartments_VM = db.Database.SqlQuery<CommodityBaseDepartments_VM>("SP_GetDepartmentByCommodityTypeAndUserId @CommodityTypeId,@DealsInId,@UserId", commodityTypeId, markeetId, userId).ToList();
            return commodityBaseDepartments_VM;

        }



        public IList<CommodityBaseDepartments_VM> SP_MarkeetByDepartmentAndUserId(int UserId, int DeptId)
        {
            var userId = new SqlParameter("@UserId", UserId);
            var deptId = new SqlParameter("@deptId", DeptId);

            IList<CommodityBaseDepartments_VM> commodityBaseDepartments_VM = db.Database.SqlQuery<CommodityBaseDepartments_VM>("SP_GetDepartmentByCommodityTypeAndUserId @UserId @DeptId", userId, deptId).ToList();
            return commodityBaseDepartments_VM;

        }


        public bool Remove(DeptDealsInCommodityType deptDealsInCommodityType)
        {
            var existingRecord = db.DeptDealsInCommodityType.SingleOrDefault(x => x.mkey == deptDealsInCommodityType.mkey); 

            if (existingRecord != null)
            {
                db.DeptDealsInCommodityType.Remove(existingRecord);
            }

            if (db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }

        public bool Delete(DeptDealsInCommodityType deptDealsInCommodityType)
        {
            using (var context = db.Database.BeginTransaction())
            {
                try
                {
                    var cmdDeleteDeptDealsInCommodityTypes = ("Delete  from DeptDealsInCommodityTypes" +
                                                              " where DepartmentId =" + deptDealsInCommodityType.DepartmentId);
                    db.Database.ExecuteSqlCommand(cmdDeleteDeptDealsInCommodityTypes);
                    var cmdDetailDeptDealsInMarkeets = ("delete from DeptDealsInMarkeets" +
                                                        " where DepartmentId = " + deptDealsInCommodityType.DepartmentId);
                    db.Database.ExecuteSqlCommand(cmdDetailDeptDealsInMarkeets);
                    db.SaveChanges();
                    context.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    context.Rollback();
                    Console.WriteLine(e);
                    return false;
                    throw;
                }

            }
        }
    }
}
