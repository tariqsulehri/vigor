using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Admin;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class YarnInspectionRepository : IYarnInspectionRepository
    {
        private ErpDbContext db;
        public YarnInspectionRepository()
        {
            db = new ErpDbContext();
        }

        public YarnInspection Add(YarnInspection yarnInspection)
        {
            db.YarnInspection.Add(yarnInspection);
            db.SaveChanges();
            return yarnInspection;
        }
        public YarnInspection Edit(YarnInspection yarnInspection)
        {
            try
            {
                var existingRecord = db.YarnInspection.Find(yarnInspection.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(yarnInspection);
                db.SaveChanges();
                return yarnInspection;

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }


        }
        public void EditAttachments(YarnInspectionAttachments yarnInspectionAttachments)    
        {
            try
            {
                YarnInspectionAttachments existingRecord = db.YarnInspectionAttachments.Find(yarnInspectionAttachments.Id);

                if (existingRecord != null)
                {
                    existingRecord.isActive = yarnInspectionAttachments.isActive;
                    existingRecord.Id = yarnInspectionAttachments.Id;
                    existingRecord.FileName = yarnInspectionAttachments.FileName;
                    existingRecord.CreatedBy = yarnInspectionAttachments.CreatedBy;
                    existingRecord.CreatedOn = yarnInspectionAttachments.CreatedOn;
                    existingRecord.DeleteBy = yarnInspectionAttachments.DeleteBy;
                    existingRecord.DeleteOn = yarnInspectionAttachments.DeleteOn;
                    existingRecord.FileDescription = yarnInspectionAttachments.FileDescription;
                    existingRecord.InspectionSerialID = yarnInspectionAttachments.InspectionSerialID;
                    existingRecord.YarnInspectionId = yarnInspectionAttachments.YarnInspectionId;
                    db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //db.Entry(existingRecord).CurrentValues.SetValues(yarnInspectionAttachments);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }
        public YarnInspection FindById(int id)
        {
            YarnInspection rc = db.YarnInspection.Find(id);
            return rc;
        }

        public IEnumerable<YarnInspection> GetAllYarnInspections()
        {
            return db.YarnInspection.ToList();
        }

        public bool Remove(YarnInspection yarnInspection)
        {
            throw new NotImplementedException();
        }
        public string GetInspectionSerialID(char type)
        {
            int maxno = db.IndentInspections.Count();
            maxno = maxno + 1;
            string SerialID = LoggedinUser.Company.Id.ToString().PadLeft(3, '0') + type/*+LoggedinUser.CurrentFiscalYear.YearKey*/ + maxno.ToString().PadLeft(5, '0');
            return SerialID;
        }
    }
}
