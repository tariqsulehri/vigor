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
    public class UserModulesRepository : IUserModulesRepository
    {
        private readonly ErpDbContext _db;
        public UserModulesRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(UserModules userModules)
        {
            _db.UserModules.Add(userModules);
            _db.SaveChanges();
        }

        public void Edit(UserModules userModules)
        {
            _db.Entry(userModules).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.UserModules.Find(id);

            if (existingRecord != null)
            {
                _db.UserModules.Remove(existingRecord);
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

        public UserModules FindById(int id)
        {
            var userModule = _db.UserModules.Find(id);
            return userModule;
        }

        public IEnumerable<UserModules> GetAllUserModules()
        {
            return _db.UserModules.ToList();
        }
    }
}
