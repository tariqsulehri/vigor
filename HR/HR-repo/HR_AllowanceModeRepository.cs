using ERP.Core.IRepositories.HrIRepository;
using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.HR
{
    public class HR_AllowanceModesRepository : IHR_AllowanceModesRepository
    {
        public ErpDbContext _db;

        public HR_AllowanceModesRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(HR_AllowanceModes HR_AllowanceModes)
        {
            _db.HR_AllowanceModes.Add(HR_AllowanceModes);
            _db.SaveChanges();
        }

        public void Edit(HR_AllowanceModes HR_AllowanceModes)
        {
            _db.Entry(HR_AllowanceModes).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

        }

        public HR_AllowanceModes FindById(string id)
        {
            var allowance = _db.HR_AllowanceModes.Find(id);
            return allowance;
        }

        public IEnumerable<HR_AllowanceModes> GetAllHR_AllowanceModes()
        {
            return _db.HR_AllowanceModes.ToList();
        }

        public bool IsDuplicate(HR_AllowanceModes HR_AllowanceModes)
        {
            if (HR_AllowanceModes.AllowanceMode == "")
            {
                return _db.HR_AllowanceModes.Any(x => x.Description == HR_AllowanceModes.Description);
            }

            if (HR_AllowanceModes.AllowanceMode != "")
            {
                HR_AllowanceModes reg = _db.HR_AllowanceModes.FirstOrDefault(x => x.Description == HR_AllowanceModes.Description);
                if (reg != null && reg.AllowanceMode != HR_AllowanceModes.AllowanceMode)
                {
                    return true;
                }
            }
            return false;
        }
       

        public bool Remove(string id)
            {
                var existingRecord = _db.HR_AllowanceModes.Find(id);

                if (existingRecord != null)
                {
                    _db.HR_AllowanceModes.Remove(existingRecord);
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

