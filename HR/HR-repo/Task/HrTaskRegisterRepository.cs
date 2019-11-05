using ERP.Core.IRepositories.HrIRepository.TaskRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.HR.Task;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.HR.Task
{
    public class HrTaskRegisterRepository : IHrTaskRegisterRepository
    {
            private ErpDbContext db;
            public HrTaskRegisterRepository()
            {
                db = new ErpDbContext();
            }

            public void Add(HrTaskRegister HrTaskRegister)
            {
                db.HrTaskRegister.Add(HrTaskRegister);
                db.SaveChanges();
            }

            public void Edit(HrTaskRegister HrTaskRegister)
            {
                var result = db.HrTaskRegister.SingleOrDefault(b => b.Id == HrTaskRegister.Id);
                if (result != null)
                {
                    try
                    {
                       // db.HrTaskRegister.Attach(HrTaskRegister);
                        db.Entry(HrTaskRegister).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            public HrTaskRegister FindById(int id)
            {
                HrTaskRegister rc = db.HrTaskRegister.Find(id);
                return rc;
            }

        public IEnumerable<HrTaskRegister> GetAllHrTaskRegister()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HrTaskRegister> GetAllHrTaskRegisters()
            {
                return db.HrTaskRegister.ToList();
            }

            public bool Remove(HrTaskRegister hrTaskRegister)
            {
                var existingRecord = db.HrTaskRegister.Find(hrTaskRegister.Id);

                if (existingRecord != null)
                {
                    db.HrTaskRegister.Remove(existingRecord);
                }

                if (db.SaveChanges() == 1)
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
