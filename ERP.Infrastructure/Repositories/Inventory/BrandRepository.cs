using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.CommonIRepositories;
using ERP.Core.IRepositories.InventoryIRepository;
using ERP.Core.Models.Common;
using ERP.Core.Models.Inventory;
using System;

namespace ERP.Infrastructure.Repositories.Inventory
{
    public class BrandRepository: IBrandRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(Brand brand)
        {
            _db.Brand.Add(brand);
            _db.SaveChanges();
        }

        public void Edit(Brand brand)
        {
            try
            {
                _db.Brand.Add(brand);
                _db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
			
        }
		  public bool IsDuplicate(Brand brand)
        {
            if (brand.Id == 0)
            {
                return _db.Brand.Any(x => x.Title == brand.Title);
            }

            if (brand.Id != 0)
            {
                Brand reg = _db.Brand.FirstOrDefault(x => x.Title == brand.Title);
                if (reg != null && reg.Id != brand.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int bcode)
        {
            var existingBrand = _db.Brand.Find(bcode);

            if (existingBrand != null)
            {
                _db.Brand.Remove(existingBrand);
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

       public Brand FindById(int bcode)
        {
            var brand = _db.Brand.Find(bcode);
            return brand;
        }

        

        public IEnumerable<Brand> GetAllbrands()
        {
            IEnumerable<Brand> brands = _db.Brand.ToList();
            return brands;
        }
    }

}
