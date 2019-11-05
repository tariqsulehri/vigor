using System.Collections.Generic;
using System.Linq;
using ERP.Core.Models.Common;
using ERP.Core.IRepositories.CommonIRepositories;


namespace ERP.Infrastructure.Repositories.Common
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
        }
        public void Edit(Company modifiedCompany)
        {
            var existingCompany = _db.Companies.Find(modifiedCompany.Id);
            if(existingCompany!=null)
            {
                existingCompany.BusId = modifiedCompany.BusId;
                existingCompany.CityId = modifiedCompany.CityId;
                existingCompany.CreatedBy = modifiedCompany.CreatedBy;
                existingCompany.CreatedDate = modifiedCompany.CreatedDate;
                existingCompany.CreatedOn = modifiedCompany.CreatedOn;
                existingCompany.Email = modifiedCompany.Email;
                existingCompany.Fax = modifiedCompany.Fax;
                existingCompany.IsActive = modifiedCompany.IsActive;
                existingCompany.LastUpDate = modifiedCompany.LastUpDate;
                existingCompany.MailAddress = modifiedCompany.MailAddress;
                existingCompany.ModifiedBy = modifiedCompany.ModifiedBy;
                existingCompany.ModifiedOn = modifiedCompany.ModifiedOn;
                existingCompany.Name = modifiedCompany.Name;
                existingCompany.Phone = modifiedCompany.Phone;
                existingCompany.WebAddress = modifiedCompany.WebAddress;
                _db.Entry(existingCompany).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            
        }
        public bool IsDuplicate(Company company)
        {

            if (company.Id == 0)
            {
                return _db.Companies.Any(x => x.Name == company.Name);
            }

            if (company.Id != 0)
            {
                Company reg = _db.Companies.FirstOrDefault(x => x.Name == company.Name);
                if (reg != null && reg.Id != company.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Remove(int ccode)
        {
            var existingCompany = _db.Companies.Find(ccode);

            if (existingCompany != null)
            {
                _db.Companies.Remove(existingCompany);
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
        public Company FindById(int ccode)
        {
            var company = _db.Companies.Find(ccode);
            return company;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            IEnumerable<Company> company = _db.Companies.ToList();
            return company;
        }
    }
}

