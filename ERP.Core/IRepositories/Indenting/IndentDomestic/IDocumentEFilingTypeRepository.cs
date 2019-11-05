using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IDocumentEFilingTypeRepository
    {
        void Add(DocumentEFilingType documentEFilingType);
        void Edit(DocumentEFilingType documentEFilingType);
        bool Remove(DocumentEFilingType documentEFilingType);
        DocumentEFilingType FindById(int id);
        bool IsDuplicate(DocumentEFilingType documentEFilingType);
        IEnumerable<DocumentEFilingType> GetAllDocumentEFilingType();
    }
}
