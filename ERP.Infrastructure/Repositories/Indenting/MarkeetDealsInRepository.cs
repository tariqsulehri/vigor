using ERP.Core.IRepositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class MarkeetDealsInRepository : IMarkeetDealsInRepository
    {
        private ErpDbContext db;
        public MarkeetDealsInRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(MarkeetDealsIn markeetDealsIn)
        {
            db.MarketDealIn.Add(markeetDealsIn);
            db.SaveChanges();
        }

        public void Edit(MarkeetDealsIn markeetDealsIn)
        {
            try
            {
                var existingRecord = db.MarketDealIn.Find(markeetDealsIn.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(markeetDealsIn);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }
              
        public IEnumerable<MarkeetDealsIn> GetAllMarkeetDealsIn()
        {
            return db.MarketDealIn.ToList();
        }

        public MarkeetDealsIn GetAllMarkeetDealsInById(int id)
        {
            MarkeetDealsIn c = db.MarketDealIn.Find(id);
            return c;
        }

        public bool IsDuplicate(MarkeetDealsIn markeetDealsIn)
        {
            if (markeetDealsIn.Id == 0)
            {
                return db.MarketDealIn.Any(x => x.Description == markeetDealsIn.Description);
            }

            if (markeetDealsIn.Id != 0)
            {
                MarkeetDealsIn rc = db.MarketDealIn.FirstOrDefault(x => x.Description == markeetDealsIn.Description);
                if (rc != null && rc.Id != markeetDealsIn.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(MarkeetDealsIn markeetDealsIn)
        {
            var existingRecord = db.MarketDealIn.Find(markeetDealsIn.Id);

            if (existingRecord != null)
            {
                db.MarketDealIn.Remove(markeetDealsIn);
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
