using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class DocumentEFilingTypeRepository : IDocumentEFilingTypeRepository
    {

        private ErpDbContext db;
        public DocumentEFilingTypeRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(DocumentEFilingType IndDomesticEFiling)
        {
            db.DocumentEFilingTypes.Add(IndDomesticEFiling);
            db.SaveChanges();
        }

        public void Edit(DocumentEFilingType IndDomesticEFiling)
        {
            try
            {
                var existingRecord = db.DocumentEFilingTypes.Find(IndDomesticEFiling.DocumentID);
                db.Entry(existingRecord).CurrentValues.SetValues(IndDomesticEFiling);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public DocumentEFilingType FindById(int id)
        {
            DocumentEFilingType rc = db.DocumentEFilingTypes.Find(id);
            return rc;
        }

        public IEnumerable<DocumentEFilingType> GetAllDocumentEFilingType()
        {
            return db.DocumentEFilingTypes.ToList();
        }

        public bool IsDuplicate(DocumentEFilingType documentEFilingType)
        {
            if (documentEFilingType.DocumentID == string.Empty)
            {
                return db.DocumentEFilingTypes.Any(x => x.Description == documentEFilingType.Description);
            }

            if (documentEFilingType.DocumentID != string.Empty)
            {
                DocumentEFilingType rc = db.DocumentEFilingTypes.FirstOrDefault(x => x.Description == documentEFilingType.Description);
                if (rc != null && rc.DocumentID != documentEFilingType.DocumentID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(DocumentEFilingType documentEFilingType)
        {
            var existingRecord = db.DocumentEFilingTypes.Find(documentEFilingType.DocumentID);

            if (existingRecord != null)
            {
                db.DocumentEFilingTypes.Remove(existingRecord);
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
