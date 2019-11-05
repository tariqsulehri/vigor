using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace ERP.Infrastructure.Repositories.FinRepository
{
    public class FinVTypeRepository:IFinVTypeRepository
    {
        private readonly ErpDbContext _db;

        public FinVTypeRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(FinVType finVtype )
        {
            _db.FinVType.Add(finVtype);
            _db.SaveChanges();
        }

        public void Edit(FinVType finVType)
        {
			FinVType oldFinVType = _db.FinVType.Find(finVType.Id);
            if (oldFinVType != null)
            {
                oldFinVType.Vtype = finVType.Vtype;
                oldFinVType.Description = finVType.Description;
                oldFinVType.Key = finVType.Key;
                _db.Entry(oldFinVType).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
		public bool IsDuplicate(FinVType FinVType)
        {

            if (FinVType.Id == 0) { return _db.FinVType.Any(x => x.Vtype == FinVType.Vtype||x.Description==FinVType.Description); }
            if (FinVType.Id != 0)
            {
                FinVType reg = _db.FinVType.FirstOrDefault(x => x.Vtype == FinVType.Vtype || x.Description == FinVType.Description);
                if (reg != null && reg.Id != FinVType.Id)
                {
                    return true;
                }
            }
            return false;
        } 
        public bool Remove(int id)
        {
            var existingAccount = _db.FinVType.Find(id);
            if (existingAccount != null)
            {
                _db.FinVType.Remove(existingAccount);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }

        public FinVType FindById(int id)
        {
            var vtype = _db.FinVType.Find(id);
            return vtype;
        }

         public FinVType FindByVType(string vType)
        {
            var vtype = _db.FinVType.Where(a => a.Key.Equals(vType)).FirstOrDefault();
            return vtype;
        }


        public IEnumerable<FinVType> GetAllTypes()
        {
            IEnumerable<FinVType> vtypes = _db.FinVType.ToList();
            return vtypes;
        }

    }


}

