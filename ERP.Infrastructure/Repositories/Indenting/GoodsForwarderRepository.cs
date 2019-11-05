using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class GoodsForwarderRepository : IGoodsForwarderRepository
    {
        public ErpDbContext _db;

        public GoodsForwarderRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(GoodsForwarder goodsForwarder)
        {
            _db.GoodsForwarder.Add(goodsForwarder);
            _db.SaveChanges();
        }

        public void Edit(GoodsForwarder goodsForwarder)
        {
            try
            {
                var existingRecord = _db.GoodsForwarder.Find(goodsForwarder.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(goodsForwarder);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(GoodsForwarder goodsForwarder)
        {
            GoodsForwarder gf = _db.GoodsForwarder.Find(goodsForwarder.Id);
            if (gf != null)
            {
                _db.GoodsForwarder.Remove(gf);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return true;
            }

        }

        public GoodsForwarder FindById(int id)
        {
            GoodsForwarder gf = _db.GoodsForwarder.Find(id);
            return gf;
        }

        public bool IsDuplicate(GoodsForwarder goodsForwarder)
        {
            if (goodsForwarder.Id == 0)
            {
                return _db.IndPaymentTermses.Any(x => x.Description == goodsForwarder.Name);
            }

            if (goodsForwarder.Id != 0)
            {
                GoodsForwarder rc = _db.GoodsForwarder.FirstOrDefault(x => x.Name == goodsForwarder.Name);
                if (rc != null && rc.Id != goodsForwarder.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<GoodsForwarder> GetAllGoodsForwarder()
        {
            return _db.GoodsForwarder.ToList();
        }
    }
}
