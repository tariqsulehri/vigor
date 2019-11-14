using ERP.Core.IRepositories.Indenting.Inspection;
using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class IndentInspectionRepository : IIndentInspectionRepository
    {

        private ErpDbContext db;
        public IndentInspectionRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndentInspection indInspection)
        {
            db.IndentInspections.Add(indInspection);
            db.SaveChanges();
        }

        public void Edit(IndentInspection indInspection)
        {
            try
            {
                var existingRecord = db.IndentInspections.Find(indInspection.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indInspection);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndentInspection FindById(int id)
        {
            IndentInspection rc = db.IndentInspections.Find(id);
            return rc;
        }

        public IEnumerable<IndentInspection> GetAllIndInspection()
        {
            return db.IndentInspections.ToList();
        }

        public bool IsDuplicate(IndentInspection indInspection)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndentInspection indInspection)
        {
            var existingRecord = db.IndentInspections.Find(indInspection.Id);

            if (existingRecord != null)
            {
                db.IndentInspections.Remove(existingRecord);
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
