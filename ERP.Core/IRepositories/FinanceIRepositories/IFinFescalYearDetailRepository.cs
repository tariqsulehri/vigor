using System.Collections.Generic;
using ERP.Core.Models.Finance;

    namespace ERP.Core.IRepositories.FinanceIRepositories
    {
        public interface IFinFescalYearDetailRepository
        {
            void Add(FinFescalYearDetail fescalYearDetail);
            void Edit(FinFescalYearDetail fescalYearDetail);
            bool Remove(int monthId);
            FinFescalYearDetail FindById(int monthId);
            IEnumerable<FinFescalYearDetail> GetAllFescalYearDetails();

            IEnumerable<FinFescalYearDetail> GetAllFescalYearDetails(int id);

        }
    }


