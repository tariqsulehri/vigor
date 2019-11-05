using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerSocialRepository
    {
        void Add(CustomerSocial customerSocials);
        void Edit(CustomerSocial customerSocials);
        bool Remove(int id);
        CustomerSocial FindById(int id);
        IEnumerable<CustomerSocial> GetAllCustomerSocial();
    }
}
