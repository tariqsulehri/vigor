using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class FinFescalYearDetailRepository : IFinFescalYearDetailRepository

    {
        private readonly ErpDbContext _db;
        public FinFescalYearDetailRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(FinFescalYearDetail fescalYearDetail)
        {
            _db.FinFescalYearDetail.Add(fescalYearDetail);
            _db.SaveChanges();
        }

        public void Edit(FinFescalYearDetail fescalYearDetail)
        {
            _db.Entry(fescalYearDetail).State = EntityState.Modified;
            _db.SaveChanges();
			 
										 
        }

        public bool Remove(int id)
        {
            var existingMonth = _db.CoaL1.Find(id);
								  
			 

            if (existingMonth != null)
            {
                _db.CoaL1.Remove(existingMonth);
								  
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

        public FinFescalYearDetail FindById(int id)
        {
            var fescalYearDetail = _db.FinFescalYearDetail.Find(id);
            return fescalYearDetail;
        }

        public IEnumerable<FinFescalYearDetail> GetAllFescalYearDetails()
        {
            IEnumerable<FinFescalYearDetail> fescallYearDetails = _db.FinFescalYearDetail.ToList();
            return fescallYearDetails;
        }

        public IEnumerable<FinFescalYearDetail> GetAllFescalYearDetails(int id)
        {
            IEnumerable<FinFescalYearDetail> fescallYearDetails = _db.FinFescalYearDetail.Where(x => x.YearId == id).ToList();
            return fescallYearDetails;
        }
    }
}
