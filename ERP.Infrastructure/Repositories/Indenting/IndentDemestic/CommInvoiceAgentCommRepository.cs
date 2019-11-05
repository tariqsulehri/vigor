using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;
using System.Data.Entity;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class CommInvoiceAgentCommRepository : ICommInvoiceAgentCommRepository
    {
        ErpDbContext db;
        public CommInvoiceAgentCommRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(CommInvoiceAgentComm commInvoiceAgentComm)
        {
            db.CommInvoiceAgentComm.Add(commInvoiceAgentComm);
            db.SaveChanges();
        }

        public void Edit(CommInvoiceAgentComm commInvoiceAgentComm)
        {
            var result = db.CommInvoiceAgentComm.SingleOrDefault(b => b.Id == commInvoiceAgentComm.Id);
            if (result != null)
            {
                try
                {
                  //  db.CommInvoiceAgentComm.Attach(commInvoiceAgentComm);
                    db.Entry(commInvoiceAgentComm).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public CommInvoiceAgentComm FindById(int id)
        {
            CommInvoiceAgentComm ca = db.CommInvoiceAgentComm.Find(id);
            return ca;
        }

        public IEnumerable<CommInvoiceAgentComm> GetAllIndCommInvoiceAgentComm()
        {
            return db.CommInvoiceAgentComm.ToList();
        }

        public bool IsDuplicate(CommInvoiceAgentComm commInvoiceAgentComm)
        {
            throw new NotImplementedException();
        }

        public bool Remove(CommInvoiceAgentComm commInvoiceAgentComm)
        {
            CommInvoiceAgentComm ca = db.CommInvoiceAgentComm.Find(commInvoiceAgentComm.Id);
            if(ca != null)
            {
                db.CommInvoiceAgentComm.Remove(ca);
            }

            if(db.SaveChanges() == 1)
            {
                return true;
            }
            else{

                return false;
            }

        }
    }
}
