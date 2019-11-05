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
    public class HR_DayStatusRepository : IHR_DayStatusRepository
    {
        private readonly ErpDbContext _db;
        public HR_DayStatusRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_DayStatus HR_DayStatus)
        {
            _db.HR_DayStatus.Add(HR_DayStatus);
            _db.SaveChanges();
        }

        public void Edit(HR_DayStatus HR_DayStatus)
        {
            try
            {
                var existingRecord = _db.HR_DayStatus.Find(HR_DayStatus.DayStatusID);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_DayStatus);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_DayStatus FindById(string id)
        {
            var department = _db.HR_DayStatus.Find(id);
            return department;
        }

        public IEnumerable<HR_DayStatus> GetAllHR_DayStatus()
        {
            return _db.HR_DayStatus.ToList();
        }

        public bool IsDuplicate(HR_DayStatus HR_DayStatus)
        {
            if (HR_DayStatus.DayStatusID == 0)
            {
                return _db.HR_DayStatus.Any(x => x.Description == HR_DayStatus.Description);
            }

            if (HR_DayStatus.DayStatusID != 0)
            {
                HR_DayStatus reg = _db.HR_DayStatus.FirstOrDefault(x => x.Description == HR_DayStatus.Description);
                if (reg != null && reg.DayStatusID != HR_DayStatus.DayStatusID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_DayStatus.Find(id);

            if (existingRecord != null)
            {
                _db.HR_DayStatus.Remove(existingRecord);
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
