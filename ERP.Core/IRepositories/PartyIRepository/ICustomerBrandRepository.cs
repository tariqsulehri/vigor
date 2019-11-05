using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Party;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerBrandRepository
    {
        void Add(CustomerBrand customerBrand);
        void Edit(CustomerBrand customerCustomerBrand);
        bool Remove(int id);
        CustomerBrand FindById(int id);
        IEnumerable<CustomerBrand> GetAllCustomerBrand();
    }
}
