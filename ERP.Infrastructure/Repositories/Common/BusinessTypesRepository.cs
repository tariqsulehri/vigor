using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;
using ERP.Core.IRepositories.CommonIRepositories.CommonIIdent;
			

namespace ERP.Infrastructure.Repositories.Common
{
    public class BusinessTypesRepository : IBusinessTypesRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(BusinessTypes businessTypes)
        {
            _db.BusinessTypes.Add(businessTypes);
            _db.SaveChanges();
        }
        public void Edit(BusinessTypes modifiedBusinessTypes)
        {
            var existingBusinessTypes = _db.BusinessTypes.Find(modifiedBusinessTypes.Id);
            if(existingBusinessTypes!=null)
            {
                existingBusinessTypes.BusinessTitle=modifiedBusinessTypes.BusinessTitle;
                existingBusinessTypes.CreatedBy=modifiedBusinessTypes.CreatedBy;
                existingBusinessTypes.CreatedOn=modifiedBusinessTypes.CreatedOn;
                existingBusinessTypes.ModifiedBy= modifiedBusinessTypes.ModifiedBy;
                existingBusinessTypes.ModifiedOn= modifiedBusinessTypes.ModifiedOn;
                existingBusinessTypes.IsActive= modifiedBusinessTypes.IsActive;
                _db.Entry(existingBusinessTypes).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public bool IsDuplicate(BusinessTypes businessTypes)
        {

            if (businessTypes.Id == 0)
            {
                return _db.BusinessTypes.Any(x => x.BusinessTitle == businessTypes.BusinessTitle);
            }

            if (businessTypes.Id != 0)
            {
                BusinessTypes reg = _db.BusinessTypes.FirstOrDefault(x => x.BusinessTitle == businessTypes.BusinessTitle);
                if (reg != null && reg.Id != businessTypes.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Remove(int ccode)
        {
            var existingBusinessTypes = _db.BusinessTypes.Find(ccode);

            if (existingBusinessTypes != null)
            {
                _db.BusinessTypes.Remove(existingBusinessTypes);
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
        public BusinessTypes FindById(int ccode)
        {
            var businessTypes = _db.BusinessTypes.Find(ccode);
            return businessTypes;
        }

        public IEnumerable<BusinessTypes> GetAllBusinessTypes()
        {
            IEnumerable<BusinessTypes> businessTypes = _db.BusinessTypes.ToList();
            return businessTypes;
        }
    }

}

