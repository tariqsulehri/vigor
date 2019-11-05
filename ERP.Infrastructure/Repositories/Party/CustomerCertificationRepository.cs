using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ERP.Core.IRepositories.PartyIRepository;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Infrastructure.Repositories.Party
{
    public class CustomerCertificationRepository : ICustomerCertificationRepository
    {
        private readonly ErpDbContext _db;
        public CustomerCertificationRepository()
        {
           _db = new ErpDbContext();    
        }
        public void Add(CustomerCertification customerCertification)
        {
            _db.CustomerCertifications.Add(customerCertification);
            _db.SaveChanges();
        }

        public void Edit(CustomerCertification customerCertification)
        {
            _db.Entry(customerCertification).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.CustomerCertifications.Find(id);
            if (existingRecord != null)
            {
                _db.CustomerCertifications.Remove(existingRecord);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public CustomerCertification FindById(int id)
        {
            var customerCertification = _db.CustomerCertifications.Find(id);
            return customerCertification;
        }
        public IEnumerable<CustomerCertification> GetAllCustomerCertification()
        {
            return _db.CustomerCertifications.ToList();
        }
    }
}
