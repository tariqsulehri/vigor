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
    public class UserModuleDetailsRepository : IUserModuleDetailsRepository
    {
        private readonly ErpDbContext _db;
        public UserModuleDetailsRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(UserModuleDetails userModuleDetails)
        {
            _db.UserModuleDetails.Add(userModuleDetails);
            _db.SaveChanges();
        }

        public void Edit(UserModuleDetails userModuleDetails)
        {
            _db.Entry(userModuleDetails).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.UserModuleDetails.Find(id);

            if (existingRecord != null)
            {
                _db.UserModuleDetails.Remove(existingRecord);
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
		 public bool RemoveAll(int id)
        {
            var existingRecord = _db.UserModuleDetails.Where(x => x.ModuleDtlId == id).ToList();

            if (existingRecord != null)
            {
                _db.UserModuleDetails.RemoveRange(existingRecord);
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
        public UserModuleDetails FindById(int id)
        {
            var userModuleDetails = _db.UserModuleDetails.Find(id);
            return userModuleDetails;
        }

        public IEnumerable<UserModuleDetails> GetAllUserModuleDetails()
        {
            return _db.UserModuleDetails.ToList();
        }

    }
}
