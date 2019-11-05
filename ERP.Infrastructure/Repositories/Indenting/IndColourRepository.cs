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
    public class IndColourRepository : IIndColourRepository
    {
        private ErpDbContext db;
        public IndColourRepository()
        {
            db = new ErpDbContext();

        }
        public void Add(IndColour indColour)
        {
            db.IndColour.Add(indColour);
            db.SaveChanges();
        }

        public void Edit(IndColour indColour)
        {
            try
            {
                var existingRecord = db.IndColour.Find(indColour.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indColour);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndColour FindById(int id)
        {
            IndColour rc = db.IndColour.Find(id);
            return rc;
        }

        public IEnumerable<IndColour> GetAllIndColours()
        {
            return db.IndColour.ToList();
        }

        public bool IsDuplicate(IndColour indColour)
        {
            if (indColour.Id == 0)
            {
                return db.IndColour.Any(x => x.Description == indColour.Description);
            }

            if (indColour.Id != 0)
            {
                IndColour rc = db.IndColour.FirstOrDefault(x => x.Description == indColour.Description);
                if (rc != null && rc.Id != indColour.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndColour indColour)
        {
            var existingRecord = db.IndColour.Find(indColour.Id);

            if (existingRecord != null)
            {
                db.IndColour.Remove(existingRecord);
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
