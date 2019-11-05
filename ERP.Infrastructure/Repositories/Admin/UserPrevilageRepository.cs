using ERP.Core.IRepositories.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Admin
{
    public class UserPrevilageRepository : IUserPrevilageRepository
    {
        private readonly ErpDbContext db;

        public UserPrevilageRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(UserPrevilage userPrevilage)
        {
            db.UserPrevilages.Add(userPrevilage);
            db.SaveChanges();
        }

        public void Edit(UserPrevilage userPrevilage)
        {
            var result = db.UserPrevilages.SingleOrDefault(b => b.UserPrevilageId == userPrevilage.UserPrevilageId);
            if (result != null)
            {
                try
                {
                    db.Entry(userPrevilage).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public UserPrevilage FindById(int id)
        {
            UserPrevilage so = db.UserPrevilages.Find(id);
            return so;
        }

      

        public IEnumerable<UserPrevilage> GetAllUserPrevilages()
        {
            return db.UserPrevilages.ToList();
        }

        public IEnumerable<UserPrevilage> GetAllUserPrevilagesByUserId(int userid)
        {
            return db.UserPrevilages.Where(x => x.UserId == userid).ToList();
        }

        public bool IsDuplicate(UserPrevilage userPrevilage)
        {
            if (userPrevilage.UserPrevilageId == 0)
            {
                return db.UserPrevilages.Any(x => x.mKey == userPrevilage.mKey);
            }

            if (userPrevilage.UserPrevilageId != 0)
            {
                UserPrevilage rc = db.UserPrevilages.FirstOrDefault(x => x.mKey == userPrevilage.mKey);
                if (rc != null && rc.UserPrevilageId != userPrevilage.UserPrevilageId)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(UserPrevilage userPrevilage)
        {
            UserPrevilage er = db.UserPrevilages.Find(userPrevilage.UserPrevilageId);
            if (er != null)
            {
                db.UserPrevilages.Remove(er);
            }

            if (db.SaveChanges() == 1)
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
