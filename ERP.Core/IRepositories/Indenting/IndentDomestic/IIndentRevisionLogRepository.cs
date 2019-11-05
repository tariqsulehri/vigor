using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndentRevisionLogRepository
    {
        void Add(IndentRevisionLog indRevisionLog);
        void Edit(IndentRevisionLog indRevisionLog);
        bool Remove(IndentRevisionLog indRevisionLog);
        IndentRevisionLog FindById(int id);
        bool IsDuplicate(IndentRevisionLog indRevisionLog);
        IEnumerable<IndentRevisionLog> GetAllIndRevisionLog();
    }
}
