using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;
using System.Data.SqlClient;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.viewModels;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndCommissionInvoiceRepository : IIndCommissionInvoiceRepository
    {
        ErpDbContext db;
        public IndCommissionInvoiceRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndCommissionInvoice indCommissionInvoice)
        {
            db.IndCommissionInvoice.Add(indCommissionInvoice);
            db.SaveChanges();
        }

        public void Edit(IndCommissionInvoice indCommissionInvoice)
        {
            IndCommissionInvoice existingRecord = db.IndCommissionInvoice.Find(indCommissionInvoice.Id);

            if (existingRecord != null)
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {

                       // db.IndCommissionInvoice.Attach(indCommissionInvoice);
                        db.Entry(indCommissionInvoice).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        var cmd1 = ("DELETE FROM IndCommissionInvoiceDetails WHERE CommissionInvoiceKey = " + indCommissionInvoice.CommissionInvoiceKey);
                        db.Database.ExecuteSqlCommand(cmd1);
                        db.SaveChanges();



                        foreach (var vDetail in indCommissionInvoice.IndCommissionDetail)
                        {
                            IndCommissionInvoiceDetail dtl = new IndCommissionInvoiceDetail()
                            {
                                CommissionInvoiceNo = vDetail.CommissionInvoiceNo,
                                CommissionInvoiceKey = vDetail.CommissionInvoiceKey,
                                UnitOfSaleId = vDetail.UnitOfSaleId,
                                Rate = vDetail.Rate,
                                Total = vDetail.Total,
                                CompanyId = vDetail.CompanyId,

                            };

                            db.IndCommissionInvoiceDetail.Add(dtl);

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

        public IndCommissionInvoice FindById(int id)
        {
            IndCommissionInvoice ci = db.IndCommissionInvoice.Find(id);
            return ci;
        }

        public IEnumerable<IndCommissionInvoice> GetAllIndIndCommissionInvoice()
        {
            return db.IndCommissionInvoice.ToList();
        }

        public bool IsDuplicate(IndCommissionInvoice indCommissionInvoice)
        {
            throw new NotImplementedException();
        }
        public bool Remove(IndCommissionInvoice indCommissionInvoice)
        {
            return true;
            
        }


        public IList<CommInvoice_VM> GetIndetnDispatchesSummaryByIndent(int IndentId)
        {

            var IndentNo = new SqlParameter("@IndentId", IndentId);
            IList<CommInvoice_VM> commInvoice_VM = db.Database.SqlQuery<CommInvoice_VM>("SP_IndDomesticDispatchSummaryByIndentId @IndentId", IndentNo).ToList();

            return commInvoice_VM;

        }

        public IList<CommInvoice_VM> GetIndetnDispatchesSummaryByDate(int IndentId, DateTime fromDate, DateTime toDate)
        {
            var IndentNo = new SqlParameter("@IndentId", IndentId);
            var from_date = new SqlParameter("@from_date", fromDate);
            var to_date = new SqlParameter("@to_date", toDate);

            IList<CommInvoice_VM> commInvoice_VM = db.Database.SqlQuery<CommInvoice_VM>("SP_IndDomesticDispatchSummaryByDate @from_date,@to_date,@IndentId", from_date, to_date, IndentNo).ToList();
            return commInvoice_VM;

        }
        public string GetInvoiceKey()
        {
            return "VIL" + LoggedinUser.CurrentFiscalYear.Id.ToString().PadLeft(3, '0') + (db.IndCommissionInvoice.ToList().Count()+1).ToString().PadLeft(4, '0');
        }
    }
}
