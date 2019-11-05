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
    public class SystemOptionRepository : ISystemOptionRepository
    {
        private readonly ErpDbContext db;

        public SystemOptionRepository()
        {
            db = new ErpDbContext(); 
        }
        public void Add(SystemOption systemOption)
        {
            db.SystemOptions.Add(systemOption);
            db.SaveChanges();
        }

        public void Edit(SystemOption systemOption)
        {
            var result = db.SystemOptions.SingleOrDefault(b => b.OptionId == systemOption.OptionId);
            if (result != null)
            {
                try
                {
                    db.Entry(systemOption).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SystemOption FindById(int id)
        {
            SystemOption so = db.SystemOptions.Find(id);
            return so;
        }

        public IEnumerable<SystemOption> GetAllSystemOptions()
        {
            return db.SystemOptions.ToList();
        }

        public IEnumerable<SystemOption> GetAllSystemOptionsByUser(int userId)
        {
            return db.SystemOptions.ToList();
        }

        public bool IsDuplicate(SystemOption systemOption)
        {
            if (systemOption.OptionId == 0)
            {
                return db.SystemOptions.Any(x => x.OptionDescription == systemOption.OptionDescription);
            }

            if (systemOption.OptionId != 0)
            {
                SystemOption rc = db.SystemOptions.FirstOrDefault(x => x.OptionDescription == systemOption.OptionDescription);
                if (rc != null && rc.OptionId != systemOption.OptionId)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(SystemOption systemOption)
        {
            SystemOption er = db.SystemOptions.Find(systemOption.OptionId);
            if (er != null)
            {
                db.SystemOptions.Remove(er);
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
