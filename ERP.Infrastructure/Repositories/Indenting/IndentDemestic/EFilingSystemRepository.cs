using ERP.Core.IRepositories.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class EFilingSystemRepository : IEFilingSystemRepository
    {
        private ErpDbContext db;
        public EFilingSystemRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(EFilingSystem IndDomesticEFiling)
        {
            db.EFilingSystems.Add(IndDomesticEFiling);
            db.SaveChanges();
        }

        public void Edit(EFilingSystem IndDomesticEFiling)
        {
            try
            {
                var existingRecord = db.EFilingSystems.Find(IndDomesticEFiling.EFilingID);
                db.Entry(existingRecord).CurrentValues.SetValues(IndDomesticEFiling);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public EFilingSystem FindById(int id)
        {
            EFilingSystem rc = db.EFilingSystems.Find(id);
            return rc;
        }

        public IEnumerable<EFilingSystem> GetAllIndDomesticEFilings()
        {
            return db.EFilingSystems.ToList();
        }

        public bool IsDuplicate(EFilingSystem IndDomesticEFiling)
        {
            if (IndDomesticEFiling.EFilingID == string.Empty)
            {
                return db.EFilingSystems.Any(x => x.FileAttached == IndDomesticEFiling.FileAttached);
            }

            if (IndDomesticEFiling.EFilingID != string.Empty)
            {
                EFilingSystem rc = db.EFilingSystems.FirstOrDefault(x => x.FileAttached == IndDomesticEFiling.FileAttached);
                if (rc != null && rc.EFilingID != IndDomesticEFiling.EFilingID)
                {
                    return true;
                }
            }

            return false;
        }
        public string NewFileKey(EFilingSystem item)
        {
            int maxno = db.EFilingSystems.ToList().Count() > 0 ? db.EFilingSystems.ToList().Max(a => Convert.ToInt32(a.EFilingID)) : 0;
            if (maxno == 0)
            {
                maxno++;
                maxno = Convert.ToInt32(item.CreatedOn.Year + LoggedinUser.Company.Id.ToString().PadLeft(3, '0') + maxno.ToString().PadLeft(3, '0'));
            }
            else
            {
                maxno++;
            }
            return maxno.ToString();

        }
        public bool Remove(EFilingSystem IndDomesticEFiling)
        {
            var existingRecord = db.EFilingSystems.Find(IndDomesticEFiling.EFilingID);

            if (existingRecord != null)
            {
                db.EFilingSystems.Remove(existingRecord);
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
