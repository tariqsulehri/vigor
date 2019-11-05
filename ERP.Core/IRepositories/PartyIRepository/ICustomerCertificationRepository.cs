using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerCertificationRepository
    {
        void Add(CustomerCertification customerCertification);
        void Edit(CustomerCertification customerCertification);
        bool Remove(int id);
        CustomerCertification FindById(int id);
        IEnumerable<CustomerCertification> GetAllCustomerCertification();
    }
}

