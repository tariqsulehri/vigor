using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;
using ERP.Infrastructure;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class FinFescalYearRepository : IFinFescalYearRepository
    {
        private readonly ErpDbContext _db;
        public FinFescalYearRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(FinFescalYear fescalYear)
        {
            using (var context = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.FinFescalYear.Add(fescalYear);
                    _db.SaveChanges();
                    context.Commit();
                }
                catch (Exception e)
                {
                    context.Rollback();
                    throw e;
                }
            }
        }

        public void Edit(FinFescalYear fescalYear)
        {
            FinFescalYear oldFescalYear = _db.FinFescalYear.Find(fescalYear.Id);
            if (oldFescalYear != null)
            {
                oldFescalYear.YearKey = fescalYear.YearKey;
                oldFescalYear.Active = fescalYear.Active;
                oldFescalYear.Title = fescalYear.Title;
                oldFescalYear.StartDate = oldFescalYear.StartDate;
                oldFescalYear.EndDate = fescalYear.EndDate;
                oldFescalYear.CreatedBy = fescalYear.CreatedBy;
                oldFescalYear.CreatedOn = fescalYear.CreatedOn;
                oldFescalYear.ModifiedBy = fescalYear.ModifiedBy;
                oldFescalYear.ModifiedOn = fescalYear.ModifiedOn;
                _db.Entry(oldFescalYear).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public bool IsDuplicate(FinFescalYear fescalYear)
        {

            if (fescalYear.Id == 0) { return _db.FinFescalYear.Any(x => x.YearKey == fescalYear.YearKey); }
            if (fescalYear.Id != 0)
            {
                FinFescalYear oldFescalYear = _db.FinFescalYear.FirstOrDefault(x => x.YearKey == fescalYear.YearKey);
                if (oldFescalYear != null && oldFescalYear.Id != fescalYear.Id)
										 
				 
												   
				 

										   
                {
                    return true;

                }
					
				 
								 
				  
            }
            return false;
        }

        public bool Remove(int id)
        {
            var existingYear = _db.CoaL1.Find(id);

            if (existingYear != null)
            {
                _db.CoaL1.Remove(existingYear);
								  
            }

            if (_db.SaveChanges() == 1)
            {
																					
                return true;

            }
            else
            {
                return false;
            };
        }

        public FinFescalYear FindById(int id)
        {
            var fescalYear = _db.FinFescalYear.Find(id);
            return fescalYear;
        }

        public IEnumerable<FinFescalYear> GetAllFescalYears()
        {
            IEnumerable<FinFescalYear> fescalYears = _db.FinFescalYear.ToList();
            return fescalYears;
        }
    }
}


