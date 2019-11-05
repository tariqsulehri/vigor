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
    public class HR_DegreeRepository : IHR_DegreeRepository
    {
        private readonly ErpDbContext _db;
        public HR_DegreeRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_Degree HR_Degree)
        {
            _db.HR_Degree.Add(HR_Degree);
            _db.SaveChanges();
        }

        public void Edit(HR_Degree HR_Degree)
        {
            try
            {
                var existingRecord = _db.HR_Degree.Find(HR_Degree.DegreeID);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_Degree);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_Degree FindById(string id)
        {
            var department = _db.HR_Degree.Find(id);
            return department;
        }

        public IEnumerable<HR_Degree> GetAllHR_Degree()
        {
            return _db.HR_Degree.ToList();
        }

        public bool IsDuplicate(HR_Degree HR_Degree)
        {
            if (HR_Degree.DegreeID == "")
            {
                return _db.HR_Degree.Any(x => x.Description == HR_Degree.Description);
            }

            if (HR_Degree.DegreeID != "")
            {
                HR_Degree reg = _db.HR_Degree.FirstOrDefault(x => x.Description == HR_Degree.Description);
                if (reg != null && reg.Description != HR_Degree.DegreeID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_Degree.Find(id);

            if (existingRecord != null)
            {
                _db.HR_Degree.Remove(existingRecord);
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
