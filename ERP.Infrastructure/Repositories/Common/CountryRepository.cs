using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.CommonIRepositories;
using ERP.Core.Models.Common;

namespace ERP.Infrastructure.Repositories.Common
{
    public class CountryRepository :ICountryRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(Country country)
        {
            _db.Country.Add(country);
            _db.SaveChanges();
        }

        public void Edit(Country country)
        {
			//var existingCountry = _db.Country.Find(country.Id);
            //if(existingCountry!=null)
           // {
                //existingCountry.Name = country.Name;
                //existingCountry.RCode = country.RCode;
                //existingCountry.Ccode = country.Ccode;
                _db.Country.Add(country);
                _db.Entry(country).State = EntityState.Modified;
                _db.SaveChanges();
            //}
        }

        public bool Remove(int id)
        {
            var existingCountry = _db.Country.Find(id);

            if (existingCountry != null)
            {
                _db.Country.Remove(existingCountry);
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

        public Country FindById(int id)
        {
            var country = _db.Country.Find(id);
            return country;
        }

         public bool IsDuplicate(Country country)
        {

            if (country.Id == 0)
            {
                return _db.Country.Any(x => x.Name == country.Name);
            }

            if (country.Id != 0)
            {
                Country cou = _db.Country.FirstOrDefault(x => x.Name == country.Name);
                if (cou != null && cou.Id != country.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            IEnumerable<Country> countries = _db.Country.ToList();
            return countries;
        }
    }

    
}
