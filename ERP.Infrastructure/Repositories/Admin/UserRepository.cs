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
    public class UserRepository : IUserRepository
    {
        private readonly ErpDbContext _db;
        public UserRepository()
        {
            _db =  new ErpDbContext();
        }
        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Edit(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int ucode)
        {
            var existingRecord = _db.Users.Find(ucode);

            if (existingRecord != null)
            {
                _db.Users.Remove(existingRecord);
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

        public User FindById(int ucode)
        {
            var user = _db.Users.Find(ucode);
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }
    }
}
