using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class ShipingLineRepository : IShipingLineRepository
    {

        public ErpDbContext _db;

        public ShipingLineRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(ShipingLine shipingLine)
        {
            _db.ShipingLines.Add(shipingLine);
            _db.SaveChanges();
        }

        public void Edit(ShipingLine shipingLine)
        {
            try
            {
                var existingRecord = _db.ShipingLines.Find(shipingLine.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(shipingLine);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(ShipingLine shipingLine)
        {
            var existingRecord = _db.ShipingLines.Find(shipingLine.Id);

            if (existingRecord != null)
            {
                _db.ShipingLines.Remove(existingRecord);
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

        public ShipingLine FindById(int id)
        {
            ShipingLine shipingLine = _db.ShipingLines.Find(id);
            return shipingLine;
        }

        public bool IsDuplicate(ShipingLine shipingLine)
        {
            if (shipingLine.Id == 0)
            {
                return _db.ShipingLines.Any(x => x.Name == shipingLine.Name);
            }

            if (shipingLine.Id != 0)
            {
                ShipingLine rc = _db.ShipingLines.FirstOrDefault(x => x.Name == shipingLine.Name);
                if (rc != null && rc.Id != shipingLine.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<ShipingLine> GetAllShipingLine()
        {
            return _db.ShipingLines.ToList();
        }
    }
}
