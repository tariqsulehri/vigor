using ERP.Core.IRepositories.Indenting.Inspection;
using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting.Inspection
{
    public class YarnInspUstersRepository : IYarnInspUstersRepository
    {
        public ErpDbContext DB;

        public YarnInspUstersRepository()
        {
            DB = new ErpDbContext();
        }
        public void Add(YarnInspUsters yarnInspUsters)
        {
            DB.YarnInspUsters.Add(yarnInspUsters);
            DB.SaveChanges();
        }

        public void Edit(YarnInspUsters yarnInspUsters)
        {
            try
            {
                var existingRecord = DB.YarnInspUsters.Find(yarnInspUsters.Id);
                DB.Entry(existingRecord).CurrentValues.SetValues(yarnInspUsters);
                DB.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public YarnInspUsters FindById(int id)
        {
            return DB.YarnInspUsters.Find(id);
        }

        public IEnumerable<YarnInspUsters> GetAllYarnInspUsters()
        {
            return DB.YarnInspUsters.ToList();
        }

        public bool IsDuplicate(YarnInspUsters yarnInspUsters)
        {
            throw new NotImplementedException();
        }

        public bool Remove(YarnInspUsters yarnInspUsters)
        {
            var existingRecord = DB.YarnInspUsters.Find(yarnInspUsters.Id);

            if (existingRecord != null)
            {
                DB.YarnInspUsters.Remove(existingRecord);
            }

            if (DB.SaveChanges() == 1)
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
