using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class ProductRepository : IProductRepository
    {
        public ErpDbContext _db;

        public ProductRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Edit(Product product)
        {
            try
            {
                var existingRecord = _db.Products.Find(product.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(product);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }

        public Product FindById(int id)
        {
            var product = _db.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            IEnumerable<Product> products = _db.Products.ToList();
            return products;
        }

        public bool IsDuplicate(Product product)
        {
            if (product.Id == 0)
            {
                return _db.Products.Any(x => x.Description == product.Description);
            }

            if (product.Id != 0)
            {
                Product prod = _db.Products.FirstOrDefault(x => x.Description == product.Description);
                if (prod != null && prod.Id != product.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(Product product)
        {
            var existingRecord = _db.Products.Find(product.Id);

            if (existingRecord != null)
            {
                _db.Products.Remove(existingRecord);
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
    }
}
