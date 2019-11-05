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
    public class IndDelayShipmentReasonRepository : IIndDelayShipmentReasonRepository
    {
        private ErpDbContext db;
        public IndDelayShipmentReasonRepository()
        {
            db = new ErpDbContext();

        }
        public void Add(IndDelayShipmentReason indDelayShipmentReason)
        {
            db.IndDelayShipmentReason.Add(indDelayShipmentReason);
            db.SaveChanges();
        }

        public void Edit(IndDelayShipmentReason indDelayShipmentReason)
        {
            try
            {
                var existingRecord = db.IndDelayShipmentReason.Find(indDelayShipmentReason.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(indDelayShipmentReason);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public IndDelayShipmentReason FindById(int id)
        {
            IndDelayShipmentReason dc = db.IndDelayShipmentReason.Find(id);
            return dc;
        }

        public IEnumerable<IndDelayShipmentReason> GetAllIndDelayShipmentReasons()
        {
            return db.IndDelayShipmentReason.ToList();
        }

        public bool IsDuplicate(IndDelayShipmentReason indDelayShipmentReason)
        {
            if (indDelayShipmentReason.Id == 0)
            {
                return db.IndDelayShipmentReason.Any(x => x.Description == indDelayShipmentReason.Description);
            }

            if (indDelayShipmentReason.Id != 0)
            {
                IndDelayShipmentReason rc = db.IndDelayShipmentReason.FirstOrDefault(x => x.Description == indDelayShipmentReason.Description);
                if (rc != null && rc.Id != indDelayShipmentReason.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(IndDelayShipmentReason indDelayShipmentReason)
        {
            var existingRecord = db.IndDelayShipmentReason.Find(indDelayShipmentReason.Id);

            if (existingRecord != null)
            {
                db.IndDelayShipmentReason.Remove(existingRecord);
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
