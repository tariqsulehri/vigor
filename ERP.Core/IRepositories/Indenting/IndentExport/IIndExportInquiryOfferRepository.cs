 using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
    public interface IIndExportInquiryOfferRepository
    {
        void Add(IndExportInquiryOffer indExportInquiryOffer);
        void Edit(IndExportInquiryOffer indExportInquiryOffer);
        bool Remove(IndExportInquiryOffer indExportInquiryOffer);
        IndExportInquiryOffer FindById(int id);
        bool IsDuplicate(IndExportInquiryOffer indExportInquiryOffer);
        IEnumerable<IndExportInquiryOffer> GetAllIndExportInquiryOffers();
    }
}
