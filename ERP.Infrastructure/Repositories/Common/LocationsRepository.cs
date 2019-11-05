using ERP.Core.IRepositories.CommonIRepositories;
using ERP.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Common
{
    public class LocationsRepository : ILocationsRepository
    {
        public ErpDbContext db;
        public LocationsRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(Locations locations)
        {
            db.Locations.Add(locations);
            db.SaveChanges();
        }

        public void Edit(Locations locations)
        {
            throw new NotImplementedException();
        }

        public Locations FindById(int Id)
        {
            return db.Locations.Find(Id);
        }

        public IEnumerable<Locations> GetAllLocations()
        {
            return db.Locations.ToList();
        }

        public bool IsDuplicate(Locations Locations)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Locations location)
        {
            throw new NotImplementedException();
        }
    }
}
