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
    public class HR_CINCRRepository : IHR_CINCRRepository
    {
        private readonly ErpDbContext _db;
        public HR_CINCRRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_CINCR HR_CINCR)
        {
            _db.HR_CINCR.Add(HR_CINCR);
            _db.SaveChanges();
        }

        public void Edit(HR_CINCR HR_CINCR)
        {
            try
            {
                var existingRecord = _db.HR_CINCR.Find(HR_CINCR.id);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_CINCR);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_CINCR FindById(string id)
        {
            var department = _db.HR_CINCR.Find(id);
            return department;
        }

        public IEnumerable<HR_CINCR> GetAllHR_CINCR()
        {
            return _db.HR_CINCR.ToList();
        }

        public bool IsDuplicate(HR_CINCR HR_CINCR)
        {
            if (HR_CINCR.id == "")
            {
                return _db.HR_CINCR.Any(x => x.id == HR_CINCR.id);
            }

            if (HR_CINCR.id != "")
            {
                HR_CINCR reg = _db.HR_CINCR.FirstOrDefault(x => x.Incident == HR_CINCR.Incident);
                if (reg != null && reg.id != HR_CINCR.id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_CINCR.Find(id);

            if (existingRecord != null)
            {
                _db.HR_CINCR.Remove(existingRecord);
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
