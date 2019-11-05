using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.Fin
{
    public class FinBookTypeRepositry : IFinBookTypeRepositry
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(FinBookType finBook)
        {
            throw new NotImplementedException();
        }

        public void Edit(FinBookType finBook)
        {
            throw new NotImplementedException();
        }

        public CoaL1 FindById(int BookID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FinBookType> GetAllbBookTypes()
        {
            IEnumerable<FinBookType> finBookTypes = _db.FinBookType.OrderByDescending(a=>a.BookID).ToList();
            return finBookTypes;
        }

        public bool IsDuplicate(FinBookType finBook)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int BookID)
        {
            throw new NotImplementedException();
        }
    }
}
