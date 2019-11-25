using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Core.IRepositories.Indenting.IndentExport;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;

namespace ERP.Infrastructure.Repositories.Indenting.IndentExport
{
    public class FNLCommissionBillRepository : IFNLCommissionBillRepository
    {

        ErpDbContext db;
        public FNLCommissionBillRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(FNLCommissionBill FNLCommissionBill)
        {
            db.FNLCommissionBills.Add(FNLCommissionBill);
            db.SaveChanges();
        }

        public void Edit(FNLCommissionBill FNLCommissionBill)
        {
            FNLCommissionBill existingRecord = db.FNLCommissionBills.Find(FNLCommissionBill.Id);
            if (existingRecord != null)
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {

                        db.Entry(existingRecord).CurrentValues.SetValues(FNLCommissionBill);
                        db.SaveChanges();

                        var cmd = ("DELETE FROM FNLCommissionBills WHERE FNLCommissionBillKey = '" + FNLCommissionBill.FNLCommissionBillKey + "'");
                        db.Database.ExecuteSqlCommand(cmd);
                        db.SaveChanges();
                    
                        foreach (var vDetail in FNLCommissionBill.FNL_CommissionPaymentDetails)
                        {

                            FNL_CommissionPaymentDetail dtl = new FNL_CommissionPaymentDetail();

                            var config = new MapperConfiguration(cfg => {
                                cfg.CreateMap<FNL_CommissionPaymentDetail, FNL_CommissionPaymentDetail>();
                            });

                            IMapper iMapper = config.CreateMapper();

                            var destination = iMapper.Map<FNL_CommissionPaymentDetail, FNL_CommissionPaymentDetail>(vDetail);
                            existingRecord.FNL_CommissionPaymentDetails.Add(destination);

                        }

                            db.SaveChanges();
                            context.Commit();
                    }
                    catch (Exception e)
                    {
                        context.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }

        public FNLCommissionBill FindById(int id)
        {
            var rev = db.FNLCommissionBills.Find(id);
            return rev;
        }

        public IEnumerable<FNLCommissionBill> GetAllFNLCommissionBills()
        {
            IEnumerable<FNLCommissionBill> inqs = db.FNLCommissionBills.ToList();
            return inqs;
        }

        public bool IsDuplicate(FNLCommissionBill FNLCommissionBill)
        {
            throw new NotImplementedException();
        }

        public bool Remove(FNLCommissionBill FNLCommissionBill)
        {
            var existingRecord = db.FNLCommissionBills.Find(FNLCommissionBill.Id);

            if (existingRecord != null)
            {
                db.FNLCommissionBills.Remove(existingRecord);
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
