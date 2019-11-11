using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HrEmployeeRepository : HrEmployeeIRepository
    {
        private readonly ErpDbContext _db;
        public HrEmployeeRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HrEmployee hrEmployee)
        {
            _db.HrEmployee.Add(hrEmployee);
            _db.SaveChanges();
        }

        public void Edit(HrEmployee hrEmployee)
        {

            using (var context = _db.Database.BeginTransaction())
            {
                try
                {

                    var existingRecord = _db.HrEmployee.Find(hrEmployee.EmployeeID);
                    _db.Entry(existingRecord).CurrentValues.SetValues(hrEmployee);

                    HrEmployee employee = _db.HrEmployee.Find(hrEmployee.Id);
                    var cmd = ("DELETE FROM HR_EmployeeExperience WHERE EmployeeId = '" + hrEmployee.Id + "'");
                    _db.Database.ExecuteSqlCommand(cmd);

                    var cmd1 = ("DELETE FROM HR_EmployeeQualification WHERE EmployeeId = '" + hrEmployee.Id + "'");
                    _db.Database.ExecuteSqlCommand(cmd1);

                    foreach (var ex in hrEmployee.HR_EmployeeExperience)
                    {
                        HR_EmployeeExperience exp = new HR_EmployeeExperience();
                                exp.EmployeeNo = ex.EmployeeNo;
                                exp.Organization = ex.Organization;
                                exp.Designation = ex.Designation;
                                exp.ResignedOn = ex.ResignedOn;
                                exp.ReasonToLeave = ex.ReasonToLeave;
                                exp.JoinigDate = ex.JoinigDate;
                                exp.CreatedBy = ex.CreatedBy;
                                exp.CreatedOn = ex.CreatedOn;
                                exp.ModifiedBy = ex.ModifiedBy;
                                exp.ModifiedOn = DateTime.Now;
                                exp.EmployeeId = ex.EmployeeId;

                    }

                    foreach (var qu in hrEmployee.HR_EmployeeQualification)
                    {
                        HR_EmployeeQualification quli = new HR_EmployeeQualification();

                                quli.EmployeeNo = qu.EmployeeNo;
                                quli.DegreeId = qu.DegreeId;
                                quli.Institution = qu.Institution;
                                quli.Marks_gpa = qu.Marks_gpa;
                                quli.Grade = qu.Grade;
                                quli.Division = qu.Division;
                                quli.Status = qu.Status;
                                quli.DegreeSession = qu.DegreeSession;
                                quli.CreatedBy = qu.CreatedBy;
                                quli.CreatedOn = qu.CreatedOn;
                                quli.ModifiedBy = qu.ModifiedBy;
                                quli.ModifiedOn = DateTime.Now;
                                quli.EmployeeId = qu.EmployeeId;

                                _db.HR_EmployeeQualification.Add(quli);

                    }

                    _db.SaveChanges();
                    context.Commit();

                }
                catch (Exception ex)
                {
                    context.Rollback();
                    //Console.WriteLine(ex.Message);  
                    throw ex;
                }
            }
        }
        public bool IsDuplicate(HrEmployee hrEmployee)
        {

            if (hrEmployee.Id == 0)
            {
                return _db.HrEmployee.Any(x => x.Title == hrEmployee.Title);
            }

            if (hrEmployee.Id != 0)
            {
                HrEmployee reg = _db.HrEmployee.FirstOrDefault(x => x.Title == hrEmployee.Title);
                if (reg != null && reg.Id != hrEmployee.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.HrEmployee.Find(id);

            if (existingRecord != null)
            {
                _db.HrEmployee.Remove(existingRecord);
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

        public HrEmployee FindById(int id)
        {
            var employee = _db.HrEmployee.Find(id);
            return employee;
        }

        public IEnumerable<HrEmployee> GetAllEmployees()
        {
            return _db.HrEmployee.ToList();
        }
    }
}
