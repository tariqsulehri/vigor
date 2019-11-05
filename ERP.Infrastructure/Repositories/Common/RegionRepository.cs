using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ERP.Core.IRepositories.CommonIRepositories;
using ERP.Core.Models.Common;

namespace ERP.Infrastructure.Repositories.Common
{
    public class RegionRepository: IRegionRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(Region region)
        {
            _db.Region.Add(region);
            _db.SaveChanges();
        }
        public void Edit(Region region)
        {
            Region reg = _db.Region.Find(region.Id);
            if (reg != null)
            {
                reg.Title = region.Title;
                _db.Entry(reg).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public bool Remove(int rcode)
        {
            Region existingRecord = _db.Region.Find(rcode);
            if (existingRecord != null)
            {
                _db.Region.Remove(existingRecord);
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
        public Region FindById(int l1Code)
        {
            var account = _db.Region.Find(l1Code);
            return account;
        }

        public bool IsDuplicate(Region region)
        {

            if (region.Id == 0)
            {
                    return _db.Region.Any(x => x.Title == region.Title);
            }

            if (region.Id != 0)
            {
                Region reg = _db.Region.FirstOrDefault(x => x.Title == region.Title);
                if (reg != null && reg.Id != region.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            IEnumerable<Region> regions = _db.Region.ToList();
            return regions;
        }
    }

}
