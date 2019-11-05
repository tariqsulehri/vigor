using ERP.Core.IRepositories.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Admin
{
    public class AdminUserDealsInDepartmentRepository : IAdminUserDealsInDepartmentRepository
    {

        ErpDbContext db;
        public AdminUserDealsInDepartmentRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(AdminUserDealsInDepartment adminUserDealsInDepartment)
        {
            db.AdminUserDealsInDepartments.Add(adminUserDealsInDepartment);
            db.SaveChanges();
        }

        public void Edit(AdminUserDealsInDepartment adminUserDealsInDepartment)
        {
            var result = db.AdminUserDealsInDepartments.SingleOrDefault(b => b.Id == adminUserDealsInDepartment.Id);
            if (result != null)
            {
                try
                {
                    // db.AdminUserDealsInDepartment.Attach(AdminUserDealsInDepartment);
                    db.Entry(adminUserDealsInDepartment).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public bool Remove(AdminUserDealsInDepartment adminUserDealsInDepartment)
        {
            //AdminUserDealsInDepartment er = db.AdminUserDealsInDepartments.Find(adminUserDealsInDepartment.Id);
            //if (er != null)
            //{
            //    db.AdminUserDealsInDepartments.Remove(er);
            //}
            var cmdDeleteDeptDealsInCommodityTypes = ("Delete  from AdminUserDealsInDepartments" +
                                                      " where UserId =" + adminUserDealsInDepartment.UserId);
            db.Database.ExecuteSqlCommand(cmdDeleteDeptDealsInCommodityTypes);

            if (db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }


      
        public bool IsDuplicate(AdminUserDealsInDepartment adminUserDealsInDepartment)
        {
            if (adminUserDealsInDepartment.Id == 0)
            {
                return db.AdminUserDealsInDepartments.Any(x => x.mKey == adminUserDealsInDepartment.mKey);
            }

            if (adminUserDealsInDepartment.Id != 0)
            {
                AdminUserDealsInDepartment rc = db.AdminUserDealsInDepartments.FirstOrDefault(x => x.mKey == adminUserDealsInDepartment.mKey);
                if (rc != null && rc.Id != adminUserDealsInDepartment.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public AdminUserDealsInDepartment FindById(int id)
        {
            AdminUserDealsInDepartment so = db.AdminUserDealsInDepartments.Find(id);
            return so;
        }
        public IEnumerable<AdminUserDealsInDepartment> GetAllAdminUserDealsInDepartments()
        {
            return db.AdminUserDealsInDepartments.ToList();
        }

        public IEnumerable<AdminUserDealsInDepartment> GetAllDepartmentsByUser(int UserId)
        {
            List<AdminUserDealsInDepartment> so = db.AdminUserDealsInDepartments.Where(x => x.UserId == UserId).ToList();
            return so; ;
        }
        public IEnumerable<AdminUserDealsInDepartment> GetAllUsersByDepartment(int DeptId)
        {
            List<AdminUserDealsInDepartment> so = db.AdminUserDealsInDepartments.Where(x => x.DeptId == DeptId).ToList();
            return so; ;
        }

    }
}
