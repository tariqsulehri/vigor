using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CPAAttachments_2BDeletedRepository : ICPAAttachments_2BDeletedRepository
    {
        private ErpDbContext db;
        public CPAAttachments_2BDeletedRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CPAAttachments_2BDeleted CPAAttachments_2BDeleted)
        {
            db.CPAAttachments_2BDeleted.Add(CPAAttachments_2BDeleted);
            db.SaveChanges();
        }

        public void Edit(CPAAttachments_2BDeleted CPAAttachments_2BDeleted)
        {
            try
            {
                var existingRecord = db.CPAAttachments_2BDeleted.Find(CPAAttachments_2BDeleted.CpaNo);
                db.Entry(existingRecord).CurrentValues.SetValues(CPAAttachments_2BDeleted);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CPAAttachments_2BDeleted CPAAttachments_2BDeleted)
        {
            var existingRecord = db.CPAAttachments_2BDeleted.Find(CPAAttachments_2BDeleted.CpaNo);

            if (existingRecord != null)
            {
                db.CPAAttachments_2BDeleted.Remove(existingRecord);
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

        public CPAAttachments_2BDeleted FindById(string CPAAttachments_2BDeletedID)
        {
            return db.CPAAttachments_2BDeleted.Find(CPAAttachments_2BDeletedID);
        }

        public bool IsDuplicate(CPAAttachments_2BDeleted CPAAttachments_2BDeleted)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CPAAttachments_2BDeleted> GetAllCPAAttachments_2BDeleteds()
        {
            return db.CPAAttachments_2BDeleted.ToList();
        }
    }
}