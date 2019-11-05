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
    public class HR_GazzettedDaysRepository : IHR_GazzettedDaysRepository
    {

        private readonly ErpDbContext _db;
        public HR_GazzettedDaysRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_GazzettedDays HR_GazzettedDays)
        {
            _db.HR_GazzettedDays.Add(HR_GazzettedDays);
            _db.SaveChanges();
        }

        public void Edit(HR_GazzettedDays HR_GazzettedDays)
        {
            _db.Entry(HR_GazzettedDays).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_GazzettedDays FindById(string id)
        {
            var department = _db.HR_GazzettedDays.Find(id);
            return department;
        }

        public IEnumerable<HR_GazzettedDays> GetAllHR_GazzettedDays()
        {
            return _db.HR_GazzettedDays.ToList();
        }

        public bool IsDuplicate(HR_GazzettedDays HR_GazzettedDays)
        {
            if (HR_GazzettedDays.GazzettedDateId == "")
            {
                return _db.HR_GazzettedDays.Any(x => x.Description == HR_GazzettedDays.Description);
            }

            if (HR_GazzettedDays.GazzettedDateId != "")
            {
                HR_GazzettedDays reg = _db.HR_GazzettedDays.FirstOrDefault(x => x.Description == HR_GazzettedDays.Description);
                if (reg != null && reg.GazzettedDateId != HR_GazzettedDays.GazzettedDateId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_GazzettedDays.Find(id);

            if (existingRecord != null)
            {
                _db.HR_GazzettedDays.Remove(existingRecord);
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
