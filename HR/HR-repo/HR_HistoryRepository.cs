using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HR_HistoryRepository : IHR_HistoryRepository
    {

        private readonly ErpDbContext _db;
        public HR_HistoryRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_History HR_History)
        {
            _db.HR_History.Add(HR_History);
            _db.SaveChanges();
        }

        public void Edit(HR_History HR_History)
        {
            _db.Entry(HR_History).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_History FindById(string id)
        {
            var department = _db.HR_History.Find(id);
            return department;
        }

        public IEnumerable<HR_History> GetAllHR_History()
        {
            return _db.HR_History.ToList();
        }

        public bool IsDuplicate(HR_History HR_History)
        {
            if (HR_History.HistoryID == "")
            {
                return _db.HR_History.Any(x => x.EmployeeNo == HR_History.EmployeeNo);
            }

            if (HR_History.HistoryID != "")
            {
                HR_History reg = _db.HR_History.FirstOrDefault(x => x.EmployeeNo == HR_History.EmployeeNo);
                if (reg != null && reg.HistoryID != HR_History.HistoryID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_History.Find(id);

            if (existingRecord != null)
            {
                _db.HR_History.Remove(existingRecord);
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
