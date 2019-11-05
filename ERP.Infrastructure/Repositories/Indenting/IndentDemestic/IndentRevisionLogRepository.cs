using ERP.Core.IRepositories.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
   public class IndentRevisionLogRepository : IIndentRevisionLogRepository
    {
        public void Add(IndentRevisionLog indRevisionLog)
        {
            throw new NotImplementedException();
        }

        public void Edit(IndentRevisionLog indRevisionLog)
        {
            throw new NotImplementedException();
        }

        public IndentRevisionLog FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndentRevisionLog> GetAllIndRevisionLog()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(IndentRevisionLog indRevisionLog)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndentRevisionLog indRevisionLog)
        {
            throw new NotImplementedException();
        }
    }
}
