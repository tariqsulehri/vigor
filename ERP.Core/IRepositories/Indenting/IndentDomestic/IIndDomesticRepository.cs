using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndDomesticRepository
    {
        void Add(IndDomestic indDomestic);
        void Edit(IndDomestic indDomestic);
        bool Remove(IndDomestic indDomestic);
        IndDomestic FindById(int id);
        bool IsDuplicate(IndDomestic indDomestic);
        IEnumerable<IndDomestic> GetAllIndDomectic();
    }
}
