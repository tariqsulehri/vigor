using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IIndentInspectionRepository
    {
        void Add(IndentInspection indInspection);
        void Edit(IndentInspection indInspection);
        bool Remove(IndentInspection indInspection);
        IndentInspection FindById(int id);
        bool IsDuplicate(IndentInspection indInspection);
        IEnumerable<IndentInspection> GetAllIndInspection();
    }
}
