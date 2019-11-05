using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.CommonIRepositories.CommonParty;
using ERP.Core.Models.Common.Party;

namespace ERP.Infrastructure.Repositories.Common.PatryCommon
{
    public class CertificationsRepository : ICertificationsRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(Certifications certifications)
        {
            _db.Certifications.Add(certifications);
            _db.SaveChanges();
        }
        public void Edit(Certifications modifiedCertifications)
        {
 var existingCertifications = _db.Certifications.Find(modifiedCertifications.Id);
            if(existingCertifications!=null)
						   
            {
                existingCertifications.CertificationName = modifiedCertifications.CertificationName;
                existingCertifications.IsActive = modifiedCertifications.IsActive;
                _db.Entry(existingCertifications).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
			
        }

        public bool Remove(int id)
        {
            var existingCertifications = _db.Certifications.Find(id);

            if (existingCertifications != null)
            {
                _db.Certifications.Remove(existingCertifications);
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

        public bool IsDuplicate(Certifications certifications)
        {

            if (certifications.Id == 0)
            {
                return _db.Certifications.Any(x => x.CertificationName == certifications.CertificationName);
            }

            if (certifications.Id != 0)
            {
                Certifications reg = _db.Certifications.FirstOrDefault(x => x.CertificationName == certifications.CertificationName);
                if (reg != null && reg.Id != certifications.Id)
                {
                    return true;
                }
            }

            return false;
        }


        public Certifications FindById(int id)
        {
            var certifications = _db.Certifications.Find(id);
            return certifications;
        }

        public IEnumerable<Certifications> GetAllCertifications()
        {
            IEnumerable<Certifications> certifications = _db.Certifications.ToList();
            return certifications;
        }
    }
}

