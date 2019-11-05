using System.Collections.Generic;
using ERP.Core.Models.Common.Party;

namespace ERP.Core.IRepositories.CommonIRepositories.CommonParty
{
    public interface ICertificationsRepository
    {
        void Add(Certifications certifications);
        void Edit(Certifications certifications);
	    bool IsDuplicate(Certifications certification);							
        bool Remove(int id);
        Certifications FindById(int id);
       
        IEnumerable<Certifications> GetAllCertifications();

    }
}
