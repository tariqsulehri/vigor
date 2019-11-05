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
    public class AdminModulesRepository : IAdminModulesRepository
    {
        private readonly ErpDbContext _db;
        public AdminModulesRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(AdminModules adminModules)
        {
            _db.AdminModules.Add(adminModules);
            _db.SaveChanges();
        }

        public void Edit(AdminModules adminModules)
        {
            _db.Entry(adminModules).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.AdminModules.Find(id);

            if (existingRecord != null)
            {
                _db.AdminModules.Remove(existingRecord);
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

        public AdminModules FindById(int id)
        {
            var adminModules = _db.AdminModules.Find(id);
            return adminModules;
        }

        public IEnumerable<AdminModules> GetAllAdminModules()
        {
            return _db.AdminModules.ToList();
        }
    }
}
