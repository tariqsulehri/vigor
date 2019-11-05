using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class EmailContractApprovalRepository : IEmailContractApprovalRepository
    {
        private ErpDbContext db;
        public EmailContractApprovalRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(EmailContractApproval EmailContractApproval)
        {
            db.EmailContractApprovals.Add(EmailContractApproval);
            db.SaveChanges();
        }

        public void Edit(EmailContractApproval EmailContractApproval)
        {
            try
            {
                var existingRecord = db.EmailContractApprovals.Find(EmailContractApproval.Id);
                db.Entry(existingRecord).CurrentValues.SetValues(EmailContractApproval);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);  
                throw ex;
            }
        }

        public EmailContractApproval FindById(int id)
        {
            EmailContractApproval rc = db.EmailContractApprovals.Find(id);
            return rc;
        }

        public IEnumerable<EmailContractApproval> GetAllEmailContractApprovals()
        {
            return db.EmailContractApprovals.ToList();
        }

        public bool Remove(EmailContractApproval EmailContractApproval)
        {
            var existingRecord = db.EmailContractApprovals.Find(EmailContractApproval.Id);

            if (existingRecord != null)
            {
                db.EmailContractApprovals.Remove(existingRecord);
            }

            if (db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
