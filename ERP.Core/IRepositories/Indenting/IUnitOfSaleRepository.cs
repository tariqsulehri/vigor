using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IUnitOfSaleRepository
    {
        void Add(UnitOfSale unitOfSale);
        void Edit(UnitOfSale unitOfSale);
        bool Remove(UnitOfSale unitOfSale);
        UnitOfSale FindById(int id);
        bool IsDuplicate(UnitOfSale unitOfSale);
        IEnumerable<UnitOfSale> GetAllUnitOfSales();
    }
}
