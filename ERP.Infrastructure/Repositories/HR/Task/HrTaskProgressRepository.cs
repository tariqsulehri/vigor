using ERP.Core.Models.HR.Task;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR.Task
{
    public class HrTaskProgressRepository
    {
        private ErpDbContext db;
        public HrTaskProgressRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(HrTaskProgress hrTaskProgress)
        {
            db.HrTaskProgress.Add(hrTaskProgress);
            db.SaveChanges();
        }

        public void Edit(HrTaskProgress hrTaskProgress)
        {
            var result = db.HrTaskProgress.SingleOrDefault(b => b.Id == hrTaskProgress.Id);
            if (result != null)
            {
                try
                {
                   // db.HrTaskProgress.Attach(hrTaskProgress);
                    db.Entry(hrTaskProgress).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public HrTaskProgress FindById(int id)
        {
            HrTaskProgress rc = db.HrTaskProgress.Find(id);
            return rc;
        }

        public IEnumerable<HrTaskProgress> GetAllHrTaskProgresss()
        {
           return db.HrTaskProgress.ToList();
        }

        public bool Remove(HrTaskProgress HrTaskProgress)
        {
            var existingRecord = db.HrTaskProgress.Find(HrTaskProgress.Id);

            if (existingRecord != null)
            {
                db.HrTaskProgress.Remove(existingRecord);
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
