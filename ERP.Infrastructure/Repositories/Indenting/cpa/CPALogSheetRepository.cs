using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.cpa;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Infrastructure.Repositories.Indenting.cpa
{
    public class CPALogSheetRepository : ICPALogSheetRepository
    {

        public ErpDbContext db;
        public void Add(CPALogSheet CPALogSheet)
        {
            db.CPALogSheets.Add(CPALogSheet);
            db.SaveChanges();
        }

        public void Edit(CPALogSheet CPALogSheet)
        {
            try
            {
                var existingRecord = db.CPALogSheets.Find(CPALogSheet.CpaNo);
                db.Entry(existingRecord).CurrentValues.SetValues(CPALogSheet);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(CPALogSheet CPALogSheet)
        {
            var existingRecord = db.CPALogSheets.Find(CPALogSheet.CpaNo);

            if (existingRecord != null)
            {
                db.CPALogSheets.Remove(existingRecord);
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

        public CPALogSheet FindById(int id)
        {
            return db.CPALogSheets.Find(id);
        }

        public bool IsDuplicate(CPALogSheet CPALogSheet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CPALogSheet> GetAllCPALogSheets()
        {
            return db.CPALogSheets.ToList();
        }
    }
}