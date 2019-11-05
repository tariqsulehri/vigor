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
    public class HR_AllowancesRepository : IHR_AllowancesRepository
    {
        private readonly ErpDbContext _db;
        public HR_AllowancesRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_Allowances HR_Allowances)
        {
            _db.HR_Allowances.Add(HR_Allowances);
            _db.SaveChanges();
        }

        public void Edit(HR_Allowances HR_Allowances)
        {
            _db.Entry(HR_Allowances).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_Allowances FindById(string id)
        {
            var department = _db.HR_Allowances.Find(id);
            return department;
        }

        public IEnumerable<HR_Allowances> GetAllHR_Allowances()
        {
            return _db.HR_Allowances.ToList();
        }

        public bool IsDuplicate(HR_Allowances HR_Allowances)
        {
            if (HR_Allowances.AllowanceID == "")
            {
                return _db.HR_Allowances.Any(x => x.Description == HR_Allowances.Description);
            }

            if (HR_Allowances.AllowanceID != "")
            {
                HR_Allowances reg = _db.HR_Allowances.FirstOrDefault(x => x.Description == HR_Allowances.Description);
                if (reg != null && reg.AllowanceID != HR_Allowances.AllowanceID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_Allowances.Find(id);

            if (existingRecord != null)
            {
                _db.HR_Allowances.Remove(existingRecord);
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

 
