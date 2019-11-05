using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class CommodityTypeRepository : ICommodityTypeRepository
    {
        ErpDbContext _db;

        public CommodityTypeRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(CommodityType commodityType)
        {
            _db.CommodityTypes.Add(commodityType);
            _db.SaveChanges();
        }

        public void Edit(CommodityType commodityType)
        {
            try
            {
                var existingRecord = _db.CommodityTypes.Find(commodityType.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(commodityType);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }

        public CommodityType FindById(int id)
        {
            var uom = _db.CommodityTypes.Find(id);
            return uom;

        }

        public IEnumerable<CommodityType> GetAllCommodityType()
        {
            IEnumerable<CommodityType> cts = _db.CommodityTypes.ToList();
            return cts;

        }

        public bool IsDuplicate(CommodityType commodityType)
        {
            if (commodityType.Id == 0)
            {
                return _db.CommodityTypes.Any(x => x.Description == commodityType.Description);
            }

            if (commodityType.Id != 0)
            {
                CommodityType ct = _db.CommodityTypes.FirstOrDefault(x => x.Description == commodityType.Description);
                if (ct != null && ct.Id != commodityType.Id)
                {
                    return true;
                }
            }

            return false;

        }

        public bool Remove(CommodityType commodityType)
        {
            var existingRecord = _db.CommodityTypes.Find(commodityType.Id);

            if (existingRecord != null)
            {
                _db.CommodityTypes.Remove(existingRecord);
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
