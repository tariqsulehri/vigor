using System.Linq;

namespace ERP.Infrastructure.Repositories.HR
{
    using ERP.Core.IRepositories.HrIRepository;
    using ERP.Core.Models.HR;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class HR_LoanAdvanceApplicationRepository : IHR_LoanAdvanceApplicationRepository
    {

        private readonly ErpDbContext _db;
        public HR_LoanAdvanceApplicationRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_LoanAdvanceApplication HR_LoanAdvanceApplication)
        {
            _db.HR_LoanAdvanceApplication.Add(HR_LoanAdvanceApplication);
            _db.SaveChanges();
        }

        public void Edit(HR_LoanAdvanceApplication HR_LoanAdvanceApplication)
        {
            try
            {
                var existingRecord = _db.HR_LoanAdvanceApplication.Find(HR_LoanAdvanceApplication.LoanAdvanceID);
                _db.Entry(existingRecord).CurrentValues.SetValues(HR_LoanAdvanceApplication);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public HR_LoanAdvanceApplication FindById(string id)
        {
            var department = _db.HR_LoanAdvanceApplication.Find(id);
            return department;
        }

        public IEnumerable<HR_LoanAdvanceApplication> GetAllHR_LoanAdvanceApplication()
        {
            return _db.HR_LoanAdvanceApplication.ToList();
        }

        public bool IsDuplicate(HR_LoanAdvanceApplication HR_LoanAdvanceApplication)
        {
            if (HR_LoanAdvanceApplication.LoanAdvanceID == "")
            {
                return _db.HR_LoanAdvanceApplication.Any(x => x.RequiredAmount == HR_LoanAdvanceApplication.RequiredAmount);
            }

            if (HR_LoanAdvanceApplication.LoanAdvanceID != "")
            {
                HR_LoanAdvanceApplication reg = _db.HR_LoanAdvanceApplication.FirstOrDefault(x => x.RequiredAmount == HR_LoanAdvanceApplication.RequiredAmount);
                if (reg != null && reg.LoanAdvanceID != HR_LoanAdvanceApplication.LoanAdvanceID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string id)
        {
            var existingRecord = _db.HR_LoanAdvanceApplication.Find(id);

            if (existingRecord != null)
            {
                _db.HR_LoanAdvanceApplication.Remove(existingRecord);
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
