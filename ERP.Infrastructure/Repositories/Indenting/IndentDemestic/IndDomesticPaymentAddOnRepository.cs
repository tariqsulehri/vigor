using ERP.Core.IRepositories.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.viewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndDomesticPaymentAddOnRepository : IIndDomesticPaymentAddOnRepository
    {
        private ErpDbContext db;
        public IndDomesticPaymentAddOnRepository()
        {
            db = new ErpDbContext();
        }

        public void Add(IndDomesticPaymentAddOn indDomesticPaymentAddOn)
        {
            db.IndDomesticPaymentAddOn.Add(indDomesticPaymentAddOn);
            db.SaveChanges();
        }

        public void Edit(IndDomesticPaymentAddOn indDomesticPaymentAddOn)
        {
            var result = db.IndDomesticPaymentAddOn.SingleOrDefault(b => b.Id == indDomesticPaymentAddOn.Id);
            if (result != null)
            {
                try
                {
                    //db.IndDomesticPaymentAddOn.Attach(indDomesticPaymentAddOn);
                    db.Entry(indDomesticPaymentAddOn).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public IndDomesticAddOnTemplate FindAddOnTemplateById(int id)
        {
            IndDomesticAddOnTemplate rc = db.IndDomesticAddOnTemplate.Find(id);
            return rc;
        }

        public IndDomesticPaymentAddOn FindById(int id)
        {
            IndDomesticPaymentAddOn rc = db.IndDomesticPaymentAddOn.Find(id);
            return rc;
        }

        public IEnumerable<IndDomesticPaymentAddOn> GetAllIndDomesticPaymentAddOns()
        {
            return db.IndDomesticPaymentAddOn.ToList();
        }

        public IEnumerable<IndDomesticAddOnTemplate> GetAllIndIndDomesticAddOnTemplates()
        {
            return db.IndDomesticAddOnTemplate.ToList();
        }


        public IndDomesticAddOnTemplate GetAllIndIndDomesticAddOnTemplateById(int id)
        {
            IndDomesticAddOnTemplate rc = db.IndDomesticAddOnTemplate.Find(id);
            return rc;
        }

        public IEnumerable<IndDomesticPaymentsAddOnList> GetAllIndIndDomesticPaymentsAddOnLists()
        {
            return db.IndDomesticPaymentsAddOnLists.ToList();
        }


        public IndDomesticPaymentsAddOnList GetAllIndIndDomesticPaymentsAddOnListById(int id)
        {
            IndDomesticPaymentsAddOnList rc = db.IndDomesticPaymentsAddOnLists.Find(id);
            return rc;

        }


        

        public bool Remove(IndDomesticPaymentAddOn indDomesticPaymentAddOn)
        {
            var existingRecord = db.IndDomesticPaymentAddOn.Find(indDomesticPaymentAddOn.Id);

            if (existingRecord != null)
            {
                db.IndDomesticPaymentAddOn.Remove(existingRecord);
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
