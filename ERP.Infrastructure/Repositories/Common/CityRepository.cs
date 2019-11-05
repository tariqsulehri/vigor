using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.CommonIRepositories;
using ERP.Core.Models.Common;

namespace ERP.Infrastructure.Repositories.Common
{
    public class CityRepository: ICityRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(City city)
        {
            _db.City.Add(city);
            _db.SaveChanges();
        }
       public void Edit(City modifiedCity)
        {
            var existingCity = _db.City.Find(modifiedCity.Id);
            if(existingCity!=null)
            {
                existingCity.Name = modifiedCity.Name;
                existingCity.StId = modifiedCity.StId;
                existingCity.Ccode = modifiedCity.Ccode;
                _db.Entry(existingCity).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public bool IsDuplicate(City city)
        {

            if (city.Id == 0)
            {
                return _db.City.Any(x => x.Name == city.Name);
            }

            if (city.Id != 0)
            {
                City reg = _db.City.FirstOrDefault(x => x.Name == city.Name);
                if (reg != null && reg.Id != city.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int ccode)
        {
            var existingCity = _db.City.Find(ccode);

            if (existingCity != null)
            {
                _db.City.Remove(existingCity);
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
        public City FindById(int ccode)
        {
            var city = _db.City.Find(ccode);
            return city;
        }

       
        public IEnumerable<City> GetAllCities()
        {
            IEnumerable<City> city = _db.City.ToList();
            return city;
        }
    }

}
