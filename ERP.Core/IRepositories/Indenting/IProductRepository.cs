using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Edit(Product product);
        bool Remove(Product product);
        Product FindById(int id);
        bool IsDuplicate(Product product);
        IEnumerable<Product> GetAllProduct();
    }
}
