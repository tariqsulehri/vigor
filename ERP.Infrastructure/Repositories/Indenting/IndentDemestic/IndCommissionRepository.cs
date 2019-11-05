using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndCommissionRepository : IIndCommissionRepository
    {
        private ErpDbContext db;
        public IndCommissionRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndCommission indCommission)
        {
            throw new NotImplementedException();
        }

        public void Edit(IndCommission indCommission)
        {
            throw new NotImplementedException();
        }

        public IndCommission FindById(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IndCommission> GetAllIndIndCommission()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(IndCommission indCommission)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndCommission indCommission)
        {
            throw new NotImplementedException();
        }
    }
}
