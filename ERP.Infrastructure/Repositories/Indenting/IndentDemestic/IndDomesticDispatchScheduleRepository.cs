using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndDomesticDispatchScheduleRepository : IIndDomesticDispatchScheduleRepository
    {
        private ErpDbContext db;
        private IndDomesticRepository indDomesticRepository; 

        public IndDomesticDispatchScheduleRepository()
        {
            db = new ErpDbContext();
            indDomesticRepository = new IndDomesticRepository();
        }

        public void Add(IndDomesticDispatchSchedule indDomesticDispatchSchedule)
        {
            db.IndDomesticDispatchSchedules.Add(indDomesticDispatchSchedule);
            db.SaveChanges();

        }

        public void  updateRunningBalance(int productId, int indentId)
        {
            decimal qty = indDomesticRepository.GetIndentQuantityById(productId, indentId);

            if (qty > 0)
            {
              List<IndDomesticDispatchSchedule> dispatches = db.IndDomesticDispatchSchedules.
                                                             Where(x => x.IndentId == indentId && x.CommodityId == productId && x.TypeOfTransaction != "P").
                                                             OrderBy(x=> x.Id).
                                                             ToList();  
              foreach(var disp in dispatches)
              {
 
                  if (disp.TypeOfTransaction == "D")
                  {
                        qty = qty - disp.Quantity;    
                  }

                  if (disp.TypeOfTransaction == "R")
                  {
                        qty = qty + disp.Quantity;
                  }

                    disp.Balance = qty;

                    var existingRecord = db.IndDomesticDispatchSchedules.Find(disp.Id);
                    db.Entry(existingRecord).CurrentValues.SetValues(disp);
                    db.SaveChanges();

                }
            }

        }

        public void Edit(IndDomesticDispatchSchedule indDomesticDispatchSchedule)
        {
            var result = db.IndDomesticDispatchSchedules.SingleOrDefault(b => b.Id == indDomesticDispatchSchedule.Id);
            if (result != null)
            {
                try
                {
                 // db.IndDomesticDispatchSchedules.Attach(indDomesticDispatchSchedule);
                    db.Entry(indDomesticDispatchSchedule).State = EntityState.Modified;
                    db.SaveChanges();

                    updateRunningBalance(indDomesticDispatchSchedule.CommodityId, indDomesticDispatchSchedule.IndentId);
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public IndDomesticDispatchSchedule FindById(int id)
        {
            IndDomesticDispatchSchedule rc = db.IndDomesticDispatchSchedules.Find(id);
            return rc;
        }

        public IEnumerable<IndDomesticDispatchSchedule> GetAllIndDomesticDispatchSchedule()
        {
            return db.IndDomesticDispatchSchedules.ToList();
        }

        public bool IsDuplicate(IndDomesticDispatchSchedule IndDomesticDispatchSchedule)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndDomesticDispatchSchedule IndDomesticDispatchSchedule)
        {
            var existingRecord = db.IndDomesticDispatchSchedules.Find(IndDomesticDispatchSchedule.Id);

            if (existingRecord != null)
            {
                db.IndDomesticDispatchSchedules.Remove(existingRecord);
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

