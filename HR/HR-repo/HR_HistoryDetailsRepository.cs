using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HR_HistoryDetailsRepository : IHR_HistoryDetailsRepository
    {

        private readonly ErpDbContext _db;
        public HR_HistoryDetailsRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_HistoryDetails HR_HistoryDetails)
        {
            _db.HR_HistoryDetails.Add(HR_HistoryDetails);
            _db.SaveChanges();
        }

        public void Edit(HR_HistoryDetails HR_HistoryDetails)
        {
            _db.Entry(HR_HistoryDetails).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_HistoryDetails FindById(string id)
        {
            var department = _db.HR_HistoryDetails.Find(id);
            return department;
        }

        public IEnumerable<HR_HistoryDetails> GetAllHR_HistoryDetails()
        {
            return _db.HR_HistoryDetails.ToList();
        }

        public bool IsDuplicate(HR_HistoryDetails HR_HistoryDetails)
        {
            if (HR_HistoryDetails.HistoryID == "")
            {
                return _db.HR_HistoryDetails.Any(x => x.Amount == HR_HistoryDetails.Amount);
            }

            if (HR_HistoryDetails.AllowanceID != "")
            {
                HR_HistoryDetails reg = _db.HR_HistoryDetails.FirstOrDefault(x => x.Amount == HR_HistoryDetails.Amount);
                if (reg != null && reg.HistoryID != HR_HistoryDetails.HistoryID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_HistoryDetails.Find(id);

            if (existingRecord != null)
            {
                _db.HR_HistoryDetails.Remove(existingRecord);
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
    }
}
