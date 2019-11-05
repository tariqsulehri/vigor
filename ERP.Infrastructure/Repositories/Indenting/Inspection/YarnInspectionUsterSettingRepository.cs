using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class YarnInspectionUsterSettingRepository : IYarnInspectionUsterSettingRepository
    {
        private ErpDbContext db;
        public YarnInspectionUsterSettingRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(YarnInspectionsUsterSetting yarnInspectionsUsterSetting)
        {
            db.YarnInspectionsUsterSetting.Add(yarnInspectionsUsterSetting);
            db.SaveChanges();
        }

        public void Edit(YarnInspectionsUsterSetting yarnInspectionsUsterSetting)
        {
            try
            {
                var existingRecord = db.YarnInspectionsUsterSetting.Find(yarnInspectionsUsterSetting.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(yarnInspectionsUsterSetting);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public YarnInspectionsUsterSetting FindById(int id)
        {
            YarnInspectionsUsterSetting rc = db.YarnInspectionsUsterSetting.Find(id);
            return rc;
        }

        public IEnumerable<YarnInspectionsUsterSetting> GetAllYarnInspectionsUsterSetting()
        {
            return db.YarnInspectionsUsterSetting.ToList();
        }

        public bool IsDuplicate(YarnInspectionsUsterSetting yarnInspectionsUsterSetting)
        {
            if (yarnInspectionsUsterSetting.Id == 0)
            {
                return db.YarnInspectionsUsterSetting.Any(x => x.Description == yarnInspectionsUsterSetting.Description);
            }

            if (yarnInspectionsUsterSetting.Id != 0)
            {
                YarnInspectionsUsterSetting rc = db.YarnInspectionsUsterSetting.FirstOrDefault(x => x.Description == yarnInspectionsUsterSetting.Description);
                if (rc != null && rc.Id != yarnInspectionsUsterSetting.Id)
                {
                    return true;
                }
            }

            return false;

        }
        public bool Remove(YarnInspectionsUsterSetting yarnInspectionsUsterSetting)
        {
            var existingRecord = db.YarnInspectionsUsterSetting.Find(yarnInspectionsUsterSetting.Id);

            if (existingRecord != null)
            {
                db.YarnInspectionsUsterSetting.Remove(existingRecord);
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
