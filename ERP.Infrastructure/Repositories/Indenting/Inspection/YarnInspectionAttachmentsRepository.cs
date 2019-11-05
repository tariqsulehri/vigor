using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.Inspection;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class YarnInspectionAttachmentsRepository : IYarnInspectionAttachmentsRepository
    {

        private ErpDbContext db;
        public YarnInspectionAttachmentsRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(YarnInspectionAttachments yarnInspectionAttachments)
        {
            db.YarnInspectionAttachments.Add(yarnInspectionAttachments);
            db.SaveChanges();
        }

        public void Edit(YarnInspectionAttachments yarnInspectionAttachments)
        {
            try
            {
                var existingRecord = db.YarnInspectionAttachments.Find(yarnInspectionAttachments.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(yarnInspectionAttachments);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }

        public YarnInspectionAttachments FindById(int id)
        {
            YarnInspectionAttachments rc = db.YarnInspectionAttachments.Find(id);
            return rc;
        }

        public IEnumerable<YarnInspectionAttachments> GetAllYarnInspectionAttachments()
        {
            return db.YarnInspectionAttachments.ToList();
        }

        public bool IsDuplicate(YarnInspectionAttachments yarnInspectionAttachments)
        {
            if (yarnInspectionAttachments.Id == 0)
            {
                return db.YarnInspectionAttachments.Any(x => x.FileName == yarnInspectionAttachments.FileName);
            }

            if (yarnInspectionAttachments.Id != 0)
            {
                YarnInspectionAttachments rc = db.YarnInspectionAttachments.FirstOrDefault(x => x.FileName == yarnInspectionAttachments.FileName);
                if (rc != null && rc.Id != yarnInspectionAttachments.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(YarnInspectionAttachments yarnInspectionAttachments)
        {
            var existingRecord = db.YarnInspectionAttachments.Find(yarnInspectionAttachments.Id);

            if (existingRecord != null)
            {
                db.YarnInspectionAttachments.Remove(existingRecord);
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
