using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticPaymentAddOnRepository
    {
        void Add(IndDomesticPaymentAddOn indDomesticPaymentAddOn);
        void Edit(IndDomesticPaymentAddOn indDomesticPaymentAddOn);
        bool Remove(IndDomesticPaymentAddOn indDomesticPaymentAddOn);
        IndDomesticPaymentAddOn FindById(int id);
        IEnumerable<IndDomesticPaymentAddOn> GetAllIndDomesticPaymentAddOns();
        IEnumerable<IndDomesticAddOnTemplate> GetAllIndIndDomesticAddOnTemplates();
        IndDomesticAddOnTemplate FindAddOnTemplateById(int id);
                
    }
}
