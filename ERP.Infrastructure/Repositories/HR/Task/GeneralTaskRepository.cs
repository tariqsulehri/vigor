using ERP.Core.IRepositories.HrIRepository.TaskRepository;
using ERP.Core.Models.HR.Task;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR.Task
{
    public class GeneralTaskRepository : IGeneralTaskRepository
    {
        private ErpDbContext db;
        public GeneralTaskRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(GeneralTask GeneralTask)
        {
            db.GeneralTasks.Add(GeneralTask);
            db.SaveChanges();
        }

        public void Edit(GeneralTask GeneralTask)
        {
            var result = db.GeneralTasks.SingleOrDefault(b => b.Id == GeneralTask.Id);
            if (result != null)
            {
                try
                {
                    db.Entry(GeneralTask).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public GeneralTask FindById(int id)
        {
            var gTask = db.GeneralTasks.Find(id);
            return gTask;
        }

        public IEnumerable<GeneralTask> GetAllGeneralTask()
        {
            return db.GeneralTasks.ToList();
        }

        public bool Remove(GeneralTask GeneralTask)
        {
            var existingRecord = db.GeneralTasks.Find(GeneralTask.Id);

            if (existingRecord != null)
            {
                db.GeneralTasks.Remove(existingRecord);
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

        HrTaskProgress IGeneralTaskRepository.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
