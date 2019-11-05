using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.Indenting;
using ERP.Core.Models.Indenting;

namespace ERP.Infrastructure.Repositories.Indenting
{
    public class IndGeneralDescriptionsRepository : IIndGeneralDescriptionsRepository
    {
        public ErpDbContext _db;

        public IndGeneralDescriptionsRepository()
        {
            _db = new ErpDbContext();
        }

        public void Add(IndGeneralDescriptions indGeneralDescriptions)
        {
            _db.GeneralDescriptions.Add(indGeneralDescriptions);
            _db.SaveChanges();
        }

        public void Edit(IndGeneralDescriptions indGeneralDescriptions)
        {
            try
            {
                var existingRecord = _db.GeneralDescriptions.Find(indGeneralDescriptions.Id);
                _db.Entry(existingRecord).CurrentValues.SetValues(indGeneralDescriptions);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public bool Remove(IndGeneralDescriptions indGeneralDescriptions)
        {
            IndGeneralDescriptions gd = _db.GeneralDescriptions.Find(indGeneralDescriptions.Id);
            if (gd != null)
            {
                _db.GeneralDescriptions.Remove(gd);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IndGeneralDescriptions FindById(int id)
        {
            IndGeneralDescriptions gd = _db.GeneralDescriptions.Find(id);
            return gd;
        }

        public bool IsDuplicate(IndGeneralDescriptions indGeneralDescriptions)
        {
            if (indGeneralDescriptions.Id == 0)
            {
                return _db.IndPaymentTermses.Any(x => x.Description == indGeneralDescriptions.Description);
            }

            if (indGeneralDescriptions.Id != 0)
            {
                IndGeneralDescriptions rc = _db.GeneralDescriptions.FirstOrDefault(x => x.Description == indGeneralDescriptions.Description);
                if (rc != null && rc.Id != indGeneralDescriptions.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<IndGeneralDescriptions> GetAllIndGeneralDescriptions()
        {
            return _db.GeneralDescriptions.ToList();
        }
    }
}
