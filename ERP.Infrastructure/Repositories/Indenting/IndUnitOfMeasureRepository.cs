using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting
{
  public  class IndUnitOfMeasureRepository : IIndUnitOfMeasureRepository
    {
        public ErpDbContext _db;

        public IndUnitOfMeasureRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(IndUnitOfMeasure indUnitOfMeasure)
        {
            _db.IndUnitOfMeasures.Add(indUnitOfMeasure);
            _db.SaveChanges();
        }

        public void Edit(IndUnitOfMeasure indUnitOfMeasure)
        {
            try
            {
                var existingRecord = _db.IndUnitOfMeasures.Find(indUnitOfMeasure.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(indUnitOfMeasure);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }

        }

        public IndUnitOfMeasure FindById(int id)
        {
            var uom = _db.IndUnitOfMeasures.Find(id);
            return uom;
        }

        public IEnumerable<IndUnitOfMeasure> GetAllIndUnitOfMeasure()
        {
            IEnumerable<IndUnitOfMeasure> uoms  = _db.IndUnitOfMeasures.ToList();
            return uoms;
        }

        public bool IsDuplicate(IndUnitOfMeasure indUnitOfMeasure)
        {
            if (indUnitOfMeasure.Id == 0)
            {
                return _db.IndUnitOfMeasures.Any(x => x.Description == indUnitOfMeasure.Description);
            }

            if (indUnitOfMeasure.Id != 0)
            {
                IndUnitOfMeasure uom = _db.IndUnitOfMeasures.FirstOrDefault(x => x.Description == indUnitOfMeasure.Description);
                if (uom != null && uom.Id != indUnitOfMeasure.Id)
                {
                    return true;
                }
            }

            return false;

        }

        public bool Remove(IndUnitOfMeasure indUnitOfMeasure)
        {
            var existingRecord = _db.IndUnitOfMeasures.Find(indUnitOfMeasure.Id);

            if (existingRecord != null)
            {
                _db.IndUnitOfMeasures.Remove(existingRecord);
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
