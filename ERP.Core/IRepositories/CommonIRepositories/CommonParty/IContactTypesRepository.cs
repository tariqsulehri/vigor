using System.Collections.Generic;
using ERP.Core.Models.Common.Party;

namespace ERP.Core.IRepositories.CommonIRepositories.CommonParty
{
    public interface IContactTypesRepository
    {
        void Add(ContactType contactType);
        void Edit(ContactType contactType);
        bool IsDuplicate(ContactType contactType);				  
        bool Remove(int id);
        ContactType FindById(int id);
       
        IEnumerable<ContactType> GetAllContactsTypes();
    }
}
