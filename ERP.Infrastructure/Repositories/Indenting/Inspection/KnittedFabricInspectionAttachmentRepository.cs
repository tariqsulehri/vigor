using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.Indenting.Inspection;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class KnittedFabricInspectionAttachmentRepository : IKnittedFabricInspectionAttachmentRepository
    {
        public ErpDbContext db;
        public KnittedFabricInspectionAttachmentRepository()
        {
                db =  new ErpDbContext();
        }

        public void Add(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment)
        {
            db.KnittedFabricInspectionAttachment.Add(KnittedFabricInspectionAttachment);
            db.SaveChanges();
        }

        public void Edit(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment)
        {
            //try
            //{
            //    var existingRecord = db.KnittedFabricInspectionAttachment.Find(KnittedFabricInspectionAttachment.InspectionCode);
            //    db.Entry(existingRecord).CurrentValues.SetValues(KnittedFabricInspectionAttachment);
            //    db.SaveChanges();

            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);  
            //    throw ex;
            //}
            
        }

        public KnittedFabricInspectionAttachment FindById(string id)
        {
            KnittedFabricInspectionAttachment c = db.KnittedFabricInspectionAttachment.Find(id);
            return c;
        }

        public IEnumerable<KnittedFabricInspectionAttachment> GetAllKnittedFabricInspectionAttachment()
        {
            return db.KnittedFabricInspectionAttachment.ToList();
        }

        public bool IsDuplicate(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment)
        {
            return false;
        }

        public IEnumerable<KnittedFabricInspectionAttachment> GetAllKnittedFabricInspectionAttachments()
        {
            return db.KnittedFabricInspectionAttachment.ToList();
        }


        public bool Remove(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment)
        {
            //var existingRecord = db.KnittedFabricInspectionAttachment.Find(KnittedFabricInspectionAttachment.InspectionCode);

            //if (existingRecord != null)
            //{
            //    db.KnittedFabricInspectionAttachment.Remove(existingRecord);
            //}

            //if (db.SaveChanges() == 1)
            //{
            //    return true;

            //}
            //else
            //{
            //    return false;
            //};
            return true;
        }
    }
}