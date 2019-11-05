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
    public class HR_DesignationRepository : IHR_DesignationRepository
    {
        private readonly ErpDbContext _db;
        public HR_DesignationRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_Designation HR_Designation)
        {
            _db.HR_Designation.Add(HR_Designation);
            _db.SaveChanges();
        }

        public void Edit(HR_Designation HR_Designation)
        {
            _db.Entry(HR_Designation).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public HR_Designation FindById(string id)
        {
            var position = _db.HR_Designation.Find(id);
            return position;
        }

        public IEnumerable<HR_Designation> GetAllHR_Designation()
        {
            return _db.HR_Designation.ToList();
        }

        public bool IsDuplicate(HR_Designation HR_Designation)
        {
            if (HR_Designation.DesignationId == "")
            {
                return _db.HR_Designation.Any(x => x.Description == HR_Designation.Description);
            }

            if (HR_Designation.DesignationId != "")
            {
                HR_Designation reg = _db.HR_Designation.FirstOrDefault(x => x.Description == HR_Designation.Description);
                if (reg != null && reg.DesignationId != HR_Designation.DesignationId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_Designation.Find(id);

            if (existingRecord != null)
            {
                _db.HR_Designation.Remove(existingRecord);
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
