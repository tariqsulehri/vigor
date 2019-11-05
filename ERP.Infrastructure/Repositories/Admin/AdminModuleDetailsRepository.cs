using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.Admin;
using ERP.Core.Models.Admin;

namespace ERP.Infrastructure.Repositories.Admin
{
    public class AdminModuleDetailsRepository : IAdminModuleDetailsRepository
    {
        private readonly ErpDbContext _db;
        public AdminModuleDetailsRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(AdminModuleDetails adminModuleDetails)
        {
            _db.AdminModuleDetails.Add(adminModuleDetails);
            _db.SaveChanges();
        }

        public void Edit(AdminModuleDetails adminModuleDetails)
        {
            _db.Entry(adminModuleDetails).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.AdminModuleDetails.Find(id);

            if (existingRecord != null)
            {
                _db.AdminModuleDetails.Remove(existingRecord);
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

        public AdminModuleDetails FindById(int id)
        {
            var adminModuleDetails = _db.AdminModuleDetails.Find(id);
            return adminModuleDetails;
        }

        public IEnumerable<AdminModuleDetails> GetAllAdminModuleDetails()
        {
          return _db.AdminModuleDetails.ToList();
        }

    }
}
