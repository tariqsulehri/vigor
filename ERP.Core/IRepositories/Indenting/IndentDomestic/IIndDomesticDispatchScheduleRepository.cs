using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticDispatchScheduleRepository
    {
        void Add(IndDomesticDispatchSchedule indDomesticDispatchSchedule);
        void Edit(IndDomesticDispatchSchedule indDomesticDispatchSchedule);
        bool Remove(IndDomesticDispatchSchedule indDomesticDispatchSchedule);
        IndDomesticDispatchSchedule FindById(int id);
        bool IsDuplicate(IndDomesticDispatchSchedule indDomesticDispatchSchedule);
        IEnumerable<IndDomesticDispatchSchedule> GetAllIndDomesticDispatchSchedule();
    }
}
