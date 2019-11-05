using ERP.Core.IRepositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class DeptDealsInMarkeetRepository : IDeptDealsInMarkeetRepository
    {
        private ErpDbContext db;

        public DeptDealsInMarkeetRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(DeptDealsInMarkeet deptDealsInMarkeet)
        {
            db.DeptDealsInMarkeet.Add(deptDealsInMarkeet);
            db.SaveChanges();
        }

        public void Edit(DeptDealsInMarkeet deptDealsInMarkeet)
        {
            try
            {
                var existingRecord = db.DeptDealsInMarkeet.Find(deptDealsInMarkeet.id);
                db.Entry(existingRecord).CurrentValues.SetValues(deptDealsInMarkeet);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public DeptDealsInMarkeet FindByKey(string key)
        {
            DeptDealsInMarkeet c = db.DeptDealsInMarkeet.Find(key);
            return c;
        }

        public IEnumerable<DeptDealsInMarkeet> GetAllMarkeetByDepartment(int deptID)
        {
            var result = db.DeptDealsInMarkeet.Where(x => x.DepartmentId == deptID).ToList();
            return result;
        }

        public IEnumerable<DeptDealsInMarkeet> GetAllDepartmentsByMarkeets(int markeetID)
        {
            var result = db.DeptDealsInMarkeet.Where(x => x.DealsInId == x.DealsInId).ToList();
            return result;
        }

        public IEnumerable<DeptDealsInMarkeet> GetAllDeptDealsInMarkeets()
        {
            return db.DeptDealsInMarkeet.ToList();
        }

        public DeptDealsInMarkeet GetAllDeptDealsInMarkeetsByKey(string mKey)
        {
            var result = db.DeptDealsInMarkeet.SingleOrDefault(x => x.mkey == mKey);
            return result;
        }

        public bool IsDuplicate(DeptDealsInMarkeet deptDealsInMarkeet)
        {
            int cnt = 0;
            if (deptDealsInMarkeet.mkey != string.Empty)
            {
                cnt = db.DeptDealsInMarkeet.Count(x => x.mkey == deptDealsInMarkeet.mkey);

            }

            if (cnt >= 1)
            {
                return true;
            }

            return false;
        }

        public bool Remove(DeptDealsInMarkeet deptDealsInMarkeet)
        {
            var existingRecord = db.DeptDealsInMarkeet.SingleOrDefault(x => x.mkey == deptDealsInMarkeet.mkey);

            if (existingRecord != null)
            {
                db.DeptDealsInMarkeet.Remove(existingRecord);
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
    }
}
