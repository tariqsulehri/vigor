using ERP.Core.IRepositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class QcInspectorRepository : IQcInspectorRepository
    {
        private ErpDbContext db;

        public QcInspectorRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(QcInspector qcInspector)
        {
            db.QcInspector.Add(qcInspector);
            db.SaveChanges();
        }

        public void Edit(QcInspector qcInspector)
        {
            try
            {
                var existingRecord = db.QcInspector.Find(qcInspector.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(qcInspector);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public QcInspector FindById(int id)
        {
            QcInspector c = db.QcInspector.Find(id);
            return c;
        }

        public IEnumerable<QcInspector> GetAllQcInspector()
        {
            return db.QcInspector.ToList();
        }

        public bool IsDuplicate(QcInspector qcInspector)
        {
            if (qcInspector.Id == 0)
            {
                return db.QcInspector.Any(x => x.FullName == qcInspector.FullName);
            }

            if (qcInspector.Id != 0)
            {
                QcInspector rc = db.QcInspector.FirstOrDefault(x => x.FullName == qcInspector.FullName);
                if (rc != null && rc.Id != qcInspector.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(QcInspector qcInspector)
        {
            var existingRecord = db.QcInspector.Find(qcInspector.Id);

            if (existingRecord != null)
            {
                db.QcInspector.Remove(existingRecord);
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
