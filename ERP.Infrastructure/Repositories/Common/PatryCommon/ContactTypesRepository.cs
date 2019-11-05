		using System;	 
using System.Collections.Generic;
using System.Linq;
		using System.Text;
using System.Threading.Tasks;		  
using ERP.Core.IRepositories.CommonIRepositories.CommonParty;
using ERP.Core.Models.Common.Party;
using ContactType = ERP.Core.Models.Common.Party.ContactType;

namespace ERP.Infrastructure.Repositories.Common.PatryCommon
{
    public class ContactTypesRepository : IContactTypesRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(ContactType contactType)
        {
            _db.ContactTypes.Add(contactType);
            _db.SaveChanges();
        }
        public void Edit(ContactType modifiedContactTypes)
        {
							var existingContactTypes = _db.ContactTypes.Find(modifiedContactTypes.Id);
            if(existingContactTypes!=null)
            {
                existingContactTypes.Title = modifiedContactTypes.Title;
                _db.Entry(existingContactTypes).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }			  
		
        }

        public bool Remove(int id)
        {
            var existingContactTypes = _db.ContactTypes.Find(id);

            if (existingContactTypes != null)
            {
                _db.ContactTypes.Remove(existingContactTypes);
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
        public ContactType FindById(int id)
        {
            var contactType = _db.ContactTypes.Find(id);
            return contactType;
        }

        public bool IsDuplicate(ContactType contactType)
        {
            if (contactType.Id == 0)
            {
                return _db.ContactTypes.Any(x => x.Title == contactType.Title);
            }

            if (contactType.Id != 0)
            {
                ContactType reg = _db.ContactTypes.FirstOrDefault(x => x.Title == contactType.Title);
                if (reg != null && reg.Id != contactType.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<ContactType> GetAllContactsTypes()
        {
            IEnumerable<ContactType> contactTypes = _db.ContactTypes.ToList();
            return contactTypes;
        }

    }
}
